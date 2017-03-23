﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.KiemTraXacMinh
{
    class CKTXM : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng DCBD & CTDCBD & CTDCHD

        #region KTXM (Kiểm Tra Xác Minh)

        public bool Them(KTXM ktxm)
        {
            try
            {
                if (db.KTXMs.Count() > 0)
                {
                    string ID = "MaKTXM";
                    string Table = "KTXM";
                    decimal MaKTXM = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    ktxm.MaKTXM = getMaxNextIDTable(MaKTXM);
                }
                else
                    ktxm.MaKTXM = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                ktxm.CreateDate = DateTime.Now;
                ktxm.CreateBy = CTaiKhoan.MaUser;
                db.KTXMs.InsertOnSubmit(ktxm);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool Sua(KTXM ktxm)
        {
            try
            {
                ktxm.ModifyDate = DateTime.Now;
                ktxm.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa KTXM", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool Xoa(KTXM ktxm)
        {
            try
            {
                db.KTXMs.DeleteOnSubmit(ktxm);
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa KTXM", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool CheckExist(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.KTXMs.Any(item => item.MaDon == MaDon);
                case "TXL":
                    return db.KTXMs.Any(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.KTXMs.Any(item => item.MaDonTBC == MaDon);
                default:
                    return false;
            }
        }

        public KTXM Get(decimal MaKTXM)
        {
                return db.KTXMs.SingleOrDefault(item => item.MaKTXM == MaKTXM);
        }

        public KTXM Get(string Loai,decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.KTXMs.SingleOrDefault(item => item.MaDon == MaDon);
                case "TXL":
                    return db.KTXMs.SingleOrDefault(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.KTXMs.SingleOrDefault(item => item.MaDonTBC == MaDon);
                default:
                    return null;
            }
        }

        #endregion

        #region CTKTXM (Chi Tiết Kiểm Tra Xác Minh)

        public bool ThemCT(CTKTXM ctktxm)
        {
            try
            {
                if (db.CTKTXMs.Count() > 0)
                {
                    string ID = "MaCTKTXM";
                    string Table = "CTKTXM";
                    decimal MaCTKTXM = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    ctktxm.MaCTKTXM = getMaxNextIDTable(MaCTKTXM);
                }
                else
                    ctktxm.MaCTKTXM = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                ctktxm.CreateDate = DateTime.Now;
                ctktxm.CreateBy = CTaiKhoan.MaUser;
                db.CTKTXMs.InsertOnSubmit(ctktxm);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool SuaCT(CTKTXM ctktxm)
        {
            try
            {
                ctktxm.ModifyDate = DateTime.Now;
                ctktxm.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool XoaCT(CTKTXM ctktxm)
        {
            try
            {
                decimal MaKTXM = ctktxm.MaKTXM.Value;
                db.CTKTXMs.DeleteOnSubmit(ctktxm);
                if (db.CTKTXMs.Any(item => item.MaKTXM == MaKTXM) == false)
                    db.KTXMs.DeleteOnSubmit(db.KTXMs.SingleOrDefault(item => item.MaKTXM == MaKTXM));
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool CheckExist_CT(string Loai, int CreateBy, decimal MaDon, string DanhBo, DateTime NgayKTXM)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.CTKTXMs.Any(item => item.CreateBy==CreateBy&& item.KTXM.MaDon == MaDon && item.DanhBo == DanhBo && item.NgayKTXM == NgayKTXM);
                case "TXL":
                    return db.CTKTXMs.Any(item => item.CreateBy == CreateBy && item.KTXM.MaDonTXL == MaDon && item.DanhBo == DanhBo && item.NgayKTXM == NgayKTXM);
                case "TBC":
                    return db.CTKTXMs.Any(item => item.CreateBy == CreateBy && item.KTXM.MaDonTBC == MaDon && item.DanhBo == DanhBo && item.NgayKTXM == NgayKTXM);
                default:
                    return false;
            }
        }

        public CTKTXM GetCT(decimal MaCTKTXM)
        {
            return db.CTKTXMs.SingleOrDefault(item => item.MaCTKTXM == MaCTKTXM);
        }

        public CTKTXM GetCT(string Loai, decimal MaDon, string DanhBo)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.CTKTXMs.SingleOrDefault(item => item.KTXM.MaDon == MaDon && item.DanhBo == DanhBo);
                case "TXL":
                    return db.CTKTXMs.SingleOrDefault(item => item.KTXM.MaDonTXL == MaDon && item.DanhBo == DanhBo);
                case "TBC":
                    return db.CTKTXMs.SingleOrDefault(item => item.KTXM.MaDonTBC == MaDon && item.DanhBo == DanhBo);
                default:
                    return null;
            }

        }

        public bool CheckExist_CT(decimal MaCTKTXM)
        {
                return db.CTKTXMs.Any(itemCTKTXM => itemCTKTXM.MaCTKTXM == MaCTKTXM);
        }

        public DataTable GetDS(string Loai, DateTime FromNgayKTXM, DateTime ToNgayKTXM)
        {
            switch (Loai)
            {
                case "TKH":
                    var query = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                join itemHTKT in db.HienTrangKiemTras on itemCTKTXM.HienTrangKiemTra equals itemHTKT.TenHTKT into tableHTKT
                                from itemtableHTKT in tableHTKT.DefaultIfEmpty()
                                where itemCTKTXM.KTXM.MaDon != null
                                && itemCTKTXM.NgayKTXM.Value.Date >= FromNgayKTXM.Date && itemCTKTXM.NgayKTXM.Value.Date <= ToNgayKTXM.Date
                                select new
                                {
                                    To="TỔ KHÁCH HÀNG",
                                    itemCTKTXM.MaCTKTXM,
                                    MaDon = "TKH" + itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NgayKTXM,
                                    itemCTKTXM.NoiDungKiemTra,
                                    CreateBy = itemUser.HoTen,
                                    STT_HTKT=itemtableHTKT.STT,
                                    itemCTKTXM.HienTrangKiemTra,
                                    itemCTKTXM.TieuThuTrungBinh,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from itemCTKTXM in db.CTKTXMs
                            join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            join itemHTKT in db.HienTrangKiemTras on itemCTKTXM.HienTrangKiemTra equals itemHTKT.TenHTKT into tableHTKT
                            from itemtableHTKT in tableHTKT.DefaultIfEmpty()
                            where itemCTKTXM.KTXM.MaDonTXL != null
                            && itemCTKTXM.NgayKTXM.Value.Date >= FromNgayKTXM.Date && itemCTKTXM.NgayKTXM.Value.Date <= ToNgayKTXM.Date
                            select new
                            {
                                To = "TỔ XỬ LÝ",
                                itemCTKTXM.MaCTKTXM,
                                MaDon = "TXL" + itemCTKTXM.KTXM.MaDonTXL,
                                itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                itemCTKTXM.DanhBo,
                                itemCTKTXM.HoTen,
                                itemCTKTXM.DiaChi,
                                itemCTKTXM.NgayKTXM,
                                itemCTKTXM.NoiDungKiemTra,
                                CreateBy = itemUser.HoTen,
                                STT_HTKT = itemtableHTKT.STT,
                                itemCTKTXM.HienTrangKiemTra,
                                itemCTKTXM.TieuThuTrungBinh,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from itemCTKTXM in db.CTKTXMs
                            join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            join itemHTKT in db.HienTrangKiemTras on itemCTKTXM.HienTrangKiemTra equals itemHTKT.TenHTKT into tableHTKT
                            from itemtableHTKT in tableHTKT.DefaultIfEmpty()
                            where itemCTKTXM.KTXM.MaDonTBC != null
                            && itemCTKTXM.NgayKTXM.Value.Date >= FromNgayKTXM.Date && itemCTKTXM.NgayKTXM.Value.Date <= ToNgayKTXM.Date
                            select new
                            {
                                To = "TỔ BẤM CHÌ",
                                itemCTKTXM.MaCTKTXM,
                                MaDon = "TBC" + itemCTKTXM.KTXM.MaDonTBC,
                                itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD,
                                itemCTKTXM.DanhBo,
                                itemCTKTXM.HoTen,
                                itemCTKTXM.DiaChi,
                                itemCTKTXM.NgayKTXM,
                                itemCTKTXM.NoiDungKiemTra,
                                CreateBy = itemUser.HoTen,
                                STT_HTKT = itemtableHTKT.STT,
                                itemCTKTXM.HienTrangKiemTra,
                                itemCTKTXM.TieuThuTrungBinh,
                            };
                    return LINQToDataTable(query);
                default:
                    return null;
            }
        }

        public DataTable GetDS(string Loai, int CreateBy, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    var query = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.CreateBy == CreateBy && itemCTKTXM.KTXM.MaDon == MaDon
                                select new
                                {
                                    itemCTKTXM.MaCTKTXM,
                                    MaDon = "TKH" + itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NgayKTXM,
                                    itemCTKTXM.NoiDungKiemTra,
                                    CreateBy = itemUser.HoTen,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from itemCTKTXM in db.CTKTXMs
                            join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            where itemCTKTXM.CreateBy == CreateBy && itemCTKTXM.KTXM.MaDonTXL == MaDon
                            select new
                            {
                                itemCTKTXM.MaCTKTXM,
                                MaDon = "TXL" + itemCTKTXM.KTXM.MaDonTXL,
                                itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                itemCTKTXM.DanhBo,
                                itemCTKTXM.HoTen,
                                itemCTKTXM.DiaChi,
                                itemCTKTXM.NgayKTXM,
                                itemCTKTXM.NoiDungKiemTra,
                                CreateBy = itemUser.HoTen,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from itemCTKTXM in db.CTKTXMs
                            join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            where itemCTKTXM.CreateBy == CreateBy && itemCTKTXM.KTXM.MaDonTBC == MaDon
                            select new
                            {
                                itemCTKTXM.MaCTKTXM,
                                MaDon = "TBC" + itemCTKTXM.KTXM.MaDonTBC,
                                itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD,
                                itemCTKTXM.DanhBo,
                                itemCTKTXM.HoTen,
                                itemCTKTXM.DiaChi,
                                itemCTKTXM.NgayKTXM,
                                itemCTKTXM.NoiDungKiemTra,
                                CreateBy = itemUser.HoTen,
                            };
                    return LINQToDataTable(query);
                default:
                    return null;
            }
        }

        public DataTable GetDS(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    var query = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDon == MaDon
                                select new
                                {
                                    itemCTKTXM.MaCTKTXM,
                                    MaDon = "TKH" + itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NgayKTXM,
                                    itemCTKTXM.NoiDungKiemTra,
                                    CreateBy = itemUser.HoTen,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from itemCTKTXM in db.CTKTXMs
                            join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            where itemCTKTXM.KTXM.MaDonTXL == MaDon
                            select new
                            {
                                itemCTKTXM.MaCTKTXM,
                                MaDon = "TXL" + itemCTKTXM.KTXM.MaDonTXL,
                                itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                itemCTKTXM.DanhBo,
                                itemCTKTXM.HoTen,
                                itemCTKTXM.DiaChi,
                                itemCTKTXM.NgayKTXM,
                                itemCTKTXM.NoiDungKiemTra,
                                CreateBy = itemUser.HoTen,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from itemCTKTXM in db.CTKTXMs
                            join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            where itemCTKTXM.KTXM.MaDonTBC == MaDon
                            select new
                            {
                                itemCTKTXM.MaCTKTXM,
                                MaDon = "TBC" + itemCTKTXM.KTXM.MaDonTBC,
                                itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD,
                                itemCTKTXM.DanhBo,
                                itemCTKTXM.HoTen,
                                itemCTKTXM.DiaChi,
                                itemCTKTXM.NgayKTXM,
                                itemCTKTXM.NoiDungKiemTra,
                                CreateBy = itemUser.HoTen,
                            };
                    return LINQToDataTable(query);
                default:
                    return null;
            }
        }

        public DataTable GetDS(string DanhBo)
        {
            DataTable dt = new DataTable();

            var query = from itemCTKTXM in db.CTKTXMs
                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                        where itemCTKTXM.KTXM.MaDon != null
                        && itemCTKTXM.DanhBo == DanhBo
                        select new
                        {
                            itemCTKTXM.MaCTKTXM,
                            MaDon = "TKH" + itemCTKTXM.KTXM.MaDon,
                            itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                            itemCTKTXM.DanhBo,
                            itemCTKTXM.HoTen,
                            itemCTKTXM.DiaChi,
                            itemCTKTXM.NgayKTXM,
                            itemCTKTXM.NoiDungKiemTra,
                            CreateBy = itemUser.HoTen,
                        };
            dt = LINQToDataTable(query);

            query = from itemCTKTXM in db.CTKTXMs
                    join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                    where itemCTKTXM.KTXM.MaDonTXL != null
                    && itemCTKTXM.DanhBo == DanhBo
                    select new
                    {
                        itemCTKTXM.MaCTKTXM,
                        MaDon = "TXL" + itemCTKTXM.KTXM.MaDonTXL,
                        itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                        itemCTKTXM.DanhBo,
                        itemCTKTXM.HoTen,
                        itemCTKTXM.DiaChi,
                        itemCTKTXM.NgayKTXM,
                        itemCTKTXM.NoiDungKiemTra,
                        CreateBy = itemUser.HoTen,
                    };
            dt.Merge(LINQToDataTable(query));

            query = from itemCTKTXM in db.CTKTXMs
                    join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                    where itemCTKTXM.KTXM.MaDonTBC != null
                    && itemCTKTXM.DanhBo == DanhBo
                    select new
                    {
                        itemCTKTXM.MaCTKTXM,
                        MaDon = "TBC" + itemCTKTXM.KTXM.MaDonTBC,
                        itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD,
                        itemCTKTXM.DanhBo,
                        itemCTKTXM.HoTen,
                        itemCTKTXM.DiaChi,
                        itemCTKTXM.NgayKTXM,
                        itemCTKTXM.NoiDungKiemTra,
                        CreateBy = itemUser.HoTen,
                    };
            dt.Merge(LINQToDataTable(query));

            return dt;
        }

        public DataTable GetDSByDanhBo(int CreateBy, string DanhBo)
        {
            DataTable dt = new DataTable();

            var query = from itemCTKTXM in db.CTKTXMs
                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                        where itemCTKTXM.KTXM.MaDon != null && itemCTKTXM.CreateBy == CreateBy
                        && itemCTKTXM.DanhBo == DanhBo
                        select new
                        {
                            itemCTKTXM.MaCTKTXM,
                            MaDon = "TKH" + itemCTKTXM.KTXM.MaDon,
                            itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                            itemCTKTXM.DanhBo,
                            itemCTKTXM.HoTen,
                            itemCTKTXM.DiaChi,
                            itemCTKTXM.NgayKTXM,
                            itemCTKTXM.NoiDungKiemTra,
                            CreateBy = itemUser.HoTen,
                        };
            dt = LINQToDataTable(query);

            query = from itemCTKTXM in db.CTKTXMs
                    join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                    where itemCTKTXM.KTXM.MaDonTXL != null && itemCTKTXM.CreateBy == CreateBy
                    && itemCTKTXM.DanhBo == DanhBo
                    select new
                    {
                        itemCTKTXM.MaCTKTXM,
                        MaDon = "TXL" + itemCTKTXM.KTXM.MaDonTXL,
                        itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                        itemCTKTXM.DanhBo,
                        itemCTKTXM.HoTen,
                        itemCTKTXM.DiaChi,
                        itemCTKTXM.NgayKTXM,
                        itemCTKTXM.NoiDungKiemTra,
                        CreateBy = itemUser.HoTen,
                    };
            dt.Merge(LINQToDataTable(query));

            query = from itemCTKTXM in db.CTKTXMs
                    join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                    where itemCTKTXM.KTXM.MaDonTBC != null && itemCTKTXM.CreateBy == CreateBy
                    && itemCTKTXM.DanhBo == DanhBo
                    select new
                    {
                        itemCTKTXM.MaCTKTXM,
                        MaDon = "TBC" + itemCTKTXM.KTXM.MaDonTBC,
                        itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD,
                        itemCTKTXM.DanhBo,
                        itemCTKTXM.HoTen,
                        itemCTKTXM.DiaChi,
                        itemCTKTXM.NgayKTXM,
                        itemCTKTXM.NoiDungKiemTra,
                        CreateBy = itemUser.HoTen,
                    };
            dt.Merge(LINQToDataTable(query));

            return dt;
        }

        public DataTable GetDSBySoCongVan(int CreateBy, string SoCongVan)
        {
            DataTable dt = new DataTable();

            var query = from itemCTKTXM in db.CTKTXMs
                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                        where itemCTKTXM.KTXM.MaDon != null && itemCTKTXM.CreateBy == CreateBy
                        && itemCTKTXM.KTXM.DonKH.SoCongVan.Contains(SoCongVan)
                        select new
                        {
                            itemCTKTXM.MaCTKTXM,
                            MaDon = "TKH" + itemCTKTXM.KTXM.MaDon,
                            itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                            itemCTKTXM.DanhBo,
                            itemCTKTXM.HoTen,
                            itemCTKTXM.DiaChi,
                            itemCTKTXM.NgayKTXM,
                            itemCTKTXM.NoiDungKiemTra,
                            CreateBy = itemUser.HoTen,
                        };
            dt = LINQToDataTable(query);

            query = from itemCTKTXM in db.CTKTXMs
                    join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                    where itemCTKTXM.KTXM.MaDonTXL != null && itemCTKTXM.CreateBy == CreateBy
                    && itemCTKTXM.KTXM.DonTXL.SoCongVan.Contains(SoCongVan)
                    select new
                    {
                        itemCTKTXM.MaCTKTXM,
                        MaDon = "TXL" + itemCTKTXM.KTXM.MaDonTXL,
                        itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                        itemCTKTXM.DanhBo,
                        itemCTKTXM.HoTen,
                        itemCTKTXM.DiaChi,
                        itemCTKTXM.NgayKTXM,
                        itemCTKTXM.NoiDungKiemTra,
                        CreateBy = itemUser.HoTen,
                    };
            dt.Merge(LINQToDataTable(query));

            query = from itemCTKTXM in db.CTKTXMs
                    join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                    where itemCTKTXM.KTXM.MaDonTBC != null && itemCTKTXM.CreateBy == CreateBy
                    && itemCTKTXM.KTXM.DonTBC.SoCongVan.Contains(SoCongVan)
                    select new
                    {
                        itemCTKTXM.MaCTKTXM,
                        MaDon = "TBC" + itemCTKTXM.KTXM.MaDonTBC,
                        itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD,
                        itemCTKTXM.DanhBo,
                        itemCTKTXM.HoTen,
                        itemCTKTXM.DiaChi,
                        itemCTKTXM.NgayKTXM,
                        itemCTKTXM.NoiDungKiemTra,
                        CreateBy = itemUser.HoTen,
                    };
            dt.Merge(LINQToDataTable(query));

            return dt;
        }

        public DataTable GetDSBySoCongVan(string SoCongVan)
        {
            DataTable dt = new DataTable();

            var query = from itemCTKTXM in db.CTKTXMs
                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                        where itemCTKTXM.KTXM.MaDon != null
                        && itemCTKTXM.KTXM.DonKH.SoCongVan.Contains(SoCongVan)
                        select new
                        {
                            itemCTKTXM.MaCTKTXM,
                            MaDon = "TKH" + itemCTKTXM.KTXM.MaDon,
                            itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                            itemCTKTXM.DanhBo,
                            itemCTKTXM.HoTen,
                            itemCTKTXM.DiaChi,
                            itemCTKTXM.NgayKTXM,
                            itemCTKTXM.NoiDungKiemTra,
                            CreateBy = itemUser.HoTen,
                        };
            dt = LINQToDataTable(query);

            query = from itemCTKTXM in db.CTKTXMs
                    join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                    where itemCTKTXM.KTXM.MaDonTXL != null
                    && itemCTKTXM.KTXM.DonTXL.SoCongVan.Contains(SoCongVan)
                    select new
                    {
                        itemCTKTXM.MaCTKTXM,
                        MaDon = "TXL" + itemCTKTXM.KTXM.MaDonTXL,
                        itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                        itemCTKTXM.DanhBo,
                        itemCTKTXM.HoTen,
                        itemCTKTXM.DiaChi,
                        itemCTKTXM.NgayKTXM,
                        itemCTKTXM.NoiDungKiemTra,
                        CreateBy = itemUser.HoTen,
                    };
            dt.Merge(LINQToDataTable(query));

            query = from itemCTKTXM in db.CTKTXMs
                    join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                    where itemCTKTXM.KTXM.MaDonTBC != null
                    && itemCTKTXM.KTXM.DonTBC.SoCongVan.Contains(SoCongVan)
                    select new
                    {
                        itemCTKTXM.MaCTKTXM,
                        MaDon = "TBC" + itemCTKTXM.KTXM.MaDonTBC,
                        itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD,
                        itemCTKTXM.DanhBo,
                        itemCTKTXM.HoTen,
                        itemCTKTXM.DiaChi,
                        itemCTKTXM.NgayKTXM,
                        itemCTKTXM.NoiDungKiemTra,
                        CreateBy = itemUser.HoTen,
                    };
            dt.Merge(LINQToDataTable(query));

            return dt;
        }

        public DataTable GetDS(int CreateBy, DateTime FromNgayKTXM, DateTime ToNgayKTXM)
        {
            DataTable dt = new DataTable();

            var query = from itemCTKTXM in db.CTKTXMs
                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                        where itemCTKTXM.KTXM.MaDon != null && itemCTKTXM.CreateBy == CreateBy
                        && itemCTKTXM.NgayKTXM.Value.Date >= FromNgayKTXM.Date && itemCTKTXM.NgayKTXM.Value.Date <= ToNgayKTXM.Date
                        select new
                        {
                            itemCTKTXM.MaCTKTXM,
                            MaDon = "TKH" + itemCTKTXM.KTXM.MaDon,
                            itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                            itemCTKTXM.DanhBo,
                            itemCTKTXM.HoTen,
                            itemCTKTXM.DiaChi,
                            itemCTKTXM.NgayKTXM,
                            itemCTKTXM.NoiDungKiemTra,
                            CreateBy = itemUser.HoTen,
                        };
            dt = LINQToDataTable(query);

            query = from itemCTKTXM in db.CTKTXMs
                    join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                    where itemCTKTXM.KTXM.MaDonTXL != null && itemCTKTXM.CreateBy == CreateBy
                    && itemCTKTXM.NgayKTXM.Value.Date >= FromNgayKTXM.Date && itemCTKTXM.NgayKTXM.Value.Date <= ToNgayKTXM.Date
                    select new
                    {
                        itemCTKTXM.MaCTKTXM,
                        MaDon = "TXL" + itemCTKTXM.KTXM.MaDonTXL,
                        itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                        itemCTKTXM.DanhBo,
                        itemCTKTXM.HoTen,
                        itemCTKTXM.DiaChi,
                        itemCTKTXM.NgayKTXM,
                        itemCTKTXM.NoiDungKiemTra,
                        CreateBy = itemUser.HoTen,
                    };
            dt.Merge(LINQToDataTable(query));

            query = from itemCTKTXM in db.CTKTXMs
                    join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                    where itemCTKTXM.KTXM.MaDonTBC != null && itemCTKTXM.CreateBy == CreateBy
                    && itemCTKTXM.NgayKTXM.Value.Date >= FromNgayKTXM.Date && itemCTKTXM.NgayKTXM.Value.Date <= ToNgayKTXM.Date
                    select new
                    {
                        itemCTKTXM.MaCTKTXM,
                        MaDon = "TBC" + itemCTKTXM.KTXM.MaDonTBC,
                        itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD,
                        itemCTKTXM.DanhBo,
                        itemCTKTXM.HoTen,
                        itemCTKTXM.DiaChi,
                        itemCTKTXM.NgayKTXM,
                        itemCTKTXM.NoiDungKiemTra,
                        CreateBy = itemUser.HoTen,
                    };
            dt.Merge(LINQToDataTable(query));

            return dt;
        }

        public DataTable GetDS(DateTime FromNgayKTXM, DateTime ToNgayKTXM)
        {
            DataTable dt = new DataTable();
            var query = from itemCTKTXM in db.CTKTXMs
                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                        join itemHTKT in db.HienTrangKiemTras on itemCTKTXM.HienTrangKiemTra equals itemHTKT.TenHTKT into tableHTKT
                        from itemtableHTKT in tableHTKT.DefaultIfEmpty()
                        where itemCTKTXM.KTXM.MaDon != null
                        && itemCTKTXM.NgayKTXM.Value.Date >= FromNgayKTXM.Date && itemCTKTXM.NgayKTXM.Value.Date <= ToNgayKTXM.Date
                        select new
                        {
                            To = "TỔ KHÁCH HÀNG",
                            itemCTKTXM.MaCTKTXM,
                            MaDon = "TKH" + itemCTKTXM.KTXM.MaDon,
                            itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                            itemCTKTXM.DanhBo,
                            itemCTKTXM.HoTen,
                            itemCTKTXM.DiaChi,
                            itemCTKTXM.NgayKTXM,
                            itemCTKTXM.NoiDungKiemTra,
                            CreateBy = itemUser.HoTen,
                            STT_HTKT=itemtableHTKT.STT,
                            itemCTKTXM.HienTrangKiemTra,
                            itemCTKTXM.TieuThuTrungBinh,
                        };
            dt = LINQToDataTable(query);

            query = from itemCTKTXM in db.CTKTXMs
                    join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                    join itemHTKT in db.HienTrangKiemTras on itemCTKTXM.HienTrangKiemTra equals itemHTKT.TenHTKT into tableHTKT
                    from itemtableHTKT in tableHTKT.DefaultIfEmpty()
                    where itemCTKTXM.KTXM.MaDonTXL != null
                    && itemCTKTXM.NgayKTXM.Value.Date >= FromNgayKTXM.Date && itemCTKTXM.NgayKTXM.Value.Date <= ToNgayKTXM.Date
                    select new
                    {
                        To = "TỔ XỬ LÝ",
                        itemCTKTXM.MaCTKTXM,
                        MaDon = "TXL" + itemCTKTXM.KTXM.MaDonTXL,
                        itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                        itemCTKTXM.DanhBo,
                        itemCTKTXM.HoTen,
                        itemCTKTXM.DiaChi,
                        itemCTKTXM.NgayKTXM,
                        itemCTKTXM.NoiDungKiemTra,
                        CreateBy = itemUser.HoTen,
                        STT_HTKT = itemtableHTKT.STT,
                        itemCTKTXM.HienTrangKiemTra,
                        itemCTKTXM.TieuThuTrungBinh,
                    };
            dt.Merge(LINQToDataTable(query));

            query = from itemCTKTXM in db.CTKTXMs
                    join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                    join itemHTKT in db.HienTrangKiemTras on itemCTKTXM.HienTrangKiemTra equals itemHTKT.TenHTKT into tableHTKT
                    from itemtableHTKT in tableHTKT.DefaultIfEmpty()
                    where itemCTKTXM.KTXM.MaDonTBC != null
                    && itemCTKTXM.NgayKTXM.Value.Date >= FromNgayKTXM.Date && itemCTKTXM.NgayKTXM.Value.Date <= ToNgayKTXM.Date
                    select new
                    {
                        To = "TỔ BẤM CHÌ",
                        itemCTKTXM.MaCTKTXM,
                        MaDon = "TBC" + itemCTKTXM.KTXM.MaDonTBC,
                        itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD,
                        itemCTKTXM.DanhBo,
                        itemCTKTXM.HoTen,
                        itemCTKTXM.DiaChi,
                        itemCTKTXM.NgayKTXM,
                        itemCTKTXM.NoiDungKiemTra,
                        CreateBy = itemUser.HoTen,
                        STT_HTKT = itemtableHTKT.STT,
                        itemCTKTXM.HienTrangKiemTra,
                        itemCTKTXM.TieuThuTrungBinh,
                    };
            dt.Merge(LINQToDataTable(query));

            return dt;
        }

        #endregion
    }
}

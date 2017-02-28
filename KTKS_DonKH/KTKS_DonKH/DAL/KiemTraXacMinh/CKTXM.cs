using System;
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
                    //decimal MaKTXM = db.KTXMs.Max(itemKTXM => itemKTXM.MaKTXM);
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

        public KTXM getKTXMbyID(decimal MaKTXM)
        {
            try
            {
                return db.KTXMs.SingleOrDefault(itemKTXM => itemKTXM.MaKTXM == MaKTXM);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
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

        public bool CheckExistCT(string Loai, decimal MaDon, string DanhBo, DateTime NgayKTXM)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.CTKTXMs.Any(item => item.KTXM.MaDon == MaDon && item.DanhBo == DanhBo && item.NgayKTXM == NgayKTXM);
                case "TXL":
                    return db.CTKTXMs.Any(item => item.KTXM.MaDonTXL == MaDon && item.DanhBo == DanhBo && item.NgayKTXM == NgayKTXM);
                case "TBC":
                    return db.CTKTXMs.Any(item => item.KTXM.MaDonTBC == MaDon && item.DanhBo == DanhBo && item.NgayKTXM == NgayKTXM);
                default:
                    return false;
            }
        }

        public DataTable GetDS(string Loai, DateTime FromNgayKTXM, DateTime ToNgayKTXM)
        {
            switch (Loai)
            {
                case "TKH":
                    var query = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDon != null
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
                    return LINQToDataTable(query);
                case "TXL":
                    query = from itemCTKTXM in db.CTKTXMs
                            join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            where itemCTKTXM.KTXM.MaDonTXL != null
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
                    return LINQToDataTable(query);
                case "TBC":
                    query = from itemCTKTXM in db.CTKTXMs
                            join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            where itemCTKTXM.KTXM.MaDonTBC != null
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
                        where itemCTKTXM.KTXM.MaDon != null
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
                    where itemCTKTXM.KTXM.MaDonTXL != null
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
                    where itemCTKTXM.KTXM.MaDonTBC != null
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

        /// <summary>
        /// Lấy Danh Sách Tất Cả CTKTXM chỉ có quyền quản lý được dùng hàm này
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCTKTXM()
        {
            try
            {
                var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                  join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                  where itemCTKTXM.KTXM.MaDon != null
                                  orderby itemCTKTXM.CreateDate descending
                                  select new
                                  {
                                      itemCTKTXM.MaCTKTXM,
                                      itemCTKTXM.KTXM.MaDon,
                                      itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                      itemCTKTXM.DanhBo,
                                      itemCTKTXM.HoTen,
                                      itemCTKTXM.DiaChi,
                                      itemCTKTXM.NoiDungKiemTra,
                                      itemCTKTXM.NgayKTXM,
                                      CreateBy = itemUser.HoTen,
                                  };

                var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                   join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                   where itemCTKTXM.KTXM.MaDonTXL != null
                                   orderby itemCTKTXM.CreateDate descending
                                   select new
                                   {
                                       itemCTKTXM.MaCTKTXM,
                                       MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                       itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                       itemCTKTXM.DanhBo,
                                       itemCTKTXM.HoTen,
                                       itemCTKTXM.DiaChi,
                                       itemCTKTXM.NoiDungKiemTra,
                                       itemCTKTXM.NgayKTXM,
                                       CreateBy = itemUser.HoTen,
                                   };
                DataTable dt = LINQToDataTable(query_DonKH);
                dt.Merge(LINQToDataTable(query_DonTXL));
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByMaDon(decimal MaDon)
        {
            try
            {
                var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                  join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                  where itemCTKTXM.KTXM.MaDon != null && itemCTKTXM.KTXM.MaDon == MaDon
                                  select new
                                  {
                                      itemCTKTXM.MaCTKTXM,
                                      itemCTKTXM.KTXM.MaDon,
                                      itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                      itemCTKTXM.DanhBo,
                                      itemCTKTXM.HoTen,
                                      itemCTKTXM.DiaChi,
                                      itemCTKTXM.NoiDungKiemTra,
                                      itemCTKTXM.NgayKTXM,
                                      CreateBy = itemUser.HoTen,
                                      itemUser.MaU,
                                  };
                return LINQToDataTable(query_DonKH.Distinct());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByMaDons(decimal TuMaDon, decimal DenMaDon)
        {
            try
            {
                var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                  join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                  where itemCTKTXM.KTXM.MaDon != null && itemCTKTXM.KTXM.MaDon >= TuMaDon && itemCTKTXM.KTXM.MaDon <= DenMaDon
                                  select new
                                  {
                                      itemCTKTXM.MaCTKTXM,
                                      itemCTKTXM.KTXM.MaDon,
                                      itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                      itemCTKTXM.DanhBo,
                                      itemCTKTXM.HoTen,
                                      itemCTKTXM.DiaChi,
                                      itemCTKTXM.NoiDungKiemTra,
                                      itemCTKTXM.NgayKTXM,
                                      CreateBy = itemUser.HoTen,
                                      itemUser.MaU,
                                  };
                return LINQToDataTable(query_DonKH.Distinct());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByMaDonTXL(decimal MaDonTXL)
        {
            try
            {
                var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                   join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                   where itemCTKTXM.KTXM.MaDonTXL != null && itemCTKTXM.KTXM.MaDonTXL == MaDonTXL
                                   select new
                                   {
                                       itemCTKTXM.MaCTKTXM,
                                       MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                       itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                       itemCTKTXM.DanhBo,
                                       itemCTKTXM.HoTen,
                                       itemCTKTXM.DiaChi,
                                       itemCTKTXM.NoiDungKiemTra,
                                       itemCTKTXM.NgayKTXM,
                                       CreateBy = itemUser.HoTen,
                                   };
                return LINQToDataTable(query_DonTXL.Distinct());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByMaDonsTXL(decimal TuMaDonTXL, decimal DenMaDonTXL)
        {
            try
            {
                var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                  join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                  where itemCTKTXM.KTXM.MaDon != null && itemCTKTXM.KTXM.MaDonTXL >= TuMaDonTXL && itemCTKTXM.KTXM.MaDonTXL <= DenMaDonTXL
                                  select new
                                  {
                                      itemCTKTXM.MaCTKTXM,
                                      MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                      itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                      itemCTKTXM.DanhBo,
                                      itemCTKTXM.HoTen,
                                      itemCTKTXM.DiaChi,
                                      itemCTKTXM.NoiDungKiemTra,
                                      itemCTKTXM.NgayKTXM,
                                      CreateBy = itemUser.HoTen,
                                      itemUser.MaU,
                                  };
                return LINQToDataTable(query_DonKH.Distinct());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByDanhBo(string DanhBo)
        {
            try
            {
                var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                  join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                  where itemCTKTXM.KTXM.MaDon != null && itemCTKTXM.DanhBo == DanhBo
                                  orderby itemCTKTXM.NgayKTXM descending
                                  select new
                                  {
                                      itemCTKTXM.MaCTKTXM,
                                      itemCTKTXM.KTXM.MaDon,
                                      itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                      itemCTKTXM.DanhBo,
                                      itemCTKTXM.HoTen,
                                      itemCTKTXM.DiaChi,
                                      itemCTKTXM.NoiDungKiemTra,
                                      itemCTKTXM.NgayKTXM,
                                      CreateBy = itemUser.HoTen,
                                      itemUser.MaU,
                                  };

                var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                   join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                   where itemCTKTXM.KTXM.MaDonTXL != null && itemCTKTXM.DanhBo == DanhBo
                                   orderby itemCTKTXM.NgayKTXM descending
                                   select new
                                   {
                                       itemCTKTXM.MaCTKTXM,
                                       MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                       itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                       itemCTKTXM.DanhBo,
                                       itemCTKTXM.HoTen,
                                       itemCTKTXM.DiaChi,
                                       itemCTKTXM.NoiDungKiemTra,
                                       itemCTKTXM.NgayKTXM,
                                       CreateBy = itemUser.HoTen,
                                       itemUser.MaU,
                                   };
                DataTable dt = LINQToDataTable(query_DonKH.Distinct());
                dt.Merge(LINQToDataTable(query_DonTXL.Distinct()));
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMBySoCongVan(string SoCongVan)
        {
            try
            {
                var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                  join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                  where itemCTKTXM.KTXM.MaDon != null && itemCTKTXM.KTXM.DonKH.SoCongVan == SoCongVan
                                  orderby itemCTKTXM.NgayKTXM descending
                                  select new
                                  {
                                      itemCTKTXM.MaCTKTXM,
                                      itemCTKTXM.KTXM.MaDon,
                                      itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                      itemCTKTXM.DanhBo,
                                      itemCTKTXM.HoTen,
                                      itemCTKTXM.DiaChi,
                                      itemCTKTXM.NoiDungKiemTra,
                                      itemCTKTXM.NgayKTXM,
                                      CreateBy = itemUser.HoTen,
                                      itemUser.MaU,
                                  };

                var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                   join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                   where itemCTKTXM.KTXM.MaDonTXL != null && itemCTKTXM.KTXM.DonTXL.SoCongVan == SoCongVan
                                   orderby itemCTKTXM.NgayKTXM descending
                                   select new
                                   {
                                       itemCTKTXM.MaCTKTXM,
                                       MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                       itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                       itemCTKTXM.DanhBo,
                                       itemCTKTXM.HoTen,
                                       itemCTKTXM.DiaChi,
                                       itemCTKTXM.NoiDungKiemTra,
                                       itemCTKTXM.NgayKTXM,
                                       CreateBy = itemUser.HoTen,
                                       itemUser.MaU,
                                   };
                DataTable dt = LINQToDataTable(query_DonKH.Distinct());
                dt.Merge(LINQToDataTable(query_DonTXL.Distinct()));
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByDate(DateTime TuNgay)
        {
            try
            {
                var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                  join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                  where itemCTKTXM.KTXM.MaDon != null && itemCTKTXM.NgayKTXM.Value.Date == TuNgay.Date
                                  orderby itemCTKTXM.NgayKTXM descending
                                  select new
                                  {
                                      itemCTKTXM.MaCTKTXM,
                                      itemCTKTXM.KTXM.MaDon,
                                      itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                      itemCTKTXM.DanhBo,
                                      itemCTKTXM.HoTen,
                                      itemCTKTXM.DiaChi,
                                      itemCTKTXM.NoiDungKiemTra,
                                      itemCTKTXM.NgayKTXM,
                                      CreateBy = itemUser.HoTen,
                                      itemUser.MaU,
                                  };

                var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                   join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                   where itemCTKTXM.KTXM.MaDonTXL != null && itemCTKTXM.NgayKTXM.Value.Date == TuNgay.Date
                                   orderby itemCTKTXM.NgayKTXM descending
                                   select new
                                   {
                                       itemCTKTXM.MaCTKTXM,
                                       MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                       itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                       itemCTKTXM.DanhBo,
                                       itemCTKTXM.HoTen,
                                       itemCTKTXM.DiaChi,
                                       itemCTKTXM.NoiDungKiemTra,
                                       itemCTKTXM.NgayKTXM,
                                       CreateBy = itemUser.HoTen,
                                       itemUser.MaU,
                                   };
                DataTable dt = LINQToDataTable(query_DonKH.Distinct());
                dt.Merge(LINQToDataTable(query_DonTXL.Distinct()));
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXM_TXL()
        {
            try
            {
                var query = from itemCTKTXM in db.CTKTXMs
                            join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            where itemCTKTXM.KTXM.MaDonTXL != null
                            orderby itemCTKTXM.KTXM.MaDonTXL ascending
                            select new
                            {
                                itemCTKTXM.MaCTKTXM,
                                MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                itemCTKTXM.DanhBo,
                                itemCTKTXM.HoTen,
                                itemCTKTXM.DiaChi,
                                itemCTKTXM.NoiDungKiemTra,
                                itemCTKTXM.NgayKTXM,
                                CreateBy = itemUser.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách CTKTXM theo MaDon
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public DataTable LoadDSCTKTXM(decimal MaDon)
        {
            try
            {
                var query = from itemCTKTXM in db.CTKTXMs
                            join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            where itemCTKTXM.KTXM.MaDon == MaDon
                            orderby itemCTKTXM.KTXM.MaDon ascending
                            select new
                            {
                                itemCTKTXM.MaCTKTXM,
                                itemCTKTXM.KTXM.MaDon,
                                itemCTKTXM.DanhBo,
                                itemCTKTXM.HoTen,
                                itemCTKTXM.DiaChi,
                                itemCTKTXM.NoiDungKiemTra,
                                itemCTKTXM.NgayKTXM,
                                CreateBy = itemUser.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách CTKTXM theo User
        /// </summary>
        /// <param name="MaUser"></param>
        /// <returns></returns>
        public DataTable LoadDSCTKTXM(int MaUser)
        {
            try
            {
                var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                  join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                  where itemCTKTXM.KTXM.MaDon != null && itemCTKTXM.CreateBy == MaUser
                                  orderby itemCTKTXM.CreateDate descending
                                  select new
                                  {
                                      itemCTKTXM.MaCTKTXM,
                                      itemCTKTXM.KTXM.MaDon,
                                      itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                      itemCTKTXM.DanhBo,
                                      itemCTKTXM.HoTen,
                                      itemCTKTXM.DiaChi,
                                      itemCTKTXM.NoiDungKiemTra,
                                      itemCTKTXM.NgayKTXM,
                                      CreateBy = itemUser.HoTen,
                                  };

                var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                   join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                   where itemCTKTXM.KTXM.MaDonTXL != null && itemCTKTXM.CreateBy == MaUser
                                   orderby itemCTKTXM.CreateDate descending
                                   select new
                                   {
                                       itemCTKTXM.MaCTKTXM,
                                       MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                       itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                       itemCTKTXM.DanhBo,
                                       itemCTKTXM.HoTen,
                                       itemCTKTXM.DiaChi,
                                       itemCTKTXM.NoiDungKiemTra,
                                       itemCTKTXM.NgayKTXM,
                                       CreateBy = itemUser.HoTen,
                                   };
                DataTable dt = LINQToDataTable(query_DonKH);
                dt.Merge(LINQToDataTable(query_DonTXL));
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByMaDons(int MaUser, decimal TuMaDon, decimal DenMaDon)
        {
            try
            {
                var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                  join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                  where itemCTKTXM.KTXM.MaDon != null && itemCTKTXM.CreateBy == MaUser && itemCTKTXM.KTXM.MaDon >= TuMaDon && itemCTKTXM.KTXM.MaDon <= DenMaDon
                                  select new
                                  {
                                      itemCTKTXM.MaCTKTXM,
                                      itemCTKTXM.KTXM.MaDon,
                                      itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                      itemCTKTXM.DanhBo,
                                      itemCTKTXM.HoTen,
                                      itemCTKTXM.DiaChi,
                                      itemCTKTXM.NoiDungKiemTra,
                                      itemCTKTXM.NgayKTXM,
                                      CreateBy = itemUser.HoTen,
                                      itemUser.MaU,
                                  };

                var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                   join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                   where itemCTKTXM.KTXM.MaDonTXL != null && itemCTKTXM.CreateBy == MaUser && itemCTKTXM.KTXM.MaDonTXL >= TuMaDon && itemCTKTXM.KTXM.MaDonTXL <= DenMaDon
                                   select new
                                   {
                                       itemCTKTXM.MaCTKTXM,
                                       MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                       itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                       itemCTKTXM.DanhBo,
                                       itemCTKTXM.HoTen,
                                       itemCTKTXM.DiaChi,
                                       itemCTKTXM.NoiDungKiemTra,
                                       itemCTKTXM.NgayKTXM,
                                       CreateBy = itemUser.HoTen,
                                       itemUser.MaU,
                                   };
                DataTable dt = LINQToDataTable(query_DonKH.Distinct());
                dt.Merge(LINQToDataTable(query_DonTXL.Distinct()));
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByDate(int MaUser, DateTime TuNgay)
        {
            try
            {
                var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                  join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                  where itemCTKTXM.KTXM.MaDon != null && itemCTKTXM.CreateBy == MaUser && itemCTKTXM.NgayKTXM.Value.Date == TuNgay.Date
                                  orderby itemCTKTXM.NgayKTXM descending
                                  select new
                                  {
                                      itemCTKTXM.MaCTKTXM,
                                      itemCTKTXM.KTXM.MaDon,
                                      itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                      itemCTKTXM.DanhBo,
                                      itemCTKTXM.HoTen,
                                      itemCTKTXM.DiaChi,
                                      itemCTKTXM.NoiDungKiemTra,
                                      itemCTKTXM.NgayKTXM,
                                      CreateBy = itemUser.HoTen,
                                      itemUser.MaU,
                                  };

                var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                   join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                   where itemCTKTXM.KTXM.MaDonTXL != null && itemCTKTXM.CreateBy == MaUser && itemCTKTXM.NgayKTXM.Value.Date == TuNgay.Date
                                   orderby itemCTKTXM.NgayKTXM descending
                                   select new
                                   {
                                       itemCTKTXM.MaCTKTXM,
                                       MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                       itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                       itemCTKTXM.DanhBo,
                                       itemCTKTXM.HoTen,
                                       itemCTKTXM.DiaChi,
                                       itemCTKTXM.NoiDungKiemTra,
                                       itemCTKTXM.NgayKTXM,
                                       CreateBy = itemUser.HoTen,
                                       itemUser.MaU,
                                   };
                DataTable dt = LINQToDataTable(query_DonKH.Distinct());
                dt.Merge(LINQToDataTable(query_DonTXL.Distinct()));
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXM_TXL(int MaUser)
        {
            try
            {
                var query = from itemCTKTXM in db.CTKTXMs
                            join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            where itemCTKTXM.KTXM.MaDonTXL != null && itemCTKTXM.CreateBy == MaUser
                            orderby itemCTKTXM.KTXM.MaDonTXL ascending
                            select new
                            {
                                itemCTKTXM.MaCTKTXM,
                                MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                itemCTKTXM.DanhBo,
                                itemCTKTXM.HoTen,
                                itemCTKTXM.DiaChi,
                                itemCTKTXM.NoiDungKiemTra,
                                itemCTKTXM.NgayKTXM,
                                CreateBy = itemUser.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXM(int MaUser, DateTime TuNgay)
        {
            try
            {
                var query = from itemCTKTXM in db.CTKTXMs
                            //join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            where itemCTKTXM.NgayKTXM.Value.Date == TuNgay.Date //&& itemCTKTXM.CreateBy == MaUser
                            //orderby itemCTKTXM.KTXM.MaDon ascending
                            select new
                            {
                                LoaiBienBan = itemCTKTXM.HienTrangKiemTra,
                                itemCTKTXM.DanhBo,
                                itemCTKTXM.KTXM.MaDon,
                                itemCTKTXM.KTXM.MaDonTXL,
                                itemCTKTXM.LapBangGia,
                                itemCTKTXM.DongTienBoiThuong,
                                itemCTKTXM.ChuyenLapTBCat,
                                itemCTKTXM.TieuThuTrungBinh,
                                //CreateBy = itemUser.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXM(int MaUser, DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemCTKTXM in db.CTKTXMs
                            //join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            where itemCTKTXM.NgayKTXM.Value.Date >= TuNgay.Date && itemCTKTXM.NgayKTXM.Value.Date <= DenNgay.Date //&& itemCTKTXM.CreateBy == MaUser
                            //orderby itemCTKTXM.KTXM.MaDon ascending
                            select new
                            {
                                LoaiBienBan = itemCTKTXM.HienTrangKiemTra,
                                itemCTKTXM.DanhBo,
                                itemCTKTXM.KTXM.MaDon,
                                itemCTKTXM.KTXM.MaDonTXL,
                                itemCTKTXM.LapBangGia,
                                itemCTKTXM.DongTienBoiThuong,
                                itemCTKTXM.ChuyenLapTBCat,
                                itemCTKTXM.TieuThuTrungBinh,
                                //CreateBy = itemUser.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách CTKTXM theo Danh Bộ & User. Hàm này phục vụ cho Cập Nhật Đóng Tiền Bồi Thường KTXM
        /// </summary>
        /// <param name="DanhBo"></param>
        /// <param name="MaUser"></param>
        /// <returns></returns>
        public DataTable LoadDSCTKTXM(string DanhBo, int MaUser)
        {
            try
            {
                var queryKH = from itemCTKTXM in db.CTKTXMs
                              join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                              where itemCTKTXM.DanhBo == DanhBo && itemCTKTXM.KTXM.MaDon != null && itemCTKTXM.CreateBy == MaUser
                              orderby itemCTKTXM.KTXM.MaDon ascending
                              select new
                              {
                                  itemCTKTXM.MaCTKTXM,
                                  itemCTKTXM.KTXM.MaDon,
                                  itemCTKTXM.DanhBo,
                                  itemCTKTXM.HoTen,
                                  itemCTKTXM.DiaChi,
                                  itemCTKTXM.NoiDungKiemTra,
                                  itemCTKTXM.CreateDate,
                                  CreateBy = itemUser.HoTen,
                              };

                var queryTXL = from itemCTKTXM in db.CTKTXMs
                               join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                               where itemCTKTXM.DanhBo == DanhBo && itemCTKTXM.KTXM.MaDonTXL != null && itemCTKTXM.CreateBy == MaUser
                               orderby itemCTKTXM.KTXM.MaDonTXL ascending
                               select new
                               {
                                   itemCTKTXM.MaCTKTXM,
                                   MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                   itemCTKTXM.DanhBo,
                                   itemCTKTXM.HoTen,
                                   itemCTKTXM.DiaChi,
                                   itemCTKTXM.NoiDungKiemTra,
                                   itemCTKTXM.CreateDate,
                                   CreateBy = itemUser.HoTen,
                               };
                DataTable dt = LINQToDataTable(queryKH);
                dt.Merge(LINQToDataTable(queryTXL));
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXM(string DanhBo)
        {
            try
            {
                var queryKH = from itemCTKTXM in db.CTKTXMs
                              join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                              where itemCTKTXM.DanhBo == DanhBo && itemCTKTXM.KTXM.MaDon != null
                              orderby itemCTKTXM.KTXM.MaDon ascending
                              select new
                              {
                                  itemCTKTXM.MaCTKTXM,
                                  itemCTKTXM.KTXM.MaDon,
                                  itemCTKTXM.DanhBo,
                                  itemCTKTXM.HoTen,
                                  itemCTKTXM.DiaChi,
                                  itemCTKTXM.NoiDungKiemTra,
                                  itemCTKTXM.CreateDate,
                                  CreateBy = itemUser.HoTen,
                              };

                var queryTXL = from itemCTKTXM in db.CTKTXMs
                               join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                               where itemCTKTXM.DanhBo == DanhBo && itemCTKTXM.KTXM.MaDonTXL != null
                               orderby itemCTKTXM.KTXM.MaDonTXL ascending
                               select new
                               {
                                   itemCTKTXM.MaCTKTXM,
                                   MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                   itemCTKTXM.DanhBo,
                                   itemCTKTXM.HoTen,
                                   itemCTKTXM.DiaChi,
                                   itemCTKTXM.NoiDungKiemTra,
                                   itemCTKTXM.CreateDate,
                                   CreateBy = itemUser.HoTen,
                               };
                DataTable dt = LINQToDataTable(queryKH);
                dt.Merge(LINQToDataTable(queryTXL));
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public CTKTXM getCTKTXMbyID(decimal MaCTKTXM)
        {
            try
            {
                return db.CTKTXMs.SingleOrDefault(itemCTKTXM => itemCTKTXM.MaCTKTXM == MaCTKTXM);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public CTKTXM getCTKTXMbyMaDonKHDanhBo(decimal MaDonKH, string DanhBo)
        {
            try
            {
                return db.CTKTXMs.FirstOrDefault(itemCTKTXM => itemCTKTXM.KTXM.MaDon == MaDonKH && itemCTKTXM.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public CTKTXM getCTKTXMbyMaDonTXLDanhBo(decimal MaDonTXL, string DanhBo)
        {
            try
            {
                return db.CTKTXMs.FirstOrDefault(itemCTKTXM => itemCTKTXM.KTXM.MaDonTXL == MaDonTXL && itemCTKTXM.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        
        public bool CheckCTKTXMbyID(decimal MaCTKTXM)
        {
            try
            {
                return db.CTKTXMs.Any(itemCTKTXM => itemCTKTXM.MaCTKTXM == MaCTKTXM);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable LoadDSCTKTXMbyNgayLapBangGia(int MaUser, DateTime NgayLapBangGia)
        {
            try
            {
                var query = from itemCTKTXM in db.CTKTXMs
                            //join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            where itemCTKTXM.NgayLapBangGia.Value.Date == NgayLapBangGia.Date //&& itemCTKTXM.CreateBy == MaUser
                            //orderby itemCTKTXM.KTXM.MaDon ascending
                            select new
                            {
                                LoaiBienBan = itemCTKTXM.HienTrangKiemTra,
                                //itemCTKTXM.DanhBo,
                                //itemCTKTXM.KTXM.MaDon,
                                //itemCTKTXM.KTXM.MaDonTXL,
                                itemCTKTXM.LapBangGia,
                                itemCTKTXM.DongTienBoiThuong,
                                itemCTKTXM.ChuyenLapTBCat,
                                //CreateBy = itemUser.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMbyNgayLapBangGia(int MaUser, DateTime TuNgayLapBangGia, DateTime DenNgayLapBangGia)
        {
            try
            {
                var query = from itemCTKTXM in db.CTKTXMs
                            //join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            where itemCTKTXM.NgayLapBangGia.Value.Date >= TuNgayLapBangGia.Date && itemCTKTXM.NgayLapBangGia.Value.Date <= DenNgayLapBangGia.Date //&& itemCTKTXM.CreateBy == MaUser
                            //orderby itemCTKTXM.KTXM.MaDon ascending
                            select new
                            {
                                LoaiBienBan = itemCTKTXM.HienTrangKiemTra,
                                //itemCTKTXM.DanhBo,
                                //itemCTKTXM.KTXM.MaDon,
                                //itemCTKTXM.KTXM.MaDonTXL,
                                itemCTKTXM.LapBangGia,
                                itemCTKTXM.DongTienBoiThuong,
                                itemCTKTXM.ChuyenLapTBCat,
                                //CreateBy = itemUser.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public int countCTKTXMbyNgayLapBangGia(DateTime NgayLapBangGia)
        {
            try
            {
                return db.CTKTXMs.Count(itemCTKTXM => itemCTKTXM.LapBangGia == true && itemCTKTXM.NgayLapBangGia.Value.Date == NgayLapBangGia.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int countCTKTXMbyNgayLapBangGia(DateTime TuNgayLapBangGia, DateTime DenNgayLapBangGia)
        {
            try
            {
                return db.CTKTXMs.Count(itemCTKTXM => itemCTKTXM.LapBangGia == true && itemCTKTXM.NgayLapBangGia.Value.Date >= TuNgayLapBangGia.Date && itemCTKTXM.NgayLapBangGia.Value.Date <= DenNgayLapBangGia.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int countCTKTXMbyNgayDongTien(DateTime NgayDongTien)
        {
            try
            {
                return db.CTKTXMs.Count(itemCTKTXM => itemCTKTXM.DongTienBoiThuong == true && itemCTKTXM.NgayDongTien.Value.Date == NgayDongTien.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int countCTKTXMbyNgayDongTien(DateTime TuNgayDongTien, DateTime DenNgayDongTien)
        {
            try
            {
                return db.CTKTXMs.Count(itemCTKTXM => itemCTKTXM.DongTienBoiThuong == true && itemCTKTXM.NgayDongTien.Value.Date >= TuNgayDongTien.Date && itemCTKTXM.NgayDongTien.Value.Date <= DenNgayDongTien.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int countCTKTXMbyNgayChuyenLapTBCat(DateTime NgayChuyenLapTBCat)
        {
            try
            {
                return db.CTKTXMs.Count(itemCTKTXM => itemCTKTXM.ChuyenLapTBCat == true && itemCTKTXM.NgayChuyenLapTBCat.Value.Date == NgayChuyenLapTBCat.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int countCTKTXMbyNgayChuyenLapTBCat(DateTime TuNgayChuyenLapTBCat, DateTime DenNgayChuyenLapTBCat)
        {
            try
            {
                return db.CTKTXMs.Count(itemCTKTXM => itemCTKTXM.ChuyenLapTBCat == true && itemCTKTXM.NgayChuyenLapTBCat.Value.Date >= TuNgayChuyenLapTBCat.Date && itemCTKTXM.NgayChuyenLapTBCat.Value.Date <= DenNgayChuyenLapTBCat.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int countCTKTXMbyMaDon(decimal MaDon)
        {
            try
            {
                return db.CTKTXMs.Where(itemCTKTXM => itemCTKTXM.KTXM.MaDon == MaDon).Count();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        #endregion
    }
}

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

        public KTXM Get(string Loai, decimal MaDon)
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

        #region KTXM_ChiTiet (Chi Tiết Kiểm Tra Xác Minh)

        public bool ThemCT(KTXM_ChiTiet ctktxm)
        {
            try
            {
                if (db.KTXM_ChiTiets.Count() > 0)
                {
                    string ID = "MaCTKTXM";
                    string Table = "KTXM_ChiTiet";
                    decimal MaCTKTXM = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    ctktxm.MaCTKTXM = getMaxNextIDTable(MaCTKTXM);
                }
                else
                    ctktxm.MaCTKTXM = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                ctktxm.CreateDate = DateTime.Now;
                ctktxm.CreateBy = CTaiKhoan.MaUser;
                db.KTXM_ChiTiets.InsertOnSubmit(ctktxm);
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

        public bool SuaCT(KTXM_ChiTiet ctktxm)
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

        public bool XoaCT(KTXM_ChiTiet ctktxm)
        {
            try
            {
                decimal MaKTXM = ctktxm.MaKTXM.Value;
                db.KTXM_ChiTiets.DeleteOnSubmit(ctktxm);
                db.SubmitChanges();
                if (db.KTXM_ChiTiets.Any(item => item.MaKTXM == MaKTXM) == false)
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
                    return db.KTXM_ChiTiets.Any(item => item.CreateBy == CreateBy && item.KTXM.MaDon == MaDon && item.DanhBo == DanhBo && item.NgayKTXM == NgayKTXM);
                case "TXL":
                    return db.KTXM_ChiTiets.Any(item => item.CreateBy == CreateBy && item.KTXM.MaDonTXL == MaDon && item.DanhBo == DanhBo && item.NgayKTXM == NgayKTXM);
                case "TBC":
                    return db.KTXM_ChiTiets.Any(item => item.CreateBy == CreateBy && item.KTXM.MaDonTBC == MaDon && item.DanhBo == DanhBo && item.NgayKTXM == NgayKTXM);
                default:
                    return false;
            }
        }

        public bool checkKhongLienHe(string DanhBo)
        {
            return db.KTXM_ChiTiets.Any(item => item.DanhBo == DanhBo && item.KhongLienHe == true);
        }

        public KTXM_ChiTiet GetCT(decimal MaCTKTXM)
        {
            return db.KTXM_ChiTiets.SingleOrDefault(item => item.MaCTKTXM == MaCTKTXM);
        }

        public KTXM_ChiTiet GetCT(string Loai, decimal MaDon, string DanhBo)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.KTXM_ChiTiets.SingleOrDefault(item => item.KTXM.MaDon == MaDon && item.DanhBo == DanhBo);
                case "TXL":
                    return db.KTXM_ChiTiets.SingleOrDefault(item => item.KTXM.MaDonTXL == MaDon && item.DanhBo == DanhBo);
                case "TBC":
                    return db.KTXM_ChiTiets.SingleOrDefault(item => item.KTXM.MaDonTBC == MaDon && item.DanhBo == DanhBo);
                default:
                    return null;
            }

        }

        public bool CheckExist_CT(decimal MaCTKTXM)
        {
            return db.KTXM_ChiTiets.Any(itemCTKTXM => itemCTKTXM.MaCTKTXM == MaCTKTXM);
        }

        public DataTable GetDS(string Loai, DateTime FromNgayKTXM, DateTime ToNgayKTXM)
        {
            switch (Loai)
            {
                case "TKH":
                    var query = from itemCTKTXM in db.KTXM_ChiTiets
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                join itemHTKT in db.KTXM_HienTrangs on itemCTKTXM.HienTrangKiemTra equals itemHTKT.TenHTKT into tableHTKT
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
                                    STT_HTKT = itemtableHTKT.STT,
                                    itemCTKTXM.HienTrangKiemTra,
                                    itemCTKTXM.TieuThuTrungBinh,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from itemCTKTXM in db.KTXM_ChiTiets
                            join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            join itemHTKT in db.KTXM_HienTrangs on itemCTKTXM.HienTrangKiemTra equals itemHTKT.TenHTKT into tableHTKT
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
                    query = from itemCTKTXM in db.KTXM_ChiTiets
                            join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            join itemHTKT in db.KTXM_HienTrangs on itemCTKTXM.HienTrangKiemTra equals itemHTKT.TenHTKT into tableHTKT
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
                   query = from itemCTKTXM in db.KTXM_ChiTiets
                            join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            join itemHTKT in db.KTXM_HienTrangs on itemCTKTXM.HienTrangKiemTra equals itemHTKT.TenHTKT into tableHTKT
                            from itemtableHTKT in tableHTKT.DefaultIfEmpty()
                            where itemCTKTXM.NgayKTXM.Value.Date >= FromNgayKTXM.Date && itemCTKTXM.NgayKTXM.Value.Date <= ToNgayKTXM.Date
                            select new
                            {
                                To="",
                                itemCTKTXM.MaCTKTXM,
                                MaDon = itemCTKTXM.KTXM.MaDon != null ? "TKH" + itemCTKTXM.KTXM.MaDon
                                   : itemCTKTXM.KTXM.MaDonTXL != null ? "TXL" + itemCTKTXM.KTXM.MaDonTXL
                                   : itemCTKTXM.KTXM.MaDonTBC != null ? "TBC" + itemCTKTXM.KTXM.MaDonTBC : null,
                                TenLD = itemCTKTXM.KTXM.MaDon != null ? itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD
                                    : itemCTKTXM.KTXM.MaDonTXL != null ? itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD
                                    : itemCTKTXM.KTXM.MaDonTBC != null ? itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD : null,
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
            }
        }

        public DataTable GetDS(string Loai, int CreateBy, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    var query = from itemCTKTXM in db.KTXM_ChiTiets
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
                    query = from itemCTKTXM in db.KTXM_ChiTiets
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
                    query = from itemCTKTXM in db.KTXM_ChiTiets
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
                    var query = from itemCTKTXM in db.KTXM_ChiTiets
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
                    query = from itemCTKTXM in db.KTXM_ChiTiets
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
                    query = from itemCTKTXM in db.KTXM_ChiTiets
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

        public DataTable GetDS(string Loai, decimal FromMaDon, decimal ToMaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    var query = from itemCTKTXM in db.KTXM_ChiTiets
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where (((itemCTKTXM.KTXM.MaDon.ToString().Substring(itemCTKTXM.KTXM.MaDon.ToString().Length - 2, 2) == FromMaDon.ToString().Substring(FromMaDon.ToString().Length - 2, 2)
                                    && itemCTKTXM.KTXM.MaDon.ToString().Substring(itemCTKTXM.KTXM.MaDon.ToString().Length - 2, 2) == ToMaDon.ToString().Substring(ToMaDon.ToString().Length - 2, 2))
                                    && (itemCTKTXM.KTXM.MaDon >= FromMaDon && itemCTKTXM.KTXM.MaDon <= ToMaDon)))
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
                    query = from itemCTKTXM in db.KTXM_ChiTiets
                            join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            where (((itemCTKTXM.KTXM.MaDonTXL.ToString().Substring(itemCTKTXM.KTXM.MaDonTXL.ToString().Length - 2, 2) == FromMaDon.ToString().Substring(FromMaDon.ToString().Length - 2, 2)
                            && itemCTKTXM.KTXM.MaDonTXL.ToString().Substring(itemCTKTXM.KTXM.MaDonTXL.ToString().Length - 2, 2) == ToMaDon.ToString().Substring(ToMaDon.ToString().Length - 2, 2))
                            && (itemCTKTXM.KTXM.MaDonTXL >= FromMaDon && itemCTKTXM.KTXM.MaDonTXL <= ToMaDon)))
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
                    query = from itemCTKTXM in db.KTXM_ChiTiets
                            join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                            where (((itemCTKTXM.KTXM.MaDonTBC.ToString().Substring(itemCTKTXM.KTXM.MaDonTBC.ToString().Length - 2, 2) == FromMaDon.ToString().Substring(FromMaDon.ToString().Length - 2, 2)
                            && itemCTKTXM.KTXM.MaDonTBC.ToString().Substring(itemCTKTXM.KTXM.MaDonTBC.ToString().Length - 2, 2) == ToMaDon.ToString().Substring(ToMaDon.ToString().Length - 2, 2))
                            && (itemCTKTXM.KTXM.MaDonTBC >= FromMaDon && itemCTKTXM.KTXM.MaDonTBC <= ToMaDon)))
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
            var query = from itemCTKTXM in db.KTXM_ChiTiets
                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                        where itemCTKTXM.DanhBo == DanhBo
                        select new
                        {
                            MaDon = itemCTKTXM.KTXM.MaDonMoi != null ? itemCTKTXM.KTXM.MaDonMoi.Value.ToString()
                                    : itemCTKTXM.KTXM.MaDon != null ? "TKH" + itemCTKTXM.KTXM.MaDon
                                    : itemCTKTXM.KTXM.MaDonTXL != null ? "TXL" + itemCTKTXM.KTXM.MaDonTXL
                                    : itemCTKTXM.KTXM.MaDonTBC != null ? "TBC" + itemCTKTXM.KTXM.MaDonTBC : null,
                            itemCTKTXM.MaCTKTXM,
                            TenLD = itemCTKTXM.KTXM.MaDon != null ? itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD
                                    : itemCTKTXM.KTXM.MaDonTXL != null ? itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD
                                    : itemCTKTXM.KTXM.MaDonTBC != null ? itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD : null,
                            itemCTKTXM.DanhBo,
                            itemCTKTXM.HoTen,
                            itemCTKTXM.DiaChi,
                            itemCTKTXM.NgayKTXM,
                            itemCTKTXM.NoiDungKiemTra,
                            CreateBy = itemUser.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSByDanhBo(int CreateBy, string DanhBo)
        {
            var query = from itemCTKTXM in db.KTXM_ChiTiets
                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                        where itemCTKTXM.CreateBy == CreateBy && itemCTKTXM.DanhBo == DanhBo
                        select new
                        {
                            MaDon = itemCTKTXM.KTXM.MaDon != null ? "TKH" + itemCTKTXM.KTXM.MaDon
                                    : itemCTKTXM.KTXM.MaDonTXL != null ? "TXL" + itemCTKTXM.KTXM.MaDonTXL
                                    : itemCTKTXM.KTXM.MaDonTBC != null ? "TBC" + itemCTKTXM.KTXM.MaDonTBC : null,
                            itemCTKTXM.MaCTKTXM,
                            TenLD = itemCTKTXM.KTXM.MaDon != null ? itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD
                                    : itemCTKTXM.KTXM.MaDonTXL != null ? itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD
                                    : itemCTKTXM.KTXM.MaDonTBC != null ? itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD : null,
                            itemCTKTXM.DanhBo,
                            itemCTKTXM.HoTen,
                            itemCTKTXM.DiaChi,
                            itemCTKTXM.NgayKTXM,
                            itemCTKTXM.NoiDungKiemTra,
                            CreateBy = itemUser.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSBySoCongVan(int CreateBy, string SoCongVan)
        {
            var query = from itemCTKTXM in db.KTXM_ChiTiets
                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                        where itemCTKTXM.CreateBy == CreateBy && itemCTKTXM.KTXM.DonKH.SoCongVan.Contains(SoCongVan)
                        select new
                        {
                            MaDon = itemCTKTXM.KTXM.MaDon != null ? "TKH" + itemCTKTXM.KTXM.MaDon
                                       : itemCTKTXM.KTXM.MaDonTXL != null ? "TXL" + itemCTKTXM.KTXM.MaDonTXL
                                       : itemCTKTXM.KTXM.MaDonTBC != null ? "TBC" + itemCTKTXM.KTXM.MaDonTBC : null,
                            itemCTKTXM.MaCTKTXM,
                            TenLD = itemCTKTXM.KTXM.MaDon != null ? itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD
                                    : itemCTKTXM.KTXM.MaDonTXL != null ? itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD
                                    : itemCTKTXM.KTXM.MaDonTBC != null ? itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD : null,
                            itemCTKTXM.DanhBo,
                            itemCTKTXM.HoTen,
                            itemCTKTXM.DiaChi,
                            itemCTKTXM.NgayKTXM,
                            itemCTKTXM.NoiDungKiemTra,
                            CreateBy = itemUser.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSBySoCongVan(string SoCongVan)
        {
            var query = from itemCTKTXM in db.KTXM_ChiTiets
                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                        where itemCTKTXM.KTXM.DonKH.SoCongVan.Contains(SoCongVan)
                        select new
                        {
                            MaDon = itemCTKTXM.KTXM.MaDon != null ? "TKH" + itemCTKTXM.KTXM.MaDon
                                    : itemCTKTXM.KTXM.MaDonTXL != null ? "TXL" + itemCTKTXM.KTXM.MaDonTXL
                                    : itemCTKTXM.KTXM.MaDonTBC != null ? "TBC" + itemCTKTXM.KTXM.MaDonTBC : null,
                            itemCTKTXM.MaCTKTXM,
                            TenLD = itemCTKTXM.KTXM.MaDon != null ? itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD
                                    : itemCTKTXM.KTXM.MaDonTXL != null ? itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD
                                    : itemCTKTXM.KTXM.MaDonTBC != null ? itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD : null,
                            itemCTKTXM.DanhBo,
                            itemCTKTXM.HoTen,
                            itemCTKTXM.DiaChi,
                            itemCTKTXM.NgayKTXM,
                            itemCTKTXM.NoiDungKiemTra,
                            CreateBy = itemUser.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(int CreateBy, DateTime FromNgayKTXM, DateTime ToNgayKTXM)
        {
            var query = from itemCTKTXM in db.KTXM_ChiTiets
                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                        where itemCTKTXM.CreateBy == CreateBy
                        && itemCTKTXM.NgayKTXM.Value.Date >= FromNgayKTXM.Date && itemCTKTXM.NgayKTXM.Value.Date <= ToNgayKTXM.Date
                        select new
                        {
                            MaDon = itemCTKTXM.KTXM.MaDonMoi != null ? ""+itemCTKTXM.KTXM.MaDonMoi
                                    : itemCTKTXM.KTXM.MaDon != null ? "TKH" + itemCTKTXM.KTXM.MaDon
                                    : itemCTKTXM.KTXM.MaDonTXL != null ? "TXL" + itemCTKTXM.KTXM.MaDonTXL
                                    : itemCTKTXM.KTXM.MaDonTBC != null ? "TBC" + itemCTKTXM.KTXM.MaDonTBC : null,
                            itemCTKTXM.MaCTKTXM,
                            TenLD = itemCTKTXM.KTXM.MaDonMoi != null ? ""
                                    :itemCTKTXM.KTXM.MaDon != null ? itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD
                                    : itemCTKTXM.KTXM.MaDonTXL != null ? itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD
                                    : itemCTKTXM.KTXM.MaDonTBC != null ? itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD : null,
                            itemCTKTXM.DanhBo,
                            itemCTKTXM.HoTen,
                            itemCTKTXM.DiaChi,
                            itemCTKTXM.NgayKTXM,
                            itemCTKTXM.NoiDungKiemTra,
                            CreateBy = itemUser.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromNgayKTXM, DateTime ToNgayKTXM)
        {
            var query = from itemCTKTXM in db.KTXM_ChiTiets
                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                        join itemHTKT in db.KTXM_HienTrangs on itemCTKTXM.HienTrangKiemTra equals itemHTKT.TenHTKT into tableHTKT
                        from itemtableHTKT in tableHTKT.DefaultIfEmpty()
                        where itemCTKTXM.NgayKTXM.Value.Date >= FromNgayKTXM.Date && itemCTKTXM.NgayKTXM.Value.Date <= ToNgayKTXM.Date
                        select new
                        {
                            To = itemCTKTXM.KTXM.MaDon != null ? "TỔ KHÁCH HÀNG" + itemCTKTXM.KTXM.MaDon
                                    : itemCTKTXM.KTXM.MaDonTXL != null ? "TỔ XỬ LÝ" + itemCTKTXM.KTXM.MaDonTXL
                                    : itemCTKTXM.KTXM.MaDonTBC != null ? "TỔ BẤM CHÌ" + itemCTKTXM.KTXM.MaDonTBC : null,
                            MaDon = itemCTKTXM.KTXM.MaDon != null ? "TKH" + itemCTKTXM.KTXM.MaDon
                                    : itemCTKTXM.KTXM.MaDonTXL != null ? "TXL" + itemCTKTXM.KTXM.MaDonTXL
                                    : itemCTKTXM.KTXM.MaDonTBC != null ? "TBC" + itemCTKTXM.KTXM.MaDonTBC : null,
                            itemCTKTXM.MaCTKTXM,
                            TenLD = itemCTKTXM.KTXM.MaDon != null ? itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD
                                    : itemCTKTXM.KTXM.MaDonTXL != null ? itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD
                                    : itemCTKTXM.KTXM.MaDonTBC != null ? itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD : null,
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
        }

        public DataTable GetDS_TruyThu(DateTime FromNgayKTXM, DateTime ToNgayKTXM)
        {
            var query = from itemCTKTXM in db.KTXM_ChiTiets
                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                        join itemHTKT in db.KTXM_HienTrangs on itemCTKTXM.HienTrangKiemTra equals itemHTKT.TenHTKT into tableHTKT
                        from itemtableHTKT in tableHTKT.DefaultIfEmpty()
                        where itemCTKTXM.DinhMucMoi != null
                        && itemCTKTXM.NgayKTXM.Value.Date >= FromNgayKTXM.Date && itemCTKTXM.NgayKTXM.Value.Date <= ToNgayKTXM.Date
                        select new
                        {
                            MaDon = itemCTKTXM.KTXM.MaDon != null ? "TKH" + itemCTKTXM.KTXM.MaDon
                                    : itemCTKTXM.KTXM.MaDonTXL != null ? "TXL" + itemCTKTXM.KTXM.MaDonTXL
                                    : itemCTKTXM.KTXM.MaDonTBC != null ? "TBC" + itemCTKTXM.KTXM.MaDonTBC : null,
                            itemCTKTXM.MaCTKTXM,
                            TenLD = itemCTKTXM.KTXM.MaDon != null ? itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD
                                    : itemCTKTXM.KTXM.MaDonTXL != null ? itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD
                                    : itemCTKTXM.KTXM.MaDonTBC != null ? itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD : null,
                            itemCTKTXM.DanhBo,
                            itemCTKTXM.HoTen,
                            itemCTKTXM.DiaChi,
                            itemCTKTXM.NgayKTXM,
                            itemCTKTXM.DinhMuc,
                            itemCTKTXM.DinhMucMoi,
                            CreateBy = itemUser.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS_BaoThay(DateTime FromNgayKTXM, DateTime ToNgayKTXM)
        {
            var query = from itemCTKTXM in db.KTXM_ChiTiets
                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                        where itemCTKTXM.NgayKTXM.Value.Date >= FromNgayKTXM.Date && itemCTKTXM.NgayKTXM.Value.Date <= ToNgayKTXM.Date && itemCTKTXM.NoiDungBaoThay!=null
                        select new
                        {
                            itemCTKTXM.MaCTKTXM,
                            MaDon = itemCTKTXM.KTXM.MaDon != null ? "TKH" + itemCTKTXM.KTXM.MaDon
                               : itemCTKTXM.KTXM.MaDonTXL != null ? "TXL" + itemCTKTXM.KTXM.MaDonTXL
                               : itemCTKTXM.KTXM.MaDonTBC != null ? "TBC" + itemCTKTXM.KTXM.MaDonTBC : null,
                            TenLD = itemCTKTXM.KTXM.MaDon != null ? itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD
                                : itemCTKTXM.KTXM.MaDonTXL != null ? itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD
                                : itemCTKTXM.KTXM.MaDonTBC != null ? itemCTKTXM.KTXM.DonTBC.LoaiDonTBC.TenLD : null,
                            itemCTKTXM.DanhBo,
                            itemCTKTXM.HoTen,
                            itemCTKTXM.DiaChi,
                            itemCTKTXM.NgayKTXM,
                            itemCTKTXM.NoiDungKiemTra,
                            CreateBy = itemUser.HoTen,
                            itemCTKTXM.NoiDungBaoThay,
                        };
            return LINQToDataTable(query);
        }

        public int CountXuLySauBienBan(string TenTo, DateTime FromNgayKTXM, DateTime ToNgayKTXM, bool LapBangGia, bool DongTienBoiThuong, bool ChuyenLapTBCat, bool DutChiGoc, bool MoNuoc)
        {
            string sql = "select COUNT(MaCTKTXM) from KTXM ktxm,KTXM_ChiTiet ctktxm where ktxm.MaKTXM=ctktxm.MaKTXM and CAST(NgayKTXM as date)>='" + FromNgayKTXM.ToString("yyyyMMdd") + "' and CAST(NgayKTXM as date)<='" + ToNgayKTXM.ToString("yyyyMMdd") + "'";
            switch (TenTo)
            {
                case "TKH":
                    sql += " and MaDon is not null";
                    break;
                case "TXL":
                    sql += " and MaDonTXL is not null";
                    break;
                case "TBC":
                    sql += " and MaDonTBC is not null";
                    break;
                default:
                    break;
            }
            if(LapBangGia==true)
                sql += " and LapBangGia=1";
            if (DongTienBoiThuong == true)
                sql += " and DongTienBoiThuong=1";
            if (ChuyenLapTBCat == true)
                sql += " and ChuyenLapTBCat=1";
            if (DutChiGoc == true)
                sql += " and DutChiGoc=1";
            if (MoNuoc == true)
                sql += " and MoNuoc=1";
           
            return (int)ExecuteQuery_ReturnOneValue(sql);
        }

        public DataTable GetDSXuLySauBienBan(string TenTo, DateTime FromNgayKTXM, DateTime ToNgayKTXM, bool LapBangGia, bool DongTienBoiThuong, bool ChuyenLapTBCat, bool DutChiGoc, bool MoNuoc)
        {
            string sql = "select MaDon=case when MaDon is not null then 'TKH'+ CONVERT(varchar(10),MaDon)"
					    + " when MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),MaDonTXL)"
					    + " when MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),MaDonTBC) end"
                        + " ,DanhBo,HoTen,DiaChi,NgayLapBangGia,NgayDongTien,NgayChuyenLapTBCat,SoTien from KTXM ktxm,KTXM_ChiTiet ctktxm where ktxm.MaKTXM=ctktxm.MaKTXM and CAST(NgayKTXM as date)>='" + FromNgayKTXM.ToString("yyyyMMdd") + "' and CAST(NgayKTXM as date)<='" + ToNgayKTXM.ToString("yyyyMMdd") + "'";
            switch (TenTo)
            {
                case "TKH":
                    sql += " and MaDon is not null";
                    break;
                case "TXL":
                    sql += " and MaDonTXL is not null";
                    break;
                case "TBC":
                    sql += " and MaDonTBC is not null";
                    break;
                default:
                    break;
            }
            if (LapBangGia == true)
                sql += " and LapBangGia=1";
            if (DongTienBoiThuong == true)
                sql += " and DongTienBoiThuong=1";
            if (ChuyenLapTBCat == true)
                sql += " and ChuyenLapTBCat=1";
            if (DutChiGoc == true)
                sql += " and DutChiGoc=1";
            if (MoNuoc == true)
                sql += " and MoNuoc=1";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSLapBangGia(string TenTo,string NoiDungXuLy, DateTime FromNgayLapBangGia, DateTime ToNgayLapBangGia)
        {
            string sql = "select MaDon=case when MaDon is not null then 'TKH'+ CONVERT(varchar(10),MaDon)"
                        + " when MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),MaDonTXL)"
                        + " when MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),MaDonTBC) end"
                        + " ,DanhBo,HoTen,DiaChi,NgayLap=NgayLapBangGia,NoiDungXuLy,GhiChuNoiDungXuLy from KTXM ktxm,KTXM_ChiTiet ctktxm"
                        + " where ktxm.MaKTXM=ctktxm.MaKTXM and LapBangGia=1 and NoiDungXuLy like N'%"+NoiDungXuLy+"%'"
                        + " and CAST(NgayLapBangGia as date)>='" + FromNgayLapBangGia.ToString("yyyyMMdd") + "' and CAST(NgayLapBangGia as date)<='" + ToNgayLapBangGia.ToString("yyyyMMdd") + "'";
            switch (TenTo)
            {
                case "TKH":
                    sql += " and MaDon is not null";
                    break;
                case "TXL":
                    sql += " and MaDonTXL is not null";
                    break;
                case "TBC":
                    sql += " and MaDonTBC is not null";
                    break;
                default:
                    break;
            }
            sql += " order by NgayLapBangGia asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSDongTien(string TenTo, string NoiDungXuLy, DateTime FromNgayDongTien, DateTime ToNgayDongTien)
        {
            string sql = "select MaDon=case when MaDon is not null then 'TKH'+ CONVERT(varchar(10),MaDon)"
                        + " when MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),MaDonTXL)"
                        + " when MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),MaDonTBC) end"
                        + " ,DanhBo,HoTen,DiaChi,NgayLap=NgayDongTien,NoiDungXuLy,GhiChuNoiDungXuLy,SoTienDongTien from KTXM ktxm,KTXM_ChiTiet ctktxm"
                        + " where ktxm.MaKTXM=ctktxm.MaKTXM and DongTien=1 and NoiDungXuLy like N'%" + NoiDungXuLy + "%'"
                        + " and CAST(NgayDongTien as date)>='" + FromNgayDongTien.ToString("yyyyMMdd") + "' and CAST(NgayDongTien as date)<='" + ToNgayDongTien.ToString("yyyyMMdd") + "'";
            switch (TenTo)
            {
                case "TKH":
                    sql += " and MaDon is not null";
                    break;
                case "TXL":
                    sql += " and MaDonTXL is not null";
                    break;
                case "TBC":
                    sql += " and MaDonTBC is not null";
                    break;
                default:
                    break;
            }
            sql += " order by NgayDongTien asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSChuyenLapTBCat(string TenTo, string NoiDungXuLy, DateTime FromNgayChuyenLapTBCat, DateTime ToNgayChuyenLapTBCat)
        {
            string sql = "select MaDon=case when MaDon is not null then 'TKH'+ CONVERT(varchar(10),MaDon)"
                        + " when MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),MaDonTXL)"
                        + " when MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),MaDonTBC) end"
                        + " ,DanhBo,HoTen,DiaChi,NgayLap=NgayChuyenLapTBCat,NoiDungXuLy,GhiChuNoiDungXuLy from KTXM ktxm,KTXM_ChiTiet ctktxm"
                        + " where ktxm.MaKTXM=ctktxm.MaKTXM and ChuyenLapTBCat=1 and NoiDungXuLy like N'%" + NoiDungXuLy + "%'"
                        + " and CAST(NgayChuyenLapTBCat as date)>='" + FromNgayChuyenLapTBCat.ToString("yyyyMMdd") + "' and CAST(NgayChuyenLapTBCat as date)<='" + ToNgayChuyenLapTBCat.ToString("yyyyMMdd") + "'";
            switch (TenTo)
            {
                case "TKH":
                    sql += " and MaDon is not null";
                    break;
                case "TXL":
                    sql += " and MaDonTXL is not null";
                    break;
                case "TBC":
                    sql += " and MaDonTBC is not null";
                    break;
                default:
                    break;
            }
            sql += " order by NgayChuyenLapTBCat asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSLapBangGia(string TenTo, string NoiDungXuLy, string SoCongVan, DateTime FromNgayLapBangGia, DateTime ToNgayLapBangGia)
        {
            string sql = "select MaDon=case when MaDon is not null then 'TKH'+ CONVERT(varchar(10),MaDon)"
                        + " when MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),MaDonTXL)"
                        + " when MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),MaDonTBC) end,"
                        + " SoCongVan=case when MaDon is not null then (select top 1 SoCongVan from DonKH where DonKH.MaDon=MaDon)"
                        + " when MaDonTXL is not null then (select top 1 SoCongVan from DonTXL where DonTXL.MaDon=MaDonTXL)"
                        + " when MaDonTBC is not null then (select top 1 SoCongVan from DonTBC where DonTBC.MaDon=MaDonTBC) end"
                        + " ,DanhBo,HoTen,DiaChi,NgayLap=NgayLapBangGia,NoiDungXuLy,GhiChuNoiDungXuLy from KTXM ktxm,KTXM_ChiTiet ctktxm"
                        + " where ktxm.MaKTXM=ctktxm.MaKTXM and LapBangGia=1 and NoiDungXuLy like N'%" + NoiDungXuLy + "%'"
                        + " and N'" + SoCongVan + "'=(case when MaDon is not null then (select top 1 SoCongVan from DonKH where DonKH.MaDon=MaDon)"
                        + " when MaDonTXL is not null then (select top 1 SoCongVan from DonTXL where DonTXL.MaDon=MaDonTXL)"
                        + " when MaDonTBC is not null then (select top 1 SoCongVan from DonTBC where DonTBC.MaDon=MaDonTBC) else '' end)";
                        //+ " and CAST(NgayLapBangGia as date)>='" + FromNgayLapBangGia.ToString("yyyyMMdd") + "' and CAST(NgayLapBangGia as date)<='" + ToNgayLapBangGia.ToString("yyyyMMdd") + "'";
            switch (TenTo)
            {
                case "TKH":
                    sql += " and MaDon is not null";
                    break;
                case "TXL":
                    sql += " and MaDonTXL is not null";
                    break;
                case "TBC":
                    sql += " and MaDonTBC is not null";
                    break;
                default:
                    break;
            }
            sql += " order by NgayLapBangGia asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSDongTien(string TenTo, string NoiDungXuLy, string SoCongVan, DateTime FromNgayDongTien, DateTime ToNgayDongTien)
        {
            string sql = "select MaDon=case when MaDon is not null then 'TKH'+ CONVERT(varchar(10),MaDon)"
                        + " when MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),MaDonTXL)"
                        + " when MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),MaDonTBC) end,"
                        + " SoCongVan=case when MaDon is not null then (select top 1 SoCongVan from DonKH where DonKH.MaDon=MaDon)"
                        + " when MaDonTXL is not null then (select top 1 SoCongVan from DonTXL where DonTXL.MaDon=MaDonTXL)"
                        + " when MaDonTBC is not null then (select top 1 SoCongVan from DonTBC where DonTBC.MaDon=MaDonTBC) end"
                        + " ,DanhBo,HoTen,DiaChi,NgayLap=NgayDongTien,NoiDungXuLy,GhiChuNoiDungXuLy,SoTienDongTien from KTXM ktxm,KTXM_ChiTiet ctktxm"
                        + " where ktxm.MaKTXM=ctktxm.MaKTXM and DongTien=1 and NoiDungXuLy like N'%" + NoiDungXuLy + "%'"
                        + " and N'" + SoCongVan + "'=(case when MaDon is not null then (select top 1 SoCongVan from DonKH where DonKH.MaDon=MaDon)"
                        + " when MaDonTXL is not null then (select top 1 SoCongVan from DonTXL where DonTXL.MaDon=MaDonTXL)"
                        + " when MaDonTBC is not null then (select top 1 SoCongVan from DonTBC where DonTBC.MaDon=MaDonTBC) else '' end)";
                        //+ " and CAST(NgayDongTien as date)>='" + FromNgayDongTien.ToString("yyyyMMdd") + "' and CAST(NgayDongTien as date)<='" + ToNgayDongTien.ToString("yyyyMMdd") + "'";
            switch (TenTo)
            {
                case "TKH":
                    sql += " and MaDon is not null";
                    break;
                case "TXL":
                    sql += " and MaDonTXL is not null";
                    break;
                case "TBC":
                    sql += " and MaDonTBC is not null";
                    break;
                default:
                    break;
            }
            sql += " order by NgayDongTien asc";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSChuyenLapTBCat(string TenTo, string NoiDungXuLy, string SoCongVan, DateTime FromNgayChuyenLapTBCat, DateTime ToNgayChuyenLapTBCat)
        {
            string sql = "select MaDon=case when MaDon is not null then 'TKH'+ CONVERT(varchar(10),MaDon)"
                        + " when MaDonTXL is not null then 'TXL'+CONVERT(varchar(10),MaDonTXL)"
                        + " when MaDonTBC is not null then 'TBC'+CONVERT(varchar(10),MaDonTBC) end,"
                        + " SoCongVan=case when MaDon is not null then (select top 1 SoCongVan from DonKH where DonKH.MaDon=MaDon)"
                        + " when MaDonTXL is not null then (select top 1 SoCongVan from DonTXL where DonTXL.MaDon=MaDonTXL)"
                        + " when MaDonTBC is not null then (select top 1 SoCongVan from DonTBC where DonTBC.MaDon=MaDonTBC) end"
                        + " ,DanhBo,HoTen,DiaChi,NgayLap=NgayChuyenLapTBCat,NoiDungXuLy,GhiChuNoiDungXuLy from KTXM ktxm,KTXM_ChiTiet ctktxm"
                        + " where ktxm.MaKTXM=ctktxm.MaKTXM and ChuyenLapTBCat=1 and NoiDungXuLy like N'%" + NoiDungXuLy + "%'"
                        + " and N'" + SoCongVan + "'=(case when MaDon is not null then (select top 1 SoCongVan from DonKH where DonKH.MaDon=MaDon)"
                        + " when MaDonTXL is not null then (select top 1 SoCongVan from DonTXL where DonTXL.MaDon=MaDonTXL)"
                        + " when MaDonTBC is not null then (select top 1 SoCongVan from DonTBC where DonTBC.MaDon=MaDonTBC) else '' end)";
                        //+ " and CAST(NgayChuyenLapTBCat as date)>='" + FromNgayChuyenLapTBCat.ToString("yyyyMMdd") + "' and CAST(NgayChuyenLapTBCat as date)<='" + ToNgayChuyenLapTBCat.ToString("yyyyMMdd") + "'";
            switch (TenTo)
            {
                case "TKH":
                    sql += " and MaDon is not null";
                    break;
                case "TXL":
                    sql += " and MaDonTXL is not null";
                    break;
                case "TBC":
                    sql += " and MaDonTBC is not null";
                    break;
                default:
                    break;
            }
            sql += " order by NgayChuyenLapTBCat asc";
            return ExecuteQuery_DataTable(sql);
        }

        public int CountLapBangGia(string TenTo, DateTime FromNgayLapBangGia, DateTime ToNgayLapBangGia)
        {
            string sql = "select COUNT(MaCTKTXM) from KTXM ktxm,KTXM_ChiTiet ctktxm where ktxm.MaKTXM=ctktxm.MaKTXM and LapBangGia=1"
                        + " and CAST(NgayLapBangGia as date)>='" + FromNgayLapBangGia.ToString("yyyyMMdd") + "' and CAST(NgayLapBangGia as date)<='" + ToNgayLapBangGia.ToString("yyyyMMdd") + "'";
            switch (TenTo)
            {
                case "TKH":
                    sql += " and MaDon is not null";
                    break;
                case "TXL":
                    sql += " and MaDonTXL is not null";
                    break;
                case "TBC":
                    sql += " and MaDonTBC is not null";
                    break;
                default:
                    break;
            }
            return (int)ExecuteQuery_ReturnOneValue(sql);
        }

        public int CountDongTien(string TenTo, DateTime FromNgayDongTien, DateTime ToNgayDongTien)
        {
            string sql = "select COUNT(MaCTKTXM) from KTXM ktxm,KTXM_ChiTiet ctktxm where ktxm.MaKTXM=ctktxm.MaKTXM and DongTien=1"
                        + " and CAST(NgayDongTien as date)>='" + FromNgayDongTien.ToString("yyyyMMdd") + "' and CAST(NgayDongTien as date)<='" + ToNgayDongTien.ToString("yyyyMMdd") + "'";
            switch (TenTo)
            {
                case "TKH":
                    sql += " and MaDon is not null";
                    break;
                case "TXL":
                    sql += " and MaDonTXL is not null";
                    break;
                case "TBC":
                    sql += " and MaDonTBC is not null";
                    break;
                default:
                    break;
            }
            return (int)ExecuteQuery_ReturnOneValue(sql);
        }

        public int CountChuyenLapTBCat(string TenTo, DateTime FromNgayChuyenLapTBCat, DateTime ToNgayChuyenLapTBCat)
        {
            string sql = "select COUNT(MaCTKTXM) from KTXM ktxm,KTXM_ChiTiet ctktxm where ktxm.MaKTXM=ctktxm.MaKTXM and ChuyenLapTBCat=1"
                        + " and CAST(NgayChuyenLapTBCat as date)>='" + FromNgayChuyenLapTBCat.ToString("yyyyMMdd") + "' and CAST(NgayChuyenLapTBCat as date)<='" + ToNgayChuyenLapTBCat.ToString("yyyyMMdd") + "'";
            switch (TenTo)
            {
                case "TKH":
                    sql += " and MaDon is not null";
                    break;
                case "TXL":
                    sql += " and MaDonTXL is not null";
                    break;
                case "TBC":
                    sql += " and MaDonTBC is not null";
                    break;
                default:
                    break;
            }
            return (int)ExecuteQuery_ReturnOneValue(sql);
        }

        public DataTable GetGhiChuNoiDungXuLy()
        {
            return LINQToDataTable(db.KTXM_ChiTiets.Select(item => new { item.GhiChuNoiDungXuLy }).ToList().Distinct());
        }

        #endregion

        //MaDonMoi

        public bool checkExist(int MaDon)
        {
            return db.KTXMs.Any(item => item.MaDonMoi == MaDon);
        }

        public bool checkExist_ChiTiet(int CreateBy, int MaDon, string DanhBo, DateTime NgayKTXM)
        {
            return db.KTXM_ChiTiets.Any(item => item.CreateBy == CreateBy && item.KTXM.MaDonMoi == MaDon && item.DanhBo == DanhBo && item.NgayKTXM == NgayKTXM);
        }

        public KTXM get(int MaDon)
        {
                    return db.KTXMs.SingleOrDefault(item => item.MaDonMoi == MaDon);
        }

        public KTXM_ChiTiet get_ChiTiet(int MaDon, string DanhBo)
        {
                    return db.KTXM_ChiTiets.SingleOrDefault(item => item.KTXM.MaDonMoi == MaDon && item.DanhBo == DanhBo);
        }

        public DataTable getDS(int MaDon)
        {
            var query = from itemCTKTXM in db.KTXM_ChiTiets
                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                        where itemCTKTXM.KTXM.MaDonMoi == MaDon
                        select new
                        {
                            itemCTKTXM.MaCTKTXM,
                            MaDon = itemCTKTXM.KTXM.MaDonMoi,
                            itemCTKTXM.STT,
                            itemCTKTXM.DanhBo,
                            itemCTKTXM.HoTen,
                            itemCTKTXM.DiaChi,
                            itemCTKTXM.NgayKTXM,
                            itemCTKTXM.NoiDungKiemTra,
                            CreateBy = itemUser.HoTen,
                        };
            return LINQToDataTable(query);
        }

        
    }
}

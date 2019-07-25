using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.BamChi
{
    class CBamChi : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng BamChi & BamChi_ChiTiet

        #region BamChi (Bấm Chì)

        public bool Them(LinQ.BamChi bamchi)
        {
            try
            {
                if (db.BamChis.Count() > 0)
                {
                    string ID = "MaBC";
                    string Table = "BamChi";
                    decimal MaBC = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaBC = db.BamChis.Max(itemBamChi => itemBamChi.MaBC);
                    bamchi.MaBC = getMaxNextIDTable(MaBC);
                }
                else
                    bamchi.MaBC = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                bamchi.CreateDate = DateTime.Now;
                bamchi.CreateBy = CTaiKhoan.MaUser;
                db.BamChis.InsertOnSubmit(bamchi);
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

        public bool Sua(LinQ.BamChi bamchi)
        {
            try
            {
                bamchi.ModifyDate = DateTime.Now;
                bamchi.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa BamChi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool Xoa(LinQ.BamChi bamchi)
        {
            try
            {
                db.BamChis.DeleteOnSubmit(bamchi);
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa BamChi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool CheckExist_BamChi(string TenTo, decimal MaDon)
        {
            switch (TenTo)
            {
                case "TKH":
                    return db.BamChis.Any(item => item.MaDon == MaDon);
                case "TXL":
                    return db.BamChis.Any(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.BamChis.Any(item => item.MaDonTBC == MaDon);
                default:
                    return false;
            }
        }

        public LinQ.BamChi Get(decimal MaBC)
        {
            try
            {
                return db.BamChis.SingleOrDefault(itemBamChi => itemBamChi.MaBC == MaBC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public LinQ.BamChi Get(string TenTo, decimal MaDon)
        {
            switch (TenTo)
            {
                case "TKH":
                    return db.BamChis.FirstOrDefault(item => item.MaDon == MaDon);
                case "TXL":
                    return db.BamChis.FirstOrDefault(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.BamChis.FirstOrDefault(item => item.MaDonTBC == MaDon);
                default:
                    return null;
            }
        }

        #endregion

        #region BamChi_ChiTiet (Chi Tiết Bấm Chì)

        public bool ThemCT(BamChi_ChiTiet ctbamchi)
        {
            try
            {
                if (db.BamChi_ChiTiets.Count() > 0)
                {
                    string ID = "MaCTBC";
                    string Table = "BamChi_ChiTiet";
                    decimal MaCTBC = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaCTBC = db.BamChi_ChiTiets.Max(itemCTBamChi => itemCTBamChi.MaCTBC);
                    ctbamchi.MaCTBC = getMaxNextIDTable(MaCTBC);
                }
                else
                    ctbamchi.MaCTBC = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                ctbamchi.CreateDate = DateTime.Now;
                ctbamchi.CreateBy = CTaiKhoan.MaUser;
                db.BamChi_ChiTiets.InsertOnSubmit(ctbamchi);
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

        public bool SuaCT(BamChi_ChiTiet ctbamchi)
        {
            try
            {
                ctbamchi.ModifyDate = DateTime.Now;
                ctbamchi.ModifyBy = CTaiKhoan.MaUser;
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

        public bool XoaCT(BamChi_ChiTiet ctbamchi)
        {
            try
            {
                decimal MaBC = ctbamchi.MaBC.Value;
                db.BamChi_ChiTiets.DeleteOnSubmit(ctbamchi);
                db.SubmitChanges();
                if (db.BamChi_ChiTiets.Any(item => item.MaBC == MaBC) == false)
                    db.BamChis.DeleteOnSubmit(db.BamChis.SingleOrDefault(item => item.MaBC == MaBC));
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

        public bool CheckExist_CTBamChi(string TenTo, decimal MaDon, string DanhBo, DateTime NgayBC, string TrangThaiBamChi)
        {
            switch (TenTo)
            {
                case "TKH":
                    return db.BamChi_ChiTiets.Any(item => item.BamChi.MaDon == MaDon && item.DanhBo == DanhBo && item.NgayBC.Value.Date == NgayBC.Date && item.TrangThaiBC == TrangThaiBamChi);
                case "TXL":
                    return db.BamChi_ChiTiets.Any(item => item.BamChi.MaDonTXL == MaDon && item.DanhBo == DanhBo && item.NgayBC.Value.Date == NgayBC.Date && item.TrangThaiBC == TrangThaiBamChi);
                case "TBC":
                    return db.BamChi_ChiTiets.Any(item => item.BamChi.MaDonTBC == MaDon && item.DanhBo == DanhBo && item.NgayBC.Value.Date == NgayBC.Date && item.TrangThaiBC == TrangThaiBamChi);
                default:
                    return false;
            }
        }

        public BamChi_ChiTiet GetCT(decimal MaCTBC)
        {
            try
            {
                return db.BamChi_ChiTiets.SingleOrDefault(itemCTBamChi => itemCTBamChi.MaCTBC == MaCTBC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS(string TenTo, int CreateBy, decimal MaDon)
        {
            switch (TenTo)
            {
                case "ToTB":
                    var query = from itemCTBamChi in db.BamChi_ChiTiets
                                join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                where itemCTBamChi.CreateBy == CreateBy && itemCTBamChi.BamChi.MaDon == MaDon
                                select new
                                {
                                    MaDon = "TKH" + itemCTBamChi.BamChi.MaDon,
                                    itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD,
                                    itemCTBamChi.MaCTBC,
                                    itemCTBamChi.DanhBo,
                                    itemCTBamChi.HoTen,
                                    itemCTBamChi.DiaChi,
                                    itemCTBamChi.HopDong,
                                    itemCTBamChi.NgayBC,
                                    itemCTBamChi.TrangThaiBC,
                                    itemCTBamChi.Hieu,
                                    itemCTBamChi.Co,
                                    itemCTBamChi.ChiSo,
                                    itemCTBamChi.VienChi,
                                    itemCTBamChi.DayChi,
                                    itemCTBamChi.TheoYeuCau,
                                    itemCTBamChi.MaSoBC,
                                    itemCTBamChi.NiemChi,
                                    CreateBy = itemUser.HoTen,
                                };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from itemCTBamChi in db.BamChi_ChiTiets
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.CreateBy == CreateBy && itemCTBamChi.BamChi.MaDonTXL == MaDon
                            select new
                            {
                                MaDon = "TXL" + itemCTBamChi.BamChi.MaDonTXL,
                                itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD,
                                itemCTBamChi.MaCTBC,
                                itemCTBamChi.DanhBo,
                                itemCTBamChi.HoTen,
                                itemCTBamChi.DiaChi,
                                itemCTBamChi.HopDong,
                                itemCTBamChi.NgayBC,
                                itemCTBamChi.TrangThaiBC,
                                itemCTBamChi.Hieu,
                                itemCTBamChi.Co,
                                itemCTBamChi.ChiSo,
                                itemCTBamChi.VienChi,
                                itemCTBamChi.DayChi,
                                itemCTBamChi.TheoYeuCau,
                                itemCTBamChi.MaSoBC,
                                itemCTBamChi.NiemChi,
                                CreateBy = itemUser.HoTen,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from itemCTBamChi in db.BamChi_ChiTiets
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.CreateBy == CreateBy && itemCTBamChi.BamChi.MaDonTBC == MaDon
                            select new
                            {
                                MaDon = "TBC" + itemCTBamChi.BamChi.MaDonTBC,
                                itemCTBamChi.BamChi.DonTBC.LoaiDonTBC.TenLD,
                                itemCTBamChi.MaCTBC,
                                itemCTBamChi.DanhBo,
                                itemCTBamChi.HoTen,
                                itemCTBamChi.DiaChi,
                                itemCTBamChi.HopDong,
                                itemCTBamChi.NgayBC,
                                itemCTBamChi.TrangThaiBC,
                                itemCTBamChi.Hieu,
                                itemCTBamChi.Co,
                                itemCTBamChi.ChiSo,
                                itemCTBamChi.VienChi,
                                itemCTBamChi.DayChi,
                                itemCTBamChi.TheoYeuCau,
                                itemCTBamChi.MaSoBC,
                                itemCTBamChi.NiemChi,
                                CreateBy = itemUser.HoTen,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from itemCTBamChi in db.BamChi_ChiTiets
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.CreateBy == CreateBy && itemCTBamChi.BamChi.MaDonMoi == MaDon
                            select new
                            {
                                MaDon = itemCTBamChi.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTBamChi.BamChi.MaDonMoi).Count() == 1 ? itemCTBamChi.BamChi.MaDonMoi.Value.ToString() : itemCTBamChi.BamChi.MaDonMoi + "." + itemCTBamChi.STT : null,
                                TenLD = itemCTBamChi.BamChi.DonTu.Name_NhomDon,
                                itemCTBamChi.MaCTBC,
                                itemCTBamChi.DanhBo,
                                itemCTBamChi.HoTen,
                                itemCTBamChi.DiaChi,
                                itemCTBamChi.HopDong,
                                itemCTBamChi.NgayBC,
                                itemCTBamChi.TrangThaiBC,
                                itemCTBamChi.Hieu,
                                itemCTBamChi.Co,
                                itemCTBamChi.ChiSo,
                                itemCTBamChi.VienChi,
                                itemCTBamChi.DayChi,
                                itemCTBamChi.TheoYeuCau,
                                itemCTBamChi.MaSoBC,
                                itemCTBamChi.NiemChi,
                                CreateBy = itemUser.HoTen,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS(string TenTo, decimal MaDon)
        {
            switch (TenTo)
            {
                case "ToTB":
                    var query = from itemCTBamChi in db.BamChi_ChiTiets
                                join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                where itemCTBamChi.BamChi.MaDon == MaDon
                                select new
                                {
                                    MaDon = "TKH" + itemCTBamChi.BamChi.MaDon,
                                    itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD,
                                    itemCTBamChi.MaCTBC,
                                    itemCTBamChi.DanhBo,
                                    itemCTBamChi.HoTen,
                                    itemCTBamChi.DiaChi,
                                    itemCTBamChi.HopDong,
                                    itemCTBamChi.NgayBC,
                                    itemCTBamChi.TrangThaiBC,
                                    itemCTBamChi.Hieu,
                                    itemCTBamChi.Co,
                                    itemCTBamChi.ChiSo,
                                    itemCTBamChi.VienChi,
                                    itemCTBamChi.DayChi,
                                    itemCTBamChi.TheoYeuCau,
                                    itemCTBamChi.MaSoBC,
                                    itemCTBamChi.NiemChi,
                                    CreateBy = itemUser.HoTen,
                                };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from itemCTBamChi in db.BamChi_ChiTiets
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.BamChi.MaDonTXL == MaDon
                            select new
                            {
                                MaDon = "TXL" + itemCTBamChi.BamChi.MaDonTXL,
                                itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD,
                                itemCTBamChi.MaCTBC,
                                itemCTBamChi.DanhBo,
                                itemCTBamChi.HoTen,
                                itemCTBamChi.DiaChi,
                                itemCTBamChi.HopDong,
                                itemCTBamChi.NgayBC,
                                itemCTBamChi.TrangThaiBC,
                                itemCTBamChi.Hieu,
                                itemCTBamChi.Co,
                                itemCTBamChi.ChiSo,
                                itemCTBamChi.VienChi,
                                itemCTBamChi.DayChi,
                                itemCTBamChi.TheoYeuCau,
                                itemCTBamChi.MaSoBC,
                                itemCTBamChi.NiemChi,
                                CreateBy = itemUser.HoTen,
                            };
                    return LINQToDataTable(query);
                case "TpBC":
                    query = from itemCTBamChi in db.BamChi_ChiTiets
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.BamChi.MaDonTBC == MaDon
                            select new
                            {
                                MaDon = "TBC" + itemCTBamChi.BamChi.MaDonTBC,
                                itemCTBamChi.BamChi.DonTBC.LoaiDonTBC.TenLD,
                                itemCTBamChi.MaCTBC,
                                itemCTBamChi.DanhBo,
                                itemCTBamChi.HoTen,
                                itemCTBamChi.DiaChi,
                                itemCTBamChi.HopDong,
                                itemCTBamChi.NgayBC,
                                itemCTBamChi.TrangThaiBC,
                                itemCTBamChi.Hieu,
                                itemCTBamChi.Co,
                                itemCTBamChi.ChiSo,
                                itemCTBamChi.VienChi,
                                itemCTBamChi.DayChi,
                                itemCTBamChi.TheoYeuCau,
                                itemCTBamChi.MaSoBC,
                                itemCTBamChi.NiemChi,
                                CreateBy = itemUser.HoTen,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from itemCTBamChi in db.BamChi_ChiTiets
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.BamChi.MaDonMoi == MaDon
                            select new
                            {
                                MaDon = itemCTBamChi.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTBamChi.BamChi.MaDonMoi).Count() == 1 ? itemCTBamChi.BamChi.MaDonMoi.Value.ToString() : itemCTBamChi.BamChi.MaDonMoi + "." + itemCTBamChi.STT:null,
                                TenLD = itemCTBamChi.BamChi.DonTu.Name_NhomDon,
                                itemCTBamChi.MaCTBC,
                                itemCTBamChi.DanhBo,
                                itemCTBamChi.HoTen,
                                itemCTBamChi.DiaChi,
                                itemCTBamChi.HopDong,
                                itemCTBamChi.NgayBC,
                                itemCTBamChi.TrangThaiBC,
                                itemCTBamChi.Hieu,
                                itemCTBamChi.Co,
                                itemCTBamChi.ChiSo,
                                itemCTBamChi.VienChi,
                                itemCTBamChi.DayChi,
                                itemCTBamChi.TheoYeuCau,
                                itemCTBamChi.MaSoBC,
                                itemCTBamChi.NiemChi,
                                CreateBy = itemUser.HoTen,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS(string TenTo, decimal MaDon, string DanhBo)
        {
            switch (TenTo)
            {
                case "ToTB":
                    var query = from itemCTBamChi in db.BamChi_ChiTiets
                                join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                where itemCTBamChi.BamChi.MaDon == MaDon && itemCTBamChi.DanhBo == DanhBo
                                select new
                                {
                                    MaDon = "TKH" + itemCTBamChi.BamChi.MaDon,
                                    itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD,
                                    itemCTBamChi.MaCTBC,
                                    itemCTBamChi.DanhBo,
                                    itemCTBamChi.HoTen,
                                    itemCTBamChi.DiaChi,
                                    itemCTBamChi.HopDong,
                                    itemCTBamChi.NgayBC,
                                    itemCTBamChi.TrangThaiBC,
                                    itemCTBamChi.Hieu,
                                    itemCTBamChi.Co,
                                    itemCTBamChi.ChiSo,
                                    itemCTBamChi.VienChi,
                                    itemCTBamChi.DayChi,
                                    itemCTBamChi.TheoYeuCau,
                                    itemCTBamChi.MaSoBC,
                                    CreateBy = itemUser.HoTen,
                                };
                    return LINQToDataTable(query);
                case "ToTP":
                    query = from itemCTBamChi in db.BamChi_ChiTiets
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.BamChi.MaDonTXL == MaDon && itemCTBamChi.DanhBo == DanhBo
                            select new
                            {
                                MaDon = "TXL" + itemCTBamChi.BamChi.MaDonTXL,
                                itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD,
                                itemCTBamChi.MaCTBC,
                                itemCTBamChi.DanhBo,
                                itemCTBamChi.HoTen,
                                itemCTBamChi.DiaChi,
                                itemCTBamChi.HopDong,
                                itemCTBamChi.NgayBC,
                                itemCTBamChi.TrangThaiBC,
                                itemCTBamChi.Hieu,
                                itemCTBamChi.Co,
                                itemCTBamChi.ChiSo,
                                itemCTBamChi.VienChi,
                                itemCTBamChi.DayChi,
                                itemCTBamChi.TheoYeuCau,
                                itemCTBamChi.MaSoBC,
                                CreateBy = itemUser.HoTen,
                            };
                    return LINQToDataTable(query);
                case "ToBC":
                    query = from itemCTBamChi in db.BamChi_ChiTiets
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.BamChi.MaDonTBC == MaDon && itemCTBamChi.DanhBo == DanhBo
                            select new
                            {
                                MaDon = "TBC" + itemCTBamChi.BamChi.MaDonTBC,
                                itemCTBamChi.BamChi.DonTBC.LoaiDonTBC.TenLD,
                                itemCTBamChi.MaCTBC,
                                itemCTBamChi.DanhBo,
                                itemCTBamChi.HoTen,
                                itemCTBamChi.DiaChi,
                                itemCTBamChi.HopDong,
                                itemCTBamChi.NgayBC,
                                itemCTBamChi.TrangThaiBC,
                                itemCTBamChi.Hieu,
                                itemCTBamChi.Co,
                                itemCTBamChi.ChiSo,
                                itemCTBamChi.VienChi,
                                itemCTBamChi.DayChi,
                                itemCTBamChi.TheoYeuCau,
                                itemCTBamChi.MaSoBC,
                                CreateBy = itemUser.HoTen,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from itemCTBamChi in db.BamChi_ChiTiets
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.BamChi.MaDonMoi == MaDon && itemCTBamChi.DanhBo == DanhBo
                            select new
                            {
                                MaDon = itemCTBamChi.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTBamChi.BamChi.MaDonMoi).Count() == 1 ? itemCTBamChi.BamChi.MaDonMoi.Value.ToString() : itemCTBamChi.BamChi.MaDonMoi + "." + itemCTBamChi.STT:null,
                                TenLD = itemCTBamChi.BamChi.DonTu.Name_NhomDon,
                                itemCTBamChi.MaCTBC,
                                itemCTBamChi.DanhBo,
                                itemCTBamChi.HoTen,
                                itemCTBamChi.DiaChi,
                                itemCTBamChi.HopDong,
                                itemCTBamChi.NgayBC,
                                itemCTBamChi.TrangThaiBC,
                                itemCTBamChi.Hieu,
                                itemCTBamChi.Co,
                                itemCTBamChi.ChiSo,
                                itemCTBamChi.VienChi,
                                itemCTBamChi.DayChi,
                                itemCTBamChi.TheoYeuCau,
                                itemCTBamChi.MaSoBC,
                                CreateBy = itemUser.HoTen,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS(string DanhBo)
        {
            var query = from itemCTBamChi in db.BamChi_ChiTiets
                        join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                        where itemCTBamChi.DanhBo == DanhBo
                        select new
                        {
                            MaDon = itemCTBamChi.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTBamChi.BamChi.MaDonMoi).Count() == 1 ? itemCTBamChi.BamChi.MaDonMoi.Value.ToString() : itemCTBamChi.BamChi.MaDonMoi + "." + itemCTBamChi.STT
                                        : itemCTBamChi.BamChi.MaDon != null ? "TKH" + itemCTBamChi.BamChi.MaDon
                                        : itemCTBamChi.BamChi.MaDonTXL != null ? "TXL" + itemCTBamChi.BamChi.MaDonTXL
                                        : itemCTBamChi.BamChi.MaDonTBC != null ? "TBC" + itemCTBamChi.BamChi.MaDonTBC : null,
                            TenLD = itemCTBamChi.BamChi.MaDonMoi != null ? itemCTBamChi.BamChi.DonTu.Name_NhomDon
                                        : itemCTBamChi.BamChi.MaDon != null ? itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD
                                        : itemCTBamChi.BamChi.MaDonTXL != null ? itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD
                                        : itemCTBamChi.BamChi.MaDonTBC != null ? itemCTBamChi.BamChi.DonTBC.LoaiDonTBC.TenLD : null,
                            itemCTBamChi.MaCTBC,
                            itemCTBamChi.DanhBo,
                            itemCTBamChi.HoTen,
                            itemCTBamChi.DiaChi,
                            itemCTBamChi.HopDong,
                            itemCTBamChi.NgayBC,
                            itemCTBamChi.TrangThaiBC,
                            itemCTBamChi.Hieu,
                            itemCTBamChi.Co,
                            itemCTBamChi.ChiSo,
                            itemCTBamChi.VienChi,
                            itemCTBamChi.DayChi,
                            itemCTBamChi.TheoYeuCau,
                            itemCTBamChi.MaSoBC,
                            itemCTBamChi.NiemChi,
                            CreateBy = itemUser.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS(int CreateBy, string DanhBo)
        {
            var query = from itemCTBamChi in db.BamChi_ChiTiets
                        join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                        where itemCTBamChi.CreateBy == CreateBy && itemCTBamChi.DanhBo == DanhBo
                        select new
                        {
                            MaDon = itemCTBamChi.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTBamChi.BamChi.MaDonMoi).Count() == 1 ? itemCTBamChi.BamChi.MaDonMoi.Value.ToString() : itemCTBamChi.BamChi.MaDonMoi + "." + itemCTBamChi.STT
                                        : itemCTBamChi.BamChi.MaDon != null ? "TKH" + itemCTBamChi.BamChi.MaDon
                                        : itemCTBamChi.BamChi.MaDonTXL != null ? "TXL" + itemCTBamChi.BamChi.MaDonTXL
                                        : itemCTBamChi.BamChi.MaDonTBC != null ? "TBC" + itemCTBamChi.BamChi.MaDonTBC : null,
                            TenLD = itemCTBamChi.BamChi.MaDonMoi != null ? itemCTBamChi.BamChi.DonTu.Name_NhomDon
                                        : itemCTBamChi.BamChi.MaDon != null ? itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD
                                        : itemCTBamChi.BamChi.MaDonTXL != null ? itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD
                                        : itemCTBamChi.BamChi.MaDonTBC != null ? itemCTBamChi.BamChi.DonTBC.LoaiDonTBC.TenLD : null,
                            itemCTBamChi.MaCTBC,
                            itemCTBamChi.DanhBo,
                            itemCTBamChi.HoTen,
                            itemCTBamChi.DiaChi,
                            itemCTBamChi.HopDong,
                            itemCTBamChi.NgayBC,
                            itemCTBamChi.TrangThaiBC,
                            itemCTBamChi.Hieu,
                            itemCTBamChi.Co,
                            itemCTBamChi.ChiSo,
                            itemCTBamChi.VienChi,
                            itemCTBamChi.DayChi,
                            itemCTBamChi.TheoYeuCau,
                            itemCTBamChi.MaSoBC,
                            itemCTBamChi.NiemChi,
                            CreateBy = itemUser.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS(int CreateBy, DateTime FromNgayBC, DateTime ToNgayBC)
        {
            var query = from itemCTBamChi in db.BamChi_ChiTiets
                        join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                        where itemCTBamChi.CreateBy == CreateBy
                        && itemCTBamChi.NgayBC.Value.Date >= FromNgayBC.Date && itemCTBamChi.NgayBC.Value.Date <= ToNgayBC.Date
                        select new
                        {
                            MaDon = itemCTBamChi.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTBamChi.BamChi.MaDonMoi).Count() == 1 ? itemCTBamChi.BamChi.MaDonMoi.Value.ToString() : itemCTBamChi.BamChi.MaDonMoi + "." + itemCTBamChi.STT
                                        : itemCTBamChi.BamChi.MaDon != null ? "TKH" + itemCTBamChi.BamChi.MaDon
                                        : itemCTBamChi.BamChi.MaDonTXL != null ? "TXL" + itemCTBamChi.BamChi.MaDonTXL
                                        : itemCTBamChi.BamChi.MaDonTBC != null ? "TBC" + itemCTBamChi.BamChi.MaDonTBC : null,
                            TenLD = itemCTBamChi.BamChi.MaDonMoi != null ? itemCTBamChi.BamChi.DonTu.Name_NhomDon
                                        : itemCTBamChi.BamChi.MaDon != null ? itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD
                                        : itemCTBamChi.BamChi.MaDonTXL != null ? itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD
                                        : itemCTBamChi.BamChi.MaDonTBC != null ? itemCTBamChi.BamChi.DonTBC.LoaiDonTBC.TenLD : null,
                            itemCTBamChi.MaCTBC,
                            itemCTBamChi.DanhBo,
                            itemCTBamChi.HoTen,
                            itemCTBamChi.DiaChi,
                            itemCTBamChi.HopDong,
                            itemCTBamChi.NgayBC,
                            itemCTBamChi.TrangThaiBC,
                            itemCTBamChi.Hieu,
                            itemCTBamChi.Co,
                            itemCTBamChi.ChiSo,
                            itemCTBamChi.VienChi,
                            itemCTBamChi.DayChi,
                            itemCTBamChi.TheoYeuCau,
                            itemCTBamChi.MaSoBC,
                            itemCTBamChi.NiemChi,
                            CreateBy = itemUser.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS(DateTime FromNgayBC, DateTime ToNgayBC)
        {
            var query = from itemCTBamChi in db.BamChi_ChiTiets
                        join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                        where  itemCTBamChi.NgayBC.Value.Date >= FromNgayBC.Date && itemCTBamChi.NgayBC.Value.Date <= ToNgayBC.Date
                        select new
                        {
                           MaDon = itemCTBamChi.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTBamChi.BamChi.MaDonMoi).Count() == 1 ? itemCTBamChi.BamChi.MaDonMoi.Value.ToString() : itemCTBamChi.BamChi.MaDonMoi + "." + itemCTBamChi.STT
                                        : itemCTBamChi.BamChi.MaDon != null ? "TKH" + itemCTBamChi.BamChi.MaDon
                                        : itemCTBamChi.BamChi.MaDonTXL != null ? "TXL" + itemCTBamChi.BamChi.MaDonTXL
                                        : itemCTBamChi.BamChi.MaDonTBC != null ? "TBC" + itemCTBamChi.BamChi.MaDonTBC : null,
                            TenLD = itemCTBamChi.BamChi.MaDonMoi != null ? itemCTBamChi.BamChi.DonTu.Name_NhomDon+" "+ itemCTBamChi.BamChi.DonTu.Name_NhomDon_ChiTiet
                                        : itemCTBamChi.BamChi.MaDon != null ? itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD
                                        : itemCTBamChi.BamChi.MaDonTXL != null ? itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD
                                        : itemCTBamChi.BamChi.MaDonTBC != null ? itemCTBamChi.BamChi.DonTBC.LoaiDonTBC.TenLD : null,
                            itemCTBamChi.MaCTBC,
                            itemCTBamChi.DanhBo,
                            itemCTBamChi.HoTen,
                            itemCTBamChi.DiaChi,
                            itemCTBamChi.HopDong,
                            itemCTBamChi.NgayBC,
                            itemCTBamChi.TrangThaiBC,
                            itemCTBamChi.Hieu,
                            itemCTBamChi.Co,
                            itemCTBamChi.ChiSo,
                            itemCTBamChi.VienChi,
                            itemCTBamChi.DayChi,
                            itemCTBamChi.TheoYeuCau,
                            itemCTBamChi.MaSoBC,
                            itemCTBamChi.NiemChi,
                            CreateBy = itemUser.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS(string TrangThaiBamChi, DateTime FromNgayBC, DateTime ToNgayBC)
        {
            var query = from itemCTBamChi in db.BamChi_ChiTiets
                        join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                        where itemCTBamChi.TrangThaiBC.Contains(TrangThaiBamChi) && itemCTBamChi.NgayBC.Value.Date >= FromNgayBC.Date && itemCTBamChi.NgayBC.Value.Date <= ToNgayBC.Date
                        select new
                        {
                            MaDon = itemCTBamChi.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTBamChi.BamChi.MaDonMoi).Count() == 1 ? itemCTBamChi.BamChi.MaDonMoi.Value.ToString() : itemCTBamChi.BamChi.MaDonMoi + "." + itemCTBamChi.STT
                                         : itemCTBamChi.BamChi.MaDon != null ? "TKH" + itemCTBamChi.BamChi.MaDon
                                         : itemCTBamChi.BamChi.MaDonTXL != null ? "TXL" + itemCTBamChi.BamChi.MaDonTXL
                                         : itemCTBamChi.BamChi.MaDonTBC != null ? "TBC" + itemCTBamChi.BamChi.MaDonTBC : null,
                            TenLD = itemCTBamChi.BamChi.MaDonMoi != null ? itemCTBamChi.BamChi.DonTu.Name_NhomDon
                                        : itemCTBamChi.BamChi.MaDon != null ? itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD
                                        : itemCTBamChi.BamChi.MaDonTXL != null ? itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD
                                        : itemCTBamChi.BamChi.MaDonTBC != null ? itemCTBamChi.BamChi.DonTBC.LoaiDonTBC.TenLD : null,
                            itemCTBamChi.MaCTBC,
                            itemCTBamChi.DanhBo,
                            itemCTBamChi.HoTen,
                            itemCTBamChi.DiaChi,
                            itemCTBamChi.HopDong,
                            itemCTBamChi.NgayBC,
                            itemCTBamChi.TrangThaiBC,
                            itemCTBamChi.Hieu,
                            itemCTBamChi.Co,
                            itemCTBamChi.ChiSo,
                            itemCTBamChi.VienChi,
                            itemCTBamChi.DayChi,
                            itemCTBamChi.TheoYeuCau,
                            itemCTBamChi.MaSoBC,
                            itemCTBamChi.NiemChi,
                            CreateBy = itemUser.HoTen,
                        };
            return LINQToDataTable(query);
        }

        #endregion

        //MaDonMoi

        public bool checkExist(int MaDon)
        {
            return db.BamChis.Any(item => item.MaDonMoi == MaDon);
        }

        public bool checkExist_ChiTiet(int MaDon, string DanhBo, DateTime NgayBC, string TrangThaiBamChi)
        {
            return db.BamChi_ChiTiets.Any(item => item.BamChi.MaDonMoi == MaDon && item.DanhBo == DanhBo && item.NgayBC.Value.Date == NgayBC.Date && item.TrangThaiBC == TrangThaiBamChi);
        }

        public LinQ.BamChi get(int MaDon)
        {
            return db.BamChis.FirstOrDefault(item => item.MaDonMoi == MaDon);
        }

        //public DataTable getDS(int MaDon)
        //{
        //    var query = from itemCTBamChi in db.BamChi_ChiTiets
        //                join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
        //                where itemCTBamChi.BamChi.MaDonMoi == MaDon
        //                select new
        //                {
        //                    itemCTBamChi.MaCTBC,
        //                    MaDon = itemCTBamChi.BamChi.MaDonMoi,
        //                    itemCTBamChi.STT,
        //                    itemCTBamChi.DanhBo,
        //                    itemCTBamChi.HoTen,
        //                    itemCTBamChi.DiaChi,
        //                    itemCTBamChi.HopDong,
        //                    itemCTBamChi.NgayBC,
        //                    itemCTBamChi.TrangThaiBC,
        //                    itemCTBamChi.Hieu,
        //                    itemCTBamChi.Co,
        //                    itemCTBamChi.ChiSo,
        //                    itemCTBamChi.VienChi,
        //                    itemCTBamChi.DayChi,
        //                    itemCTBamChi.TheoYeuCau,
        //                    itemCTBamChi.MaSoBC,
        //                    CreateBy = itemUser.HoTen,
        //                };
        //    return LINQToDataTable(query);
        //}

        //public DataTable getDS(int MaDon, string DanhBo)
        //{
        //    var query = from itemCTBamChi in db.BamChi_ChiTiets
        //                join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
        //                where itemCTBamChi.BamChi.MaDonMoi == MaDon && itemCTBamChi.DanhBo == DanhBo
        //                select new
        //                {
        //                    itemCTBamChi.MaCTBC,
        //                    MaDon = itemCTBamChi.BamChi.MaDonMoi,
        //                    itemCTBamChi.STT,
        //                    itemCTBamChi.DanhBo,
        //                    itemCTBamChi.HoTen,
        //                    itemCTBamChi.DiaChi,
        //                    itemCTBamChi.HopDong,
        //                    itemCTBamChi.NgayBC,
        //                    itemCTBamChi.TrangThaiBC,
        //                    itemCTBamChi.Hieu,
        //                    itemCTBamChi.Co,
        //                    itemCTBamChi.ChiSo,
        //                    itemCTBamChi.VienChi,
        //                    itemCTBamChi.DayChi,
        //                    itemCTBamChi.TheoYeuCau,
        //                    itemCTBamChi.MaSoBC,
        //                    CreateBy = itemUser.HoTen,
        //                };
        //    return LINQToDataTable(query);
        //}


        #region Hình

        public bool Them_Hinh(BamChi_ChiTiet_Hinh en)
        {
            try
            {
                if (db.BamChi_ChiTiet_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = db.BamChi_ChiTiet_Hinhs.Max(item => item.ID) + 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.BamChi_ChiTiet_Hinhs.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_Hinh(BamChi_ChiTiet_Hinh en)
        {
            try
            {
                db.BamChi_ChiTiet_Hinhs.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public BamChi_ChiTiet_Hinh get_Hinh(int ID)
        {
            return db.BamChi_ChiTiet_Hinhs.SingleOrDefault(item => item.ID == ID);
        }

        #endregion
    }
}

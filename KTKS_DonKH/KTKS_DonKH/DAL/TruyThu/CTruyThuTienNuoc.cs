using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Windows.Forms;
using System.Data;

namespace KTKS_DonKH.DAL.TruyThu
{
    class CTruyThuTienNuoc : CDAL
    {
        //int SoTien1m3 = 19345;
        int SoTien1m3 = 19435;

        #region TruyThuTienNuoc_ChiTiet

        public bool Them(TruyThuTienNuoc_ChiTiet tttn)
        {
            try
            {
                if (db.TruyThuTienNuoc_ChiTiets.Count() > 0)
                {
                    string ID = "MaTTTN";
                    string Table = "TruyThuTienNuoc_ChiTiet";
                    decimal MaTTTN = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    tttn.MaTTTN = getMaxNextIDTable(MaTTTN);
                }
                else
                    tttn.MaTTTN = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                tttn.SoTien1m3 = SoTien1m3;//lưu lại số tiền trong quá khứ do có thể thay đổi trong tương lai
                tttn.CreateDate = DateTime.Now;
                tttn.CreateBy = CTaiKhoan.MaUser;
                db.TruyThuTienNuoc_ChiTiets.InsertOnSubmit(tttn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(TruyThuTienNuoc_ChiTiet tttn)
        {
            try
            {
                tttn.ModifyDate = DateTime.Now;
                tttn.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(TruyThuTienNuoc_ChiTiet tttn)
        {
            try
            {
                db.TruyThuTienNuoc_HoaDons.DeleteAllOnSubmit(tttn.TruyThuTienNuoc_HoaDons.ToList());
                db.TruyThuTienNuoc_ThanhToans.DeleteAllOnSubmit(tttn.TruyThuTienNuoc_ThanhToans.ToList());
                db.TruyThuTienNuoc_ThuMois.DeleteAllOnSubmit(tttn.TruyThuTienNuoc_ThuMois.ToList());
                db.TruyThuTienNuoc_ChiTiets.DeleteOnSubmit(tttn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(decimal MaTTTN)
        {
            return db.TruyThuTienNuoc_ChiTiets.Any(item => item.MaTTTN == MaTTTN);
        }

        public bool CheckExist(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.TruyThuTienNuoc_ChiTiets.Any(item => item.TruyThuTienNuoc_Tong.MaDon == MaDon);
                case "TXL":
                    return db.TruyThuTienNuoc_ChiTiets.Any(item => item.TruyThuTienNuoc_Tong.MaDonTXL == MaDon);
                case "TBC":
                    return db.TruyThuTienNuoc_ChiTiets.Any(item => item.TruyThuTienNuoc_Tong.MaDonTBC == MaDon);
                default:
                    return false;
            }
        }

        public bool CheckExist(string Loai, decimal MaDon, string DanhBo)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.TruyThuTienNuoc_ChiTiets.Any(item => item.TruyThuTienNuoc_Tong.MaDon == MaDon && item.DanhBo == DanhBo);
                case "TXL":
                    return db.TruyThuTienNuoc_ChiTiets.Any(item => item.TruyThuTienNuoc_Tong.MaDonTXL == MaDon && item.DanhBo == DanhBo);
                case "TBC":
                    return db.TruyThuTienNuoc_ChiTiets.Any(item => item.TruyThuTienNuoc_Tong.MaDonTBC == MaDon && item.DanhBo == DanhBo);
                default:
                    return false;
            }
        }

        public bool CheckExist_ChuaXepDon(string DanhBo)
        {
            return db.TruyThuTienNuoc_ChiTiets.Any(item => (item.TinhTrang == null || item.TinhTrang == "" || item.TinhTrang == "Đang gửi thư mời") && item.DanhBo == DanhBo);
        }

        public string GetTinhTrang(string DanhBo)
        {
            if (db.TruyThuTienNuoc_ChiTiets.Any(item => item.DanhBo == DanhBo && (item.TinhTrang == "Đang gửi thư mời" || item.TinhTrang == "Trả góp" || item.TinhTrang == "Đã gửi TB tạm ngưng cung cấp nước" || item.TinhTrang == "Chuyển lập TB hủy")) == true)
                return db.TruyThuTienNuoc_ChiTiets.SingleOrDefault(item => item.DanhBo == DanhBo && (item.TinhTrang == "Đang gửi thư mời" || item.TinhTrang == "Trả góp" || item.TinhTrang == "Đã gửi TB tạm ngưng cung cấp nước" || item.TinhTrang == "Chuyển lập TB hủy")).TinhTrang;
            else
                return "";
        }

        public TruyThuTienNuoc_ChiTiet Get(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.TruyThuTienNuoc_ChiTiets.SingleOrDefault(item => item.TruyThuTienNuoc_Tong.MaDon == MaDon);
                case "TXL":
                    return db.TruyThuTienNuoc_ChiTiets.SingleOrDefault(item => item.TruyThuTienNuoc_Tong.MaDonTXL == MaDon);
                case "TBC":
                    return db.TruyThuTienNuoc_ChiTiets.SingleOrDefault(item => item.TruyThuTienNuoc_Tong.MaDonTBC == MaDon);
                default:
                    return null;
            }
        }

        public TruyThuTienNuoc_ChiTiet Get(decimal MaTTTN)
        {
            return db.TruyThuTienNuoc_ChiTiets.SingleOrDefault(item => item.MaTTTN == MaTTTN);
        }

        public DataTable GetDS(decimal MaTTTN)
        {
            var query = from item in db.TruyThuTienNuoc_ChiTiets
                        where item.MaTTTN == MaTTTN
                        select new
                        {
                            MaDon = item.TruyThuTienNuoc_Tong.MaDon != null ? "TKH" + item.TruyThuTienNuoc_Tong.MaDon
                                : item.TruyThuTienNuoc_Tong.MaDonTXL != null ? "TXL" + item.TruyThuTienNuoc_Tong.MaDonTXL
                                : item.TruyThuTienNuoc_Tong.MaDonTBC != null ? "TBC" + item.TruyThuTienNuoc_Tong.MaDonTBC : null,
                            SoCongVan = item.TruyThuTienNuoc_Tong.MaDon != null ? item.TruyThuTienNuoc_Tong.DonKH.SoCongVan
                                : item.TruyThuTienNuoc_Tong.MaDonTXL != null ? item.TruyThuTienNuoc_Tong.DonTXL.SoCongVan
                                : item.TruyThuTienNuoc_Tong.MaDonTBC != null ? item.TruyThuTienNuoc_Tong.DonTBC.SoCongVan : null,
                            item.MaTTTN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.DienThoai,
                            //item.TongTien,
                            //item.Tongm3BinhQuan,
                            TongTien = item.TruyThuTienNuoc_HoaDons.Count > 0 ? item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value : 0,
                            Tongm3BinhQuan = item.TruyThuTienNuoc_HoaDons.Count > 0 ? (item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value) / item.SoTien1m3 : 0,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(string DanhBo)
        {
            var query = from item in db.TruyThuTienNuoc_ChiTiets
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.TruyThuTienNuoc_Tong.MaDon != null ? "TKH" + item.TruyThuTienNuoc_Tong.MaDon
                                : item.TruyThuTienNuoc_Tong.MaDonTXL != null ? "TXL" + item.TruyThuTienNuoc_Tong.MaDonTXL
                                : item.TruyThuTienNuoc_Tong.MaDonTBC != null ? "TBC" + item.TruyThuTienNuoc_Tong.MaDonTBC : null,
                            SoCongVan = item.TruyThuTienNuoc_Tong.MaDon != null ? item.TruyThuTienNuoc_Tong.DonKH.SoCongVan
                            : item.TruyThuTienNuoc_Tong.MaDonTXL != null ? item.TruyThuTienNuoc_Tong.DonTXL.SoCongVan
                            : item.TruyThuTienNuoc_Tong.MaDonTBC != null ? item.TruyThuTienNuoc_Tong.DonTBC.SoCongVan : null,
                            item.MaTTTN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.DienThoai,
                            //item.TongTien,
                            //item.Tongm3BinhQuan,
                            TongTien = item.TruyThuTienNuoc_HoaDons.Count > 0 ? item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value : 0,
                            Tongm3BinhQuan = item.TruyThuTienNuoc_HoaDons.Count > 0 ? (item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value) / item.SoTien1m3 : 0,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.TruyThuTienNuoc_ChiTiets
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.TruyThuTienNuoc_Tong.MaDon != null ? "TKH" + item.TruyThuTienNuoc_Tong.MaDon
                                : item.TruyThuTienNuoc_Tong.MaDonTXL != null ? "TXL" + item.TruyThuTienNuoc_Tong.MaDonTXL
                                : item.TruyThuTienNuoc_Tong.MaDonTBC != null ? "TBC" + item.TruyThuTienNuoc_Tong.MaDonTBC : null,
                            SoCongVan = item.TruyThuTienNuoc_Tong.MaDon != null ? item.TruyThuTienNuoc_Tong.DonKH.SoCongVan
                            : item.TruyThuTienNuoc_Tong.MaDonTXL != null ? item.TruyThuTienNuoc_Tong.DonTXL.SoCongVan
                            : item.TruyThuTienNuoc_Tong.MaDonTBC != null ? item.TruyThuTienNuoc_Tong.DonTBC.SoCongVan : null,
                            item.MaTTTN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.DienThoai,
                            //item.TongTien,
                            //item.Tongm3BinhQuan,
                            TongTien = item.TruyThuTienNuoc_HoaDons.Count > 0 ? item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value : 0,
                            Tongm3BinhQuan = item.TruyThuTienNuoc_HoaDons.Count > 0 ? (item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value) / item.SoTien1m3 : 0,
                            //XepDon = item.TinhTrang != null ? item.TinhTrang != "" ? item.TinhTrang != "Đang gửi thư mời" ? true : false : false : false,
                            item.TinhTrang,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate,string TinhTrang)
        {
            var query = from item in db.TruyThuTienNuoc_ChiTiets
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.TinhTrang.ToString()==TinhTrang
                        select new
                        {
                            MaDon = item.TruyThuTienNuoc_Tong.MaDon != null ? "TKH" + item.TruyThuTienNuoc_Tong.MaDon
                                : item.TruyThuTienNuoc_Tong.MaDonTXL != null ? "TXL" + item.TruyThuTienNuoc_Tong.MaDonTXL
                                : item.TruyThuTienNuoc_Tong.MaDonTBC != null ? "TBC" + item.TruyThuTienNuoc_Tong.MaDonTBC : null,
                            SoCongVan = item.TruyThuTienNuoc_Tong.MaDon != null ? item.TruyThuTienNuoc_Tong.DonKH.SoCongVan
                            : item.TruyThuTienNuoc_Tong.MaDonTXL != null ? item.TruyThuTienNuoc_Tong.DonTXL.SoCongVan
                            : item.TruyThuTienNuoc_Tong.MaDonTBC != null ? item.TruyThuTienNuoc_Tong.DonTBC.SoCongVan : null,
                            item.MaTTTN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.DienThoai,
                            //item.TongTien,
                            //item.Tongm3BinhQuan,
                            TongTien = item.TruyThuTienNuoc_HoaDons.Count > 0 ? item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value : 0,
                            Tongm3BinhQuan = item.TruyThuTienNuoc_HoaDons.Count > 0 ? (item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongMoi).Value - item.TruyThuTienNuoc_HoaDons.Sum(itemCT => itemCT.TongCongCu).Value) / item.SoTien1m3 : 0,
                            //XepDon = item.TinhTrang != null ? item.TinhTrang != "" ? item.TinhTrang != "Đang gửi thư mời" ? true : false : false : false,
                            item.TinhTrang,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSNoiDung()
        {
            return LINQToDataTable(db.TruyThuTienNuoc_ChiTiets.Select(item => new { item.NoiDung }).ToList().Distinct());
        }

        #endregion

        #region TruyThuTienNuoc_HoaDon

        public bool ThemCT(TruyThuTienNuoc_HoaDon cttttn)
        {
            try
            {
                if (db.TruyThuTienNuoc_HoaDons.Count() > 0)
                {
                    cttttn.MaCTTTTN = db.TruyThuTienNuoc_HoaDons.Max(item => item.MaCTTTTN) + 1;
                }
                else
                    cttttn.MaCTTTTN = 1;
                cttttn.CreateDate = DateTime.Now;
                cttttn.CreateBy = CTaiKhoan.MaUser;
                db.TruyThuTienNuoc_HoaDons.InsertOnSubmit(cttttn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SuaCT(TruyThuTienNuoc_HoaDon cttttn)
        {
            try
            {
                cttttn.ModifyDate = DateTime.Now;
                cttttn.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaCT(TruyThuTienNuoc_HoaDon cttttn)
        {
            try
            {
                db.TruyThuTienNuoc_HoaDons.DeleteOnSubmit(cttttn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist_CT(decimal MaCTTTTN, string Ky, string Nam)
        {
            return db.TruyThuTienNuoc_HoaDons.Any(item => item.MaCTTTTN == MaCTTTTN && item.Ky == Ky && item.Nam == Nam);
        }

        public TruyThuTienNuoc_HoaDon GetCT(decimal MaCTTTTN)
        {
            return db.TruyThuTienNuoc_HoaDons.SingleOrDefault(item => item.MaCTTTTN == MaCTTTTN);
        }

        public TruyThuTienNuoc_HoaDon GetCT(decimal MaCTTTTN, string Ky, string Nam)
        {
            return db.TruyThuTienNuoc_HoaDons.SingleOrDefault(item => item.MaCTTTTN == MaCTTTTN && item.Ky == Ky && item.Nam == Nam);
        }

        #endregion

        #region TruyThuTienNuoc_ThanhToan

        public bool ThemThanhToan(TruyThuTienNuoc_ThanhToan tttttn)
        {
            try
            {
                if (db.TruyThuTienNuoc_ThanhToans.Count() > 0)
                {
                    tttttn.ID = db.TruyThuTienNuoc_ThanhToans.Max(item => item.ID) + 1;
                }
                else
                    tttttn.ID = 1;
                tttttn.CreateDate = DateTime.Now;
                tttttn.CreateBy = CTaiKhoan.MaUser;
                db.TruyThuTienNuoc_ThanhToans.InsertOnSubmit(tttttn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SuaThanhToan(TruyThuTienNuoc_ThanhToan tttttn)
        {
            try
            {
                tttttn.ModifyDate = DateTime.Now;
                tttttn.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaThanhToan(TruyThuTienNuoc_ThanhToan tttttn)
        {
            try
            {
                db.TruyThuTienNuoc_ThanhToans.DeleteOnSubmit(tttttn);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public TruyThuTienNuoc_ThanhToan GetThanhToan(int ID)
        {
            return db.TruyThuTienNuoc_ThanhToans.SingleOrDefault(item => item.ID == ID);
        }

        public List<TruyThuTienNuoc_ThanhToan> GetDSThanhToan(decimal MaCTTTTN)
        {
            return db.TruyThuTienNuoc_ThanhToans.Where(item => item.MaCTTTTN == MaCTTTTN).ToList();
        }

        #endregion

        #region Thư Mời

        public bool ThemThuMoi(TruyThuTienNuoc_ThuMoi entity)
        {
            try
            {
                if (db.TruyThuTienNuoc_ThuMois.Count() > 0)
                {
                    entity.ID = db.TruyThuTienNuoc_ThuMois.Max(item => item.ID) + 1;
                    if (db.TruyThuTienNuoc_ThuMois.Where(item => item.MaCTTTTN == entity.MaCTTTTN).Count() == 0)
                        entity.STT = 2;
                    else
                        entity.STT = db.TruyThuTienNuoc_ThuMois.Where(item => item.MaCTTTTN == entity.MaCTTTTN).Count() + 1;
                }
                else
                {
                    entity.ID = 1;
                    entity.STT = 2;
                }
                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.TruyThuTienNuoc_ThuMois.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SuaThuMoi(TruyThuTienNuoc_ThuMoi entity)
        {
            try
            {
                entity.ModifyDate = DateTime.Now;
                entity.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaThuMoi(TruyThuTienNuoc_ThuMoi entity)
        {
            try
            {
                db.TruyThuTienNuoc_ThuMois.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public TruyThuTienNuoc_ThuMoi GetThuMoi(int ID)
        {
            return db.TruyThuTienNuoc_ThuMois.SingleOrDefault(item => item.ID == ID);
        }

        public List<TruyThuTienNuoc_ThuMoi> GetDSThuMoi(decimal MaCTTTTN)
        {
            return db.TruyThuTienNuoc_ThuMois.Where(item => item.MaCTTTTN == MaCTTTTN).ToList();
        }

        #endregion

        public int CountTongTienThanhToan(decimal MaCTTTTN)
        {
            try
            {
                if (db.TruyThuTienNuoc_HoaDons.Any(item => item.MaCTTTTN == MaCTTTTN))
                    return db.TruyThuTienNuoc_HoaDons.Where(item => item.MaCTTTTN == MaCTTTTN).Sum(item => item.TongCongMoi).Value - db.TruyThuTienNuoc_HoaDons.Where(item => item.MaCTTTTN == MaCTTTTN).Sum(item => item.TongCongCu).Value;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int CountTongm3(decimal MaCTTTTN)
        {
            try
            {
                if (db.TruyThuTienNuoc_HoaDons.Any(item => item.MaCTTTTN == MaCTTTTN))
                    return (db.TruyThuTienNuoc_HoaDons.Where(item => item.MaCTTTTN == MaCTTTTN).Sum(item => item.TongCongMoi).Value - db.TruyThuTienNuoc_HoaDons.Where(item => item.MaCTTTTN == MaCTTTTN).Sum(item => item.TongCongCu).Value) / SoTien1m3;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}

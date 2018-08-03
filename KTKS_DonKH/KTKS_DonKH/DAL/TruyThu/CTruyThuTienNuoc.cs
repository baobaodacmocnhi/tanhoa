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

        #region TruyThuTienNuoc

        public bool Them(TruyThuTienNuoc tttn)
        {
            try
            {
                if (db.TruyThuTienNuocs.Count() > 0)
                {
                    string ID = "MaTTTN";
                    string Table = "TruyThuTienNuoc";
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
                db.TruyThuTienNuocs.InsertOnSubmit(tttn);
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

        public bool Sua(TruyThuTienNuoc tttn)
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

        public bool Xoa(TruyThuTienNuoc tttn)
        {
            try
            {
                db.CTTruyThuTienNuocs.DeleteAllOnSubmit(tttn.CTTruyThuTienNuocs.ToList());
                db.ThanhToanTruyThuTienNuocs.DeleteAllOnSubmit(tttn.ThanhToanTruyThuTienNuocs.ToList());
                db.TruyThuTienNuoc_ThuMois.DeleteAllOnSubmit(tttn.TruyThuTienNuoc_ThuMois.ToList());
                db.TruyThuTienNuocs.DeleteOnSubmit(tttn);
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
            return db.TruyThuTienNuocs.Any(item => item.MaTTTN == MaTTTN);
        }

        public bool CheckExist(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.TruyThuTienNuocs.Any(item => item.MaDon == MaDon);
                case "TXL":
                    return db.TruyThuTienNuocs.Any(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.TruyThuTienNuocs.Any(item => item.MaDonTBC == MaDon);
                default:
                    return false;
            }
        }

        public bool CheckExist(string Loai, decimal MaDon, string DanhBo)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.TruyThuTienNuocs.Any(item => item.MaDon == MaDon && item.DanhBo == DanhBo);
                case "TXL":
                    return db.TruyThuTienNuocs.Any(item => item.MaDonTXL == MaDon && item.DanhBo == DanhBo);
                case "TBC":
                    return db.TruyThuTienNuocs.Any(item => item.MaDonTBC == MaDon && item.DanhBo == DanhBo);
                default:
                    return false;
            }
        }

        public bool CheckExist_ChuaXepDon(string DanhBo)
        {
            return db.TruyThuTienNuocs.Any(item => (item.TinhTrang == null || item.TinhTrang == "" || item.TinhTrang == "Đang gửi thư mời") && item.DanhBo == DanhBo);
        }

        public string GetTinhTrang(string DanhBo)
        {
            if (db.TruyThuTienNuocs.Any(item => item.DanhBo == DanhBo && (item.TinhTrang == "Đang gửi thư mời" || item.TinhTrang == "Trả góp" || item.TinhTrang == "Đã gửi TB tạm ngưng cung cấp nước" || item.TinhTrang == "Chuyển lập TB hủy")) == true)
                return db.TruyThuTienNuocs.SingleOrDefault(item => item.DanhBo == DanhBo && (item.TinhTrang == "Đang gửi thư mời" || item.TinhTrang == "Trả góp" || item.TinhTrang == "Đã gửi TB tạm ngưng cung cấp nước" || item.TinhTrang == "Chuyển lập TB hủy")).TinhTrang;
            else
                return "";
        }

        public TruyThuTienNuoc Get(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.TruyThuTienNuocs.SingleOrDefault(item => item.MaDon == MaDon);
                case "TXL":
                    return db.TruyThuTienNuocs.SingleOrDefault(item => item.MaDonTXL == MaDon);
                case "TBC":
                    return db.TruyThuTienNuocs.SingleOrDefault(item => item.MaDonTBC == MaDon);
                default:
                    return null;
            }
        }

        public TruyThuTienNuoc Get(decimal MaTTTN)
        {
            return db.TruyThuTienNuocs.SingleOrDefault(item => item.MaTTTN == MaTTTN);
        }

        public DataTable GetDS(decimal MaTTTN)
        {
            var query = from item in db.TruyThuTienNuocs
                        where item.MaTTTN == MaTTTN
                        select new
                        {
                            MaDon = item.MaDon != null ? "TKH" + item.MaDon
                                : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            SoCongVan = item.MaDon != null ? item.DonKH.SoCongVan
                                : item.MaDonTXL != null ? item.DonTXL.SoCongVan
                                : item.MaDonTBC != null ? item.DonTBC.SoCongVan : null,
                            item.MaTTTN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.DienThoai,
                            //item.TongTien,
                            //item.Tongm3BinhQuan,
                            TongTien = item.CTTruyThuTienNuocs.Count > 0 ? item.CTTruyThuTienNuocs.Sum(itemCT => itemCT.TongCongMoi).Value - item.CTTruyThuTienNuocs.Sum(itemCT => itemCT.TongCongCu).Value : 0,
                            Tongm3BinhQuan = item.CTTruyThuTienNuocs.Count > 0 ? (item.CTTruyThuTienNuocs.Sum(itemCT => itemCT.TongCongMoi).Value - item.CTTruyThuTienNuocs.Sum(itemCT => itemCT.TongCongCu).Value) / item.SoTien1m3 : 0,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(string DanhBo)
        {
            var query = from item in db.TruyThuTienNuocs
                        where item.DanhBo == DanhBo
                        select new
                        {
                            MaDon = item.MaDon != null ? "TKH" + item.MaDon
                                : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            SoCongVan = item.MaDon != null ? item.DonKH.SoCongVan
                            : item.MaDonTXL != null ? item.DonTXL.SoCongVan
                            : item.MaDonTBC != null ? item.DonTBC.SoCongVan : null,
                            item.MaTTTN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.DienThoai,
                            //item.TongTien,
                            //item.Tongm3BinhQuan,
                            TongTien = item.CTTruyThuTienNuocs.Count > 0 ? item.CTTruyThuTienNuocs.Sum(itemCT => itemCT.TongCongMoi).Value - item.CTTruyThuTienNuocs.Sum(itemCT => itemCT.TongCongCu).Value : 0,
                            Tongm3BinhQuan = item.CTTruyThuTienNuocs.Count > 0 ? (item.CTTruyThuTienNuocs.Sum(itemCT => itemCT.TongCongMoi).Value - item.CTTruyThuTienNuocs.Sum(itemCT => itemCT.TongCongCu).Value) / item.SoTien1m3 : 0,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from item in db.TruyThuTienNuocs
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date
                        select new
                        {
                            MaDon = item.MaDon != null ? "TKH" + item.MaDon
                                : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            SoCongVan = item.MaDon != null ? item.DonKH.SoCongVan
                            : item.MaDonTXL != null ? item.DonTXL.SoCongVan
                            : item.MaDonTBC != null ? item.DonTBC.SoCongVan : null,
                            item.MaTTTN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.DienThoai,
                            //item.TongTien,
                            //item.Tongm3BinhQuan,
                            TongTien = item.CTTruyThuTienNuocs.Count > 0 ? item.CTTruyThuTienNuocs.Sum(itemCT => itemCT.TongCongMoi).Value - item.CTTruyThuTienNuocs.Sum(itemCT => itemCT.TongCongCu).Value : 0,
                            Tongm3BinhQuan = item.CTTruyThuTienNuocs.Count > 0 ? (item.CTTruyThuTienNuocs.Sum(itemCT => itemCT.TongCongMoi).Value - item.CTTruyThuTienNuocs.Sum(itemCT => itemCT.TongCongCu).Value) / item.SoTien1m3 : 0,
                            //XepDon = item.TinhTrang != null ? item.TinhTrang != "" ? item.TinhTrang != "Đang gửi thư mời" ? true : false : false : false,
                            item.TinhTrang,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate,string TinhTrang)
        {
            var query = from item in db.TruyThuTienNuocs
                        where item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.TinhTrang.ToString()==TinhTrang
                        select new
                        {
                            MaDon = item.MaDon != null ? "TKH" + item.MaDon
                                : item.MaDonTXL != null ? "TXL" + item.MaDonTXL
                                : item.MaDonTBC != null ? "TBC" + item.MaDonTBC : null,
                            SoCongVan = item.MaDon != null ? item.DonKH.SoCongVan
                            : item.MaDonTXL != null ? item.DonTXL.SoCongVan
                            : item.MaDonTBC != null ? item.DonTBC.SoCongVan : null,
                            item.MaTTTN,
                            item.CreateDate,
                            item.DanhBo,
                            item.HoTen,
                            item.DiaChi,
                            item.NoiDung,
                            item.DienThoai,
                            //item.TongTien,
                            //item.Tongm3BinhQuan,
                            TongTien = item.CTTruyThuTienNuocs.Count > 0 ? item.CTTruyThuTienNuocs.Sum(itemCT => itemCT.TongCongMoi).Value - item.CTTruyThuTienNuocs.Sum(itemCT => itemCT.TongCongCu).Value : 0,
                            Tongm3BinhQuan = item.CTTruyThuTienNuocs.Count > 0 ? (item.CTTruyThuTienNuocs.Sum(itemCT => itemCT.TongCongMoi).Value - item.CTTruyThuTienNuocs.Sum(itemCT => itemCT.TongCongCu).Value) / item.SoTien1m3 : 0,
                            //XepDon = item.TinhTrang != null ? item.TinhTrang != "" ? item.TinhTrang != "Đang gửi thư mời" ? true : false : false : false,
                            item.TinhTrang,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSNoiDung()
        {
            return LINQToDataTable(db.TruyThuTienNuocs.Select(item => new { item.NoiDung }).ToList().Distinct());
        }

        #endregion

        #region CTTruyThuTienNuoc

        public bool ThemCT(CTTruyThuTienNuoc cttttn)
        {
            try
            {
                if (db.CTTruyThuTienNuocs.Count() > 0)
                {
                    cttttn.MaCTTTTN = db.CTTruyThuTienNuocs.Max(item => item.MaCTTTTN) + 1;
                }
                else
                    cttttn.MaCTTTTN = 1;
                cttttn.CreateDate = DateTime.Now;
                cttttn.CreateBy = CTaiKhoan.MaUser;
                db.CTTruyThuTienNuocs.InsertOnSubmit(cttttn);
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

        public bool SuaCT(CTTruyThuTienNuoc cttttn)
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

        public bool XoaCT(CTTruyThuTienNuoc cttttn)
        {
            try
            {
                db.CTTruyThuTienNuocs.DeleteOnSubmit(cttttn);
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

        public bool CheckExist_CT(decimal MaTTTN, string Ky, string Nam)
        {
            return db.CTTruyThuTienNuocs.Any(item => item.MaTTTN == MaTTTN && item.Ky == Ky && item.Nam == Nam);
        }

        public CTTruyThuTienNuoc GetCT(decimal MaCTTTTN)
        {
            return db.CTTruyThuTienNuocs.SingleOrDefault(item => item.MaCTTTTN == MaCTTTTN);
        }

        public CTTruyThuTienNuoc GetCT(decimal MaTTTN, string Ky, string Nam)
        {
            return db.CTTruyThuTienNuocs.SingleOrDefault(item => item.MaTTTN == MaTTTN && item.Ky == Ky && item.Nam == Nam);
        }

        #endregion

        #region ThanhToanTruyThuTienNuoc

        public bool ThemThanhToan(ThanhToanTruyThuTienNuoc tttttn)
        {
            try
            {
                if (db.ThanhToanTruyThuTienNuocs.Count() > 0)
                {
                    tttttn.MaTTTTTN = db.ThanhToanTruyThuTienNuocs.Max(item => item.MaTTTTTN) + 1;
                }
                else
                    tttttn.MaTTTTTN = 1;
                tttttn.CreateDate = DateTime.Now;
                tttttn.CreateBy = CTaiKhoan.MaUser;
                db.ThanhToanTruyThuTienNuocs.InsertOnSubmit(tttttn);
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

        public bool SuaThanhToan(ThanhToanTruyThuTienNuoc tttttn)
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

        public bool XoaThanhToan(ThanhToanTruyThuTienNuoc tttttn)
        {
            try
            {
                db.ThanhToanTruyThuTienNuocs.DeleteOnSubmit(tttttn);
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

        public ThanhToanTruyThuTienNuoc GetThanhToan(int MaTTTTTN)
        {
            return db.ThanhToanTruyThuTienNuocs.SingleOrDefault(item => item.MaTTTTTN == MaTTTTTN);
        }

        public List<ThanhToanTruyThuTienNuoc> GetDSThanhToan(decimal MaTTTN)
        {
            return db.ThanhToanTruyThuTienNuocs.Where(item => item.MaTTTN == MaTTTN).ToList();
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
                    if (db.TruyThuTienNuoc_ThuMois.Where(item => item.MaTTTN == entity.MaTTTN).Count() == 0)
                        entity.STT = 2;
                    else
                        entity.STT = db.TruyThuTienNuoc_ThuMois.Where(item => item.MaTTTN == entity.MaTTTN).Count() + 1;
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

        public List<TruyThuTienNuoc_ThuMoi> GetDSThuMoi(decimal MaTTTN)
        {
            return db.TruyThuTienNuoc_ThuMois.Where(item => item.MaTTTN == MaTTTN).ToList();
        }

        #endregion

        public int CountTongTienThanhToan(decimal MaTTTN)
        {
            try
            {
                if (db.CTTruyThuTienNuocs.Any(item => item.MaTTTN == MaTTTN))
                    return db.CTTruyThuTienNuocs.Where(item => item.MaTTTN == MaTTTN).Sum(item => item.TongCongMoi).Value - db.CTTruyThuTienNuocs.Where(item => item.MaTTTN == MaTTTN).Sum(item => item.TongCongCu).Value;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int CountTongm3(decimal MaTTTN)
        {
            try
            {
                if (db.CTTruyThuTienNuocs.Any(item => item.MaTTTN == MaTTTN))
                    return (db.CTTruyThuTienNuocs.Where(item => item.MaTTTN == MaTTTN).Sum(item => item.TongCongMoi).Value - db.CTTruyThuTienNuocs.Where(item => item.MaTTTN == MaTTTN).Sum(item => item.TongCongCu).Value) / 8546;
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

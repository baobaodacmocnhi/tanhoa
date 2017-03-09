﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.ToXuLy
{
    class CDonTXL : CDAL
    {
        /// <summary>
        /// Lấy Mã Đơn kế tiếp
        /// </summary>
        /// <returns></returns>
        public decimal GetNextID()
        {
            try
            {
                if (db.DonTXLs.Count() > 0)
                {
                    string ID = "MaDon";
                    string Table = "DonTXL";
                    decimal MaDon = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    return getMaxNextIDTable(MaDon);
                }
                else
                    return decimal.Parse("1" + DateTime.Now.ToString("yy"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

        }

        public bool Them(DonTXL dontxl)
        {
            try
            {
                dontxl.CreateDate = DateTime.Now;
                dontxl.CreateBy = CTaiKhoan.MaUser;
                db.DonTXLs.InsertOnSubmit(dontxl);
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

        public bool Sua(DonTXL dontxl)
        {
            try
            {
                dontxl.ModifyDate = DateTime.Now;
                dontxl.ModifyBy = CTaiKhoan.MaUser;
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

        public bool Xoa(DonTXL dontxl)
        {
            try
            {
                db.DonTXLs.DeleteOnSubmit(dontxl);
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

        public bool CheckExist(decimal MaDon)
        {
            return db.DonTXLs.Any(item => item.MaDon == MaDon);
        }

        public DonTXL Get(decimal MaDon)
        {
            try
            {
                return db.DonTXLs.SingleOrDefault(itemDonTXL => itemDonTXL.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDS(decimal MaDon)
        {
            var query = from itemDonTXL in db.DonTXLs
                        join itemUser in db.Users on itemDonTXL.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where itemDonTXL.MaDon == MaDon
                        select new
                        {
                            MaDon = "TXL" + itemDonTXL.MaDon,
                            itemDonTXL.LoaiDonTXL.TenLD,
                            itemDonTXL.SoCongVan,
                            itemDonTXL.CreateDate,
                            itemDonTXL.DanhBo,
                            itemDonTXL.HoTen,
                            itemDonTXL.DiaChi,
                            itemDonTXL.NoiDung,
                            NguoiDi_KTXM = tmpUser.HoTen,
                            GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM) == true
                            ? true : db.CTBamChis.Any(item => item.BamChi.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM)
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSByDanhBo(string DanhBo)
        {
            var query = from itemDonTXL in db.DonTXLs
                        join itemUser in db.Users on itemDonTXL.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where itemDonTXL.DanhBo == DanhBo
                        orderby itemDonTXL.CreateDate descending
                        select new
                        {
                            MaDon = "TXL" + itemDonTXL.MaDon,
                            itemDonTXL.LoaiDonTXL.TenLD,
                            itemDonTXL.SoCongVan,
                            itemDonTXL.CreateDate,
                            itemDonTXL.DanhBo,
                            itemDonTXL.HoTen,
                            itemDonTXL.DiaChi,
                            itemDonTXL.NoiDung,
                            NguoiDi_KTXM = tmpUser.HoTen,
                            GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM) == true
                            ? true : db.CTBamChis.Any(item => item.BamChi.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM)
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSByDiaChi(string DiaChi)
        {
            var query = from itemDonTXL in db.DonTXLs
                        join itemUser in db.Users on itemDonTXL.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where itemDonTXL.DiaChi.Contains(DiaChi)
                        orderby itemDonTXL.CreateDate descending
                        select new
                        {
                            MaDon = "TXL" + itemDonTXL.MaDon,
                            itemDonTXL.LoaiDonTXL.TenLD,
                            itemDonTXL.SoCongVan,
                            itemDonTXL.CreateDate,
                            itemDonTXL.DanhBo,
                            itemDonTXL.HoTen,
                            itemDonTXL.DiaChi,
                            itemDonTXL.NoiDung,
                            NguoiDi_KTXM = tmpUser.HoTen,
                            GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM) == true
                            ? true : db.CTBamChis.Any(item => item.BamChi.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM)
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSBySoCongVan(string SoCongVan)
        {
            var query = from itemDonTXL in db.DonTXLs
                        join itemUser in db.Users on itemDonTXL.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where itemDonTXL.SoCongVan.Contains(SoCongVan)
                        orderby itemDonTXL.CreateDate descending
                        select new
                        {
                            MaDon = "TXL" + itemDonTXL.MaDon,
                            itemDonTXL.LoaiDonTXL.TenLD,
                            itemDonTXL.SoCongVan,
                            itemDonTXL.CreateDate,
                            itemDonTXL.DanhBo,
                            itemDonTXL.HoTen,
                            itemDonTXL.DiaChi,
                            itemDonTXL.NoiDung,
                            NguoiDi_KTXM = tmpUser.HoTen,
                            GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM) == true
                            ? true : db.CTBamChis.Any(item => item.BamChi.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM)
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from itemDonTXL in db.DonTXLs
                        join itemUser in db.Users on itemDonTXL.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where itemDonTXL.CreateDate.Value.Date >= FromCreateDate.Date && itemDonTXL.CreateDate.Value.Date <= ToCreateDate.Date
                        orderby itemDonTXL.CreateDate descending
                        select new
                        {
                            MaDon = "TXL" + itemDonTXL.MaDon,
                            itemDonTXL.LoaiDonTXL.TenLD,
                            itemDonTXL.SoCongVan,
                            itemDonTXL.CreateDate,
                            itemDonTXL.DanhBo,
                            itemDonTXL.HoTen,
                            itemDonTXL.DiaChi,
                            itemDonTXL.NoiDung,
                            NguoiDi_KTXM = tmpUser.HoTen,
                            GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM) == true
                            ? true : db.CTBamChis.Any(item => item.BamChi.MaDonTXL == itemDonTXL.MaDon && item.CreateBy == itemDonTXL.NguoiDi_KTXM)
                        };
            return LINQToDataTable(query);
        }

        /// <summary>
        /// Lấy thông tin Đơn Tổ Xử Lý
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="MaChuyen">nơi đơn được chuyến đến để xử lý</param>
        /// <param name="MaNoiChuyenDen"></param>
        /// <param name="NoiChuyenDen"></param>
        /// <param name="LyDoChuyenDen"></param>
        public void GetInfobyMaDon(decimal MaDon, string MaChuyen, out string MaNoiChuyenDen, out string NoiChuyenDen, out string LyDoChuyenDen)
        {
            MaNoiChuyenDen = "";
            NoiChuyenDen = "";
            LyDoChuyenDen = "";
            if (db.DonTXLs.Any(itemDonTXL => itemDonTXL.MaDon == MaDon && itemDonTXL.Nhan == false && itemDonTXL.MaChuyen == MaChuyen))
            {
                MaNoiChuyenDen = db.DonTXLs.SingleOrDefault(itemDonTXL => itemDonTXL.MaDon == MaDon && itemDonTXL.Nhan == false && itemDonTXL.MaChuyen == MaChuyen).MaDon.ToString();
                NoiChuyenDen = "Tổ Xử Lý";
                LyDoChuyenDen = db.DonTXLs.SingleOrDefault(itemDonTXL => itemDonTXL.MaDon == MaDon && itemDonTXL.Nhan == false && itemDonTXL.MaChuyen == MaChuyen).LyDoChuyen;
            }
            //if (db.KTXMs.Any(itemKTXM => itemKTXM.MaDon == MaDon && itemKTXM.Nhan == false && itemKTXM.MaChuyen == MaChuyen))
            //{
            //    MaNoiChuyenDen = db.KTXMs.SingleOrDefault(itemKTXM => itemKTXM.MaDon == MaDon && itemKTXM.Nhan == false && itemKTXM.MaChuyen == MaChuyen).MaKTXM.ToString();
            //    NoiChuyenDen = "Kiểm Tra Xác Minh";
            //    LyDoChuyenDen = db.KTXMs.SingleOrDefault(itemKTXM => itemKTXM.MaDon == MaDon && itemKTXM.Nhan == false && itemKTXM.MaChuyen == MaChuyen).LyDoChuyen;
            //}
        }


    }
}

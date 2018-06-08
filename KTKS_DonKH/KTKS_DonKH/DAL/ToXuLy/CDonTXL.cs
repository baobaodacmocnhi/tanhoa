using System;
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
        public bool Them(DonTXL entity)
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
                    entity.MaDon = getMaxNextIDTable(MaDon);
                }
                else
                    entity.MaDon = decimal.Parse("1" + DateTime.Now.ToString("yy"));

                if (entity.MaDonCha != null)
                {
                    entity.MaDon1 = "XL";
                    if (db.DonTXLs.Count(item => item.MaDonCha == entity.MaDonCha) > 0)
                    {
                        entity.MaDon2 = db.DonTXLs.Max(item => item.MaDon2) + 1;
                    }
                    else
                        entity.MaDon2 = 1;
                    entity.MaDonMoi = entity.MaDonCha + entity.MaDon1 + entity.MaDon2;
                }

                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.DonTXLs.InsertOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(DonTXL entity)
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
                Refresh();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(DonTXL entity)
        {
            try
            {
                db.DonTXLs.DeleteOnSubmit(entity);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(decimal MaDon)
        {
            return db.DonTXLs.Any(item => item.MaDon == MaDon);
        }

        public bool CheckExist(string MaDonMoi)
        {
            return db.DonTXLs.Any(item => item.MaDonMoi == MaDonMoi);
        }

        public bool CheckExist(string DanhBo,DateTime CreateDate)
        {
            return db.DonTXLs.Any(item => item.DanhBo == DanhBo&&item.CreateDate.Value.Date==CreateDate.Date);
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

        public DonTXL Get(string MaDonMoi)
        {
                return db.DonTXLs.SingleOrDefault(itemDonTXL => itemDonTXL.MaDonMoi == MaDonMoi);
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

        public DataTable GetDS(int MaLD,DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from itemDonTXL in db.DonTXLs
                        join itemUser in db.Users on itemDonTXL.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where itemDonTXL.MaLD==MaLD&&itemDonTXL.CreateDate.Value.Date >= FromCreateDate.Date && itemDonTXL.CreateDate.Value.Date <= ToCreateDate.Date
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

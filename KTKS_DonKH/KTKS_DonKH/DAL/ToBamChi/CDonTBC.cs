using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Data;

namespace KTKS_DonKH.DAL.ToBamChi
{
    class CDonTBC : CDAL
    {
        public bool Them(DonTBC entity)
        {
            try
            {
                if (db.DonTBCs.Count() > 0)
                {
                    string ID = "MaDon";
                    string Table = "DonTBC";
                    decimal MaDon = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    entity.MaDon = getMaxNextIDTable(MaDon);
                }
                else
                    entity.MaDon = decimal.Parse("1" + DateTime.Now.ToString("yy"));

                if (entity.MaDon_Cha != null)
                {
                    entity.MaDon1 = ".BC";
                    if (db.DonTBCs.Count(item => item.MaDon_Cha == entity.MaDon_Cha) > 0)
                    {
                        entity.MaDon2 = db.DonTBCs.Max(item => item.MaDon2) + 1;
                    }
                    else
                        entity.MaDon2 = 1;
                    entity.MaDon_New = entity.MaDon_Cha + entity.MaDon1 + entity.MaDon2;
                }

                entity.CreateDate = DateTime.Now;
                entity.CreateBy = CTaiKhoan.MaUser;
                db.DonTBCs.InsertOnSubmit(entity);
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

        public bool Sua(DonTBC entity)
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

        public bool Xoa(DonTBC entity)
        {
            try
            {
                db.DonTBCs.DeleteOnSubmit(entity);
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
            return db.DonTBCs.Any(item => item.MaDon == MaDon);
        }

        public bool CheckExist(string DanhBo, DateTime CreateDate)
        {
            return db.DonTBCs.Any(item => item.DanhBo == DanhBo && item.CreateDate.Value.Date == CreateDate.Date);
        }

        public DonTBC Get(decimal MaDon)
        {
            return db.DonTBCs.SingleOrDefault(item => item.MaDon == MaDon);
        }

        public DataTable GetDS(decimal MaDon)
        {
            var query = from itemDonTBC in db.DonTBCs
                        join itemUser in db.Users on itemDonTBC.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where itemDonTBC.MaDon == MaDon
                        select new
                        {
                            MaDon="TBC"+itemDonTBC.MaDon,
                            itemDonTBC.LoaiDonTBC.TenLD,
                            itemDonTBC.SoCongVan,
                            itemDonTBC.CreateDate,
                            itemDonTBC.DanhBo,
                            itemDonTBC.HoTen,
                            itemDonTBC.DiaChi,
                            itemDonTBC.NoiDung,
                            NguoiDi_KTXM = tmpUser.HoTen,
                            GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true ? true : db.CTBamChis.Any(item => item.BamChi.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM)
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSByDanhBo(string DanhBo)
        {
            var query = from itemDonTBC in db.DonTBCs
                        join itemUser in db.Users on itemDonTBC.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where itemDonTBC.DanhBo == DanhBo
                        orderby itemDonTBC.CreateDate descending
                        select new
                        {
                            MaDon = "TBC" + itemDonTBC.MaDon,
                            itemDonTBC.LoaiDonTBC.TenLD,
                            itemDonTBC.SoCongVan,
                            itemDonTBC.CreateDate,
                            itemDonTBC.DanhBo,
                            itemDonTBC.HoTen,
                            itemDonTBC.DiaChi,
                            itemDonTBC.NoiDung,
                            NguoiDi_KTXM = tmpUser.HoTen,
                            GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true ? true : db.CTBamChis.Any(item => item.BamChi.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM)
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSByDiaChi(string DiaChi)
        {
            var query = from itemDonTBC in db.DonTBCs
                        join itemUser in db.Users on itemDonTBC.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where itemDonTBC.DiaChi.Contains(DiaChi)
                        orderby itemDonTBC.CreateDate descending
                        select new
                        {
                            MaDon = "TBC" + itemDonTBC.MaDon,
                            itemDonTBC.LoaiDonTBC.TenLD,
                            itemDonTBC.SoCongVan,
                            itemDonTBC.CreateDate,
                            itemDonTBC.DanhBo,
                            itemDonTBC.HoTen,
                            itemDonTBC.DiaChi,
                            itemDonTBC.NoiDung,
                            NguoiDi_KTXM = tmpUser.HoTen,
                            GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true ? true : db.CTBamChis.Any(item => item.BamChi.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM)
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSBySoCongVan(string SoCongVan)
        {
            var query = from itemDonTBC in db.DonTBCs
                        join itemUser in db.Users on itemDonTBC.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where itemDonTBC.SoCongVan.Contains(SoCongVan)
                        orderby itemDonTBC.CreateDate descending
                        select new
                        {
                            MaDon = "TBC" + itemDonTBC.MaDon,
                            itemDonTBC.LoaiDonTBC.TenLD,
                            itemDonTBC.SoCongVan,
                            itemDonTBC.CreateDate,
                            itemDonTBC.DanhBo,
                            itemDonTBC.HoTen,
                            itemDonTBC.DiaChi,
                            itemDonTBC.NoiDung,
                            NguoiDi_KTXM = tmpUser.HoTen,
                            GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true ? true : db.CTBamChis.Any(item => item.BamChi.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM)
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from itemDonTBC in db.DonTBCs
                        join itemUser in db.Users on itemDonTBC.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                        from tmpUser in tmpUsers.DefaultIfEmpty()
                        where itemDonTBC.CreateDate.Value.Date >= FromCreateDate.Date && itemDonTBC.CreateDate.Value.Date <= ToCreateDate.Date
                        orderby itemDonTBC.CreateDate descending
                        select new
                        {
                            MaDon = "TBC" + itemDonTBC.MaDon,
                            itemDonTBC.LoaiDonTBC.TenLD,
                            itemDonTBC.SoCongVan,
                            itemDonTBC.CreateDate,
                            itemDonTBC.DanhBo,
                            itemDonTBC.HoTen,
                            itemDonTBC.DiaChi,
                            itemDonTBC.NoiDung,
                            NguoiDi_KTXM = tmpUser.HoTen,
                            GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true ? true : db.CTBamChis.Any(item => item.BamChi.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM)
                        };
            return LINQToDataTable(query);
        }


    }
}

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

        public DonTBC Get(decimal MaDon)
        {
            try
            {
                return db.DonTBCs.SingleOrDefault(item => item.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSByMaDon(decimal MaDon)
        {
            try
            {
                var query = from itemDonTBC in db.DonTBCs
                            join itemUser in db.Users on itemDonTBC.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                            from tmpUser in tmpUsers.DefaultIfEmpty()
                            where itemDonTBC.MaDon == MaDon
                            select new
                            {
                                itemDonTBC.MaDon,
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSByDanhBo(string DanhBo)
        {
            try
            {
                var query = from itemDonTBC in db.DonTBCs
                            join itemUser in db.Users on itemDonTBC.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                            from tmpUser in tmpUsers.DefaultIfEmpty()
                            where itemDonTBC.DanhBo == DanhBo
                            select new
                            {
                                itemDonTBC.MaDon,
                                itemDonTBC.LoaiDonTBC.TenLD,
                                itemDonTBC.SoCongVan,
                                itemDonTBC.CreateDate,
                                itemDonTBC.DanhBo,
                                itemDonTBC.HoTen,
                                itemDonTBC.DiaChi,
                                itemDonTBC.NoiDung,
                                NguoiDi_KTXM=tmpUser.HoTen,
                                GiaiQuyet = db.CTKTXMs.Any(item => item.KTXM.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true ? true : db.CTBamChis.Any(item => item.BamChi.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM)
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSByDiaChi(string DiaChi)
        {
            try
            {
                var query = from itemDonTBC in db.DonTBCs
                            join itemUser in db.Users on itemDonTBC.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                            from tmpUser in tmpUsers.DefaultIfEmpty()
                            where itemDonTBC.DiaChi.Contains(DiaChi)
                            select new
                            {
                                itemDonTBC.MaDon,
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSBySoCongVan(string SoCongVan)
        {
            try
            {
                var query = from itemDonTBC in db.DonTBCs
                            join itemUser in db.Users on itemDonTBC.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                            from tmpUser in tmpUsers.DefaultIfEmpty()
                            where itemDonTBC.SoCongVan.Contains(SoCongVan)
                            select new
                            {
                                itemDonTBC.MaDon,
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GetDSByCreateDate(DateTime FromCreateDate,DateTime ToCreateDate)
        {
            try
            {
                var query = from itemDonTBC in db.DonTBCs
                            join itemUser in db.Users on itemDonTBC.NguoiDi_KTXM equals itemUser.MaU into tmpUsers
                            from tmpUser in tmpUsers.DefaultIfEmpty()
                            where itemDonTBC.CreateDate.Value.Date >= FromCreateDate.Date && itemDonTBC.CreateDate.Value.Date <= ToCreateDate.Date
                            select new
                            {
                                itemDonTBC.MaDon,
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


    }
}

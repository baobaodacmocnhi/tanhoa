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
                                GiaiQuyet = db.KTXMs.Any(item => item.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true ? true : db.BamChis.Any(item => item.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM)
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
                                GiaiQuyet = db.KTXMs.Any(item => item.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true ? true : db.BamChis.Any(item => item.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM)
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
                                GiaiQuyet = db.KTXMs.Any(item => item.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true ? true : db.BamChis.Any(item => item.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM)
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
                                GiaiQuyet = db.KTXMs.Any(item => item.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true ? true : db.BamChis.Any(item => item.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM)
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
                                GiaiQuyet = db.KTXMs.Any(item => item.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM) == true ? true : db.BamChis.Any(item => item.MaDonTBC == itemDonTBC.MaDon && item.CreateBy == itemDonTBC.NguoiDi_KTXM)
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTBCDaChuyenKT(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemLSCKT in db.LichSuChuyenKTXMs
                            join itemDonTBC in db.DonTBCs on itemLSCKT.MaDonTBC equals itemDonTBC.MaDon
                            join itemLoaiDonTBC in db.LoaiDonTBCs on itemDonTBC.MaLD equals itemLoaiDonTBC.MaLD
                            join itemUser in db.Users on itemDonTBC.CreateBy equals itemUser.MaU
                            where itemLSCKT.MaDonTBC != null && itemLSCKT.NgayChuyen.Value.Date >= TuNgay.Date && itemLSCKT.NgayChuyen.Value.Date <= DenNgay.Date
                            orderby itemDonTBC.MaDon ascending
                            select new
                            {
                                itemDonTBC.MaDon,
                                itemLoaiDonTBC.TenLD,
                                itemDonTBC.SoCongVan,
                                itemDonTBC.CreateDate,
                                itemDonTBC.DanhBo,
                                itemDonTBC.HoTen,
                                itemDonTBC.DiaChi,
                                itemDonTBC.NoiDung,
                                CreateBy = itemUser.HoTen,
                                itemLSCKT.NguoiDi,
                                GhiChuChuyenKT = itemLSCKT.GhiChuChuyen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDonTBCDaChuyenKTbySoCongVan(string SoCongVan)
        {
            try
            {
                var query = from itemLSCKT in db.LichSuChuyenKTXMs
                            join itemDonTBC in db.DonTBCs on itemLSCKT.MaDonTBC equals itemDonTBC.MaDon
                            join itemLoaiDonTBC in db.LoaiDonTBCs on itemDonTBC.MaLD equals itemLoaiDonTBC.MaLD
                            join itemUser in db.Users on itemDonTBC.CreateBy equals itemUser.MaU
                            where itemLSCKT.MaDonTBC != null && itemDonTBC.SoCongVan.Contains(SoCongVan)
                            orderby itemDonTBC.MaDon ascending
                            select new
                            {
                                itemDonTBC.MaDon,
                                itemLoaiDonTBC.TenLD,
                                itemDonTBC.SoCongVan,
                                itemDonTBC.CreateDate,
                                itemDonTBC.DanhBo,
                                itemDonTBC.HoTen,
                                itemDonTBC.DiaChi,
                                itemDonTBC.NoiDung,
                                CreateBy = itemUser.HoTen,
                                itemLSCKT.NguoiDi,
                                GhiChuChuyenKT = itemLSCKT.GhiChuChuyen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool CheckGiaiQuyetDonTXLbyUser(int MaU, decimal MaDonTBC)
        {
            if (db.CTKTXMs.Any(itemCTKTXM => itemCTKTXM.KTXM.MaDonTBC == MaDonTBC && itemCTKTXM.CreateBy == MaU))
                return true;
            else
                return db.CTBamChis.Any(itemCTBamChi => itemCTBamChi.BamChi.MaDonTBC == MaDonTBC && itemCTBamChi.CreateBy == MaU);
        }

        public bool CheckGiaiQuyetDonTXLbyUser(int MaU, decimal MaDonTBC, out string NgayGiaiQuyet)
        {
            NgayGiaiQuyet = "";
            if (db.CTKTXMs.Any(itemCTKTXM => itemCTKTXM.KTXM.MaDonTBC == MaDonTBC && itemCTKTXM.CreateBy == MaU))
            {
                NgayGiaiQuyet = db.CTKTXMs.FirstOrDefault(itemCTKTXM => itemCTKTXM.KTXM.MaDonTBC == MaDonTBC && itemCTKTXM.CreateBy == MaU).NgayKTXM.Value.ToString("dd/MM/yyyy");
                return true;
            }
            else
                if (db.CTBamChis.Any(itemCTBamChi => itemCTBamChi.BamChi.MaDonTBC == MaDonTBC && itemCTBamChi.CreateBy == MaU))
                {
                    NgayGiaiQuyet = db.CTBamChis.FirstOrDefault(itemCTBamChi => itemCTBamChi.BamChi.MaDonTBC == MaDonTBC && itemCTBamChi.CreateBy == MaU).NgayBC.Value.ToString("dd/MM/yyyy");
                    return true;
                }
                else
                    return false;
        }

    }
}

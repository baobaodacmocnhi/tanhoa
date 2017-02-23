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
        ///Chứa hàm truy xuất dữ liệu từ bảng BamChi & CTBamChi

        #region BamChi (Bấm Chì)

        public bool ThemBamChi(LinQ.BamChi bamchi)
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

        public bool SuaBamChi(LinQ.BamChi bamchi)
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

        public bool XoaBamChi(LinQ.BamChi bamchi)
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

        public LinQ.BamChi getBamChibyID(decimal MaBC)
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

        public bool CheckExist_BamChi(string Loai,decimal MaDon)
        {
            switch (Loai)
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

        /// <summary>
        /// Kiểm tra Đơn KH có được BamChi xử lý hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns>true/có</returns>
        public bool CheckBamChibyMaDon(decimal MaDon)
        {
            try
            {
                if (db.BamChis.Any(itemBamChi => itemBamChi.MaDon == MaDon))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra Đơn Tổ Xử Lý có được BamChi xử lý hay chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns>true/có</returns>
        public bool CheckBamChibyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                if (db.BamChis.Any(itemBamChi => itemBamChi.MaDonTXL == MaDonTXL))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckBamChibyMaDon_TBC(decimal MaDonTBC)
        {
            try
            {
                if (db.BamChis.Any(itemBamChi => itemBamChi.MaDonTBC == MaDonTBC))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public LinQ.BamChi Get(string Loai,decimal MaDon)
        {
            switch (Loai)
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

        /// <summary>
        /// Lấy BamChi bằng MaDon
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public LinQ.BamChi getBamChibyMaDon(decimal MaDon)
        {
            try
            {
                return db.BamChis.FirstOrDefault(itemBamChi => itemBamChi.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy BamChi bằng MaDon Tổ Xử Lý
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns></returns>
        public LinQ.BamChi getBamChibyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                return db.BamChis.FirstOrDefault(itemBamChi => itemBamChi.MaDonTXL == MaDonTXL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public LinQ.BamChi getBamChibyMaDon_TBC(decimal MaDonTBC)
        {
            try
            {
                return db.BamChis.FirstOrDefault(itemBamChi => itemBamChi.MaDonTBC == MaDonTBC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region CTBamChi (Chi Tiết Bấm Chì)

        public bool ThemCTBamChi(CTBamChi ctbamchi)
        {
            try
            {
                if (db.CTBamChis.Count() > 0)
                {
                    string ID = "MaCTBC";
                    string Table = "CTBamChi";
                    decimal MaCTBC = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaCTBC = db.CTBamChis.Max(itemCTBamChi => itemCTBamChi.MaCTBC);
                    ctbamchi.MaCTBC = getMaxNextIDTable(MaCTBC);
                }
                else
                    ctbamchi.MaCTBC = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                ctbamchi.CreateDate = DateTime.Now;
                ctbamchi.CreateBy = CTaiKhoan.MaUser;
                db.CTBamChis.InsertOnSubmit(ctbamchi);
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

        public bool SuaCTBamChi(CTBamChi ctbamchi)
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

        public bool XoaCTBamChi(CTBamChi ctbamchi)
        {
            try
            {
                decimal MaBC = ctbamchi.MaBC.Value;
                db.CTBamChis.DeleteOnSubmit(ctbamchi);
                if (db.CTBamChis.Any(item => item.MaBC == MaBC) == false)
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

        public CTBamChi getCTBamChibyID(decimal MaCTBC)
        {
            try
            {
                return db.CTBamChis.SingleOrDefault(itemCTBamChi => itemCTBamChi.MaCTBC == MaCTBC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách CTBamChi theo Mã Đơn Tổ Khách Hàng & Danh Bộ. Dùng cho hiện thị Đóng Nước
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public DataTable LoadDSCTBamChi(decimal MaDon, string DanhBo)
        {
            try
            {
                var query = from itemCTBamChi in db.CTBamChis
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.BamChi.MaDon == MaDon && itemCTBamChi.DanhBo == DanhBo
                            orderby itemCTBamChi.CreateDate ascending
                            select new
                            {
                                itemCTBamChi.MaCTBC,
                                itemCTBamChi.NgayBC,
                                itemCTBamChi.GhiChu,
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
        /// Lấy Danh Sách CTBamChi theo Mã Đơn Tổ Xử Lý & Danh Bộ. Dùng cho hiện thị Đóng Nước
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public DataTable LoadDSCTBamChi_TXL(decimal MaDonTXL, string DanhBo)
        {
            try
            {
                var query = from itemCTBamChi in db.CTBamChis
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.BamChi.MaDonTXL == MaDonTXL && itemCTBamChi.DanhBo == DanhBo
                            orderby itemCTBamChi.CreateDate ascending
                            select new
                            {
                                itemCTBamChi.MaCTBC,
                                itemCTBamChi.NgayBC,
                                itemCTBamChi.GhiChu,
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

        public bool CheckExist_CTBamChi(string Loai,decimal MaDon, string DanhBo, DateTime NgayBC, string TrangThaiBamChi)
        {
            switch (Loai)
            {
                case "TKH":
                    return db.CTBamChis.Any(item => item.BamChi.MaDon == MaDon && item.DanhBo == DanhBo && item.NgayBC.Value.Date == NgayBC.Date && item.TrangThaiBC == TrangThaiBamChi);
                case "TXL":
                    return db.CTBamChis.Any(item => item.BamChi.MaDonTXL == MaDon && item.DanhBo == DanhBo && item.NgayBC.Value.Date == NgayBC.Date && item.TrangThaiBC == TrangThaiBamChi);
                case "TBC":
                    return db.CTBamChis.Any(item => item.BamChi.MaDonTBC == MaDon && item.DanhBo == DanhBo && item.NgayBC.Value.Date == NgayBC.Date && item.TrangThaiBC == TrangThaiBamChi);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Kiểm tra CTBamChi đã được tạo cho Mã Đơn Tổ Khách Hàng, Danh Bộ
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTBamChibyMaDonDanhBo(decimal MaDon, string DanhBo, DateTime NgayBC)
        {
            try
            {
                return db.CTBamChis.Any(itemCTBamChi => itemCTBamChi.BamChi.MaDon == MaDon && itemCTBamChi.DanhBo == DanhBo && itemCTBamChi.NgayBC == NgayBC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra CTBamChi đã được tạo cho Mã Đơn Tổ Xử Lý, Danh Bộ
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTBamChibyMaDonDanhBo_TXL(decimal MaDonTXL, string DanhBo, DateTime NgayBC,string TrangThaiBamChi)
        {
            try
            {
                return db.CTBamChis.Any(itemCTBamChi => itemCTBamChi.BamChi.MaDonTXL == MaDonTXL && itemCTBamChi.DanhBo == DanhBo && itemCTBamChi.NgayBC == NgayBC&&itemCTBamChi.TrangThaiBC==TrangThaiBamChi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckCTBamChibyMaDonDanhBo_TBC(decimal MaDonTBC, string DanhBo, DateTime NgayBC, string TrangThaiBamChi)
        {
            try
            {
                return db.CTBamChis.Any(itemCTBamChi => itemCTBamChi.BamChi.MaDonTBC == MaDonTBC && itemCTBamChi.DanhBo == DanhBo && itemCTBamChi.NgayBC == NgayBC && itemCTBamChi.TrangThaiBC == TrangThaiBamChi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable LoadDSCTBamChi()
        {
            try
            {
                var query_DonKH = from itemCTBamChi in db.CTBamChis
                                  join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                  where itemCTBamChi.BamChi.MaDon != null
                                  orderby itemCTBamChi.BamChi.MaDon ascending
                                  select new
                                  {
                                      itemCTBamChi.MaCTBC,
                                      itemCTBamChi.BamChi.MaDon,
                                      itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD,
                                      itemCTBamChi.DanhBo,
                                      itemCTBamChi.HopDong,
                                      itemCTBamChi.HoTen,
                                      itemCTBamChi.DiaChi,
                                      itemCTBamChi.Hieu,
                                      itemCTBamChi.Co,
                                      itemCTBamChi.ChiSo,
                                      itemCTBamChi.TrangThaiBC,
                                      itemCTBamChi.VienChi,
                                      itemCTBamChi.DayChi,
                                      itemCTBamChi.MaSoBC,
                                      itemCTBamChi.TheoYeuCau,
                                      itemCTBamChi.NgayBC,
                                      CreateBy = itemUser.HoTen,
                                  };

                var query_DonTXL = from itemCTBamChi in db.CTBamChis
                                   join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                   where itemCTBamChi.BamChi.MaDonTXL != null
                                   orderby itemCTBamChi.BamChi.MaDon ascending
                                   select new
                                   {
                                       itemCTBamChi.MaCTBC,
                                       MaDon = itemCTBamChi.BamChi.MaDonTXL,
                                       itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD,
                                       itemCTBamChi.DanhBo,
                                       itemCTBamChi.HopDong,
                                       itemCTBamChi.HoTen,
                                       itemCTBamChi.DiaChi,
                                       itemCTBamChi.Hieu,
                                       itemCTBamChi.Co,
                                       itemCTBamChi.ChiSo,
                                       itemCTBamChi.TrangThaiBC,
                                       itemCTBamChi.VienChi,
                                       itemCTBamChi.DayChi,
                                       itemCTBamChi.MaSoBC,
                                       itemCTBamChi.TheoYeuCau,
                                       itemCTBamChi.NgayBC,
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

        public DataTable LoadDSCTBamChiByMaDon(decimal MaDon)
        {
            try
            {
                var query_DonKH = from itemCTBamChi in db.CTBamChis
                                  join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                  where itemCTBamChi.BamChi.MaDon != null && itemCTBamChi.BamChi.MaDon == MaDon
                                  orderby itemCTBamChi.NgayBC descending
                                  select new
                                  {
                                      itemCTBamChi.MaCTBC,
                                      itemCTBamChi.BamChi.MaDon,
                                      itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD,
                                      itemCTBamChi.DanhBo,
                                      itemCTBamChi.HopDong,
                                      itemCTBamChi.HoTen,
                                      itemCTBamChi.DiaChi,
                                      itemCTBamChi.Hieu,
                                      itemCTBamChi.Co,
                                      itemCTBamChi.ChiSo,
                                      itemCTBamChi.TrangThaiBC,
                                      itemCTBamChi.VienChi,
                                      itemCTBamChi.DayChi,
                                      itemCTBamChi.MaSoBC,
                                      itemCTBamChi.TheoYeuCau,
                                      itemCTBamChi.NgayBC,
                                      CreateBy = itemUser.HoTen,
                                  };

                var query_DonTXL = from itemCTBamChi in db.CTBamChis
                                   join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                   where itemCTBamChi.BamChi.MaDonTXL != null && itemCTBamChi.BamChi.MaDonTXL == MaDon
                                   orderby itemCTBamChi.NgayBC descending
                                   select new
                                   {
                                       itemCTBamChi.MaCTBC,
                                       MaDon = itemCTBamChi.BamChi.MaDonTXL,
                                       itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD,
                                       itemCTBamChi.DanhBo,
                                       itemCTBamChi.HopDong,
                                       itemCTBamChi.HoTen,
                                       itemCTBamChi.DiaChi,
                                       itemCTBamChi.Hieu,
                                       itemCTBamChi.Co,
                                       itemCTBamChi.ChiSo,
                                       itemCTBamChi.TrangThaiBC,
                                       itemCTBamChi.VienChi,
                                       itemCTBamChi.DayChi,
                                       itemCTBamChi.MaSoBC,
                                       itemCTBamChi.TheoYeuCau,
                                       itemCTBamChi.NgayBC,
                                       CreateBy = itemUser.HoTen,
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

        public DataTable LoadDSCTBamChiByDanhBo(string DanhBo)
        {
            try
            {
                var query_DonKH = from itemCTBamChi in db.CTBamChis
                                  join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                  where itemCTBamChi.BamChi.MaDonTXL !=null && itemCTBamChi.DanhBo == DanhBo
                                  orderby itemCTBamChi.NgayBC descending
                                  select new
                                  {
                                      itemCTBamChi.MaCTBC,
                                      itemCTBamChi.BamChi.MaDon,
                                      itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD,
                                      itemCTBamChi.DanhBo,
                                      itemCTBamChi.HopDong,
                                      itemCTBamChi.HoTen,
                                      itemCTBamChi.DiaChi,
                                      itemCTBamChi.Hieu,
                                      itemCTBamChi.Co,
                                      itemCTBamChi.ChiSo,
                                      itemCTBamChi.TrangThaiBC,
                                      itemCTBamChi.VienChi,
                                      itemCTBamChi.DayChi,
                                      itemCTBamChi.MaSoBC,
                                      itemCTBamChi.TheoYeuCau,
                                      itemCTBamChi.NgayBC,
                                      CreateBy = itemUser.HoTen,
                                  };

                var query_DonTXL = from itemCTBamChi in db.CTBamChis
                                   join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                   where itemCTBamChi.BamChi.MaDon !=null && itemCTBamChi.DanhBo == DanhBo
                                   orderby itemCTBamChi.NgayBC descending
                                   select new
                                   {
                                       itemCTBamChi.MaCTBC,
                                       MaDon = itemCTBamChi.BamChi.MaDonTXL,
                                       itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD,
                                       itemCTBamChi.DanhBo,
                                       itemCTBamChi.HopDong,
                                       itemCTBamChi.HoTen,
                                       itemCTBamChi.DiaChi,
                                       itemCTBamChi.Hieu,
                                       itemCTBamChi.Co,
                                       itemCTBamChi.ChiSo,
                                       itemCTBamChi.TrangThaiBC,
                                       itemCTBamChi.VienChi,
                                       itemCTBamChi.DayChi,
                                       itemCTBamChi.MaSoBC,
                                       itemCTBamChi.TheoYeuCau,
                                       itemCTBamChi.NgayBC,
                                       CreateBy = itemUser.HoTen,
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

        public DataTable LoadDSCTBamChiByDate(DateTime TuNgay)
        {
            try
            {
                var query_DonKH = from itemCTBamChi in db.CTBamChis
                                  join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                  where itemCTBamChi.BamChi.MaDon != null && itemCTBamChi.NgayBC.Value.Date == TuNgay.Date
                                  orderby itemCTBamChi.NgayBC descending
                                  select new
                                  {
                                      itemCTBamChi.MaCTBC,
                                      itemCTBamChi.BamChi.MaDon,
                                      itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD,
                                      itemCTBamChi.DanhBo,
                                      itemCTBamChi.HopDong,
                                      itemCTBamChi.HoTen,
                                      itemCTBamChi.DiaChi,
                                      itemCTBamChi.Hieu,
                                      itemCTBamChi.Co,
                                      itemCTBamChi.ChiSo,
                                      itemCTBamChi.TrangThaiBC,
                                      itemCTBamChi.VienChi,
                                      itemCTBamChi.DayChi,
                                      itemCTBamChi.MaSoBC,
                                      itemCTBamChi.TheoYeuCau,
                                      itemCTBamChi.NgayBC,
                                      CreateBy = itemUser.HoTen,
                                  };

                var query_DonTXL = from itemCTBamChi in db.CTBamChis
                                   join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                   where itemCTBamChi.BamChi.MaDonTXL != null && itemCTBamChi.NgayBC.Value.Date == TuNgay.Date
                                   orderby itemCTBamChi.NgayBC descending
                                   select new
                                   {
                                       itemCTBamChi.MaCTBC,
                                       MaDon = itemCTBamChi.BamChi.MaDonTXL,
                                       itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD,
                                       itemCTBamChi.DanhBo,
                                       itemCTBamChi.HopDong,
                                       itemCTBamChi.HoTen,
                                       itemCTBamChi.DiaChi,
                                       itemCTBamChi.Hieu,
                                       itemCTBamChi.Co,
                                       itemCTBamChi.ChiSo,
                                       itemCTBamChi.TrangThaiBC,
                                       itemCTBamChi.VienChi,
                                       itemCTBamChi.DayChi,
                                       itemCTBamChi.MaSoBC,
                                       itemCTBamChi.TheoYeuCau,
                                       itemCTBamChi.NgayBC,
                                       CreateBy = itemUser.HoTen,
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

        public DataTable GetDS(string Loai, DateTime FromNgayBC, DateTime ToNgayBC)
        {
            switch (Loai)
            {
                case "TKH":
                    var query = from itemCTBamChi in db.CTBamChis
                                join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                where itemCTBamChi.BamChi.MaDon != null
                                && itemCTBamChi.NgayBC.Value.Date >= FromNgayBC.Date && itemCTBamChi.NgayBC.Value.Date <= ToNgayBC.Date
                                select new
                                {
                                    itemCTBamChi.MaCTBC,
                                    MaDon = "TKH" + itemCTBamChi.BamChi.MaDon,
                                    itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD,
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
                case "TXL":
                    query = from itemCTBamChi in db.CTBamChis
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.BamChi.MaDonTXL != null
                            && itemCTBamChi.NgayBC.Value.Date >= FromNgayBC.Date && itemCTBamChi.NgayBC.Value.Date <= ToNgayBC.Date
                            select new
                            {
                                itemCTBamChi.MaCTBC,
                                MaDon = "TXL" + itemCTBamChi.BamChi.MaDonTXL,
                                itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD,
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
                case "TBC":
                    query = from itemCTBamChi in db.CTBamChis
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.BamChi.MaDonTBC != null
                            && itemCTBamChi.NgayBC.Value.Date >= FromNgayBC.Date && itemCTBamChi.NgayBC.Value.Date <= ToNgayBC.Date
                            select new
                            {
                                itemCTBamChi.MaCTBC,
                                MaDon = "TBC" + itemCTBamChi.BamChi.MaDonTBC,
                                itemCTBamChi.BamChi.DonTBC.LoaiDonTBC.TenLD,
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
                    return null;
            }
        }

        public DataTable GetDS(DateTime FromNgayBC, DateTime ToNgayBC)
        {
            DataTable dt = new DataTable();
            var query = from itemCTBamChi in db.CTBamChis
                        join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                        where itemCTBamChi.BamChi.MaDon != null
                        && itemCTBamChi.NgayBC.Value.Date >= FromNgayBC.Date && itemCTBamChi.NgayBC.Value.Date <= ToNgayBC.Date
                        select new
                        {
                            itemCTBamChi.MaCTBC,
                            MaDon = "TKH" + itemCTBamChi.BamChi.MaDon,
                            itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD,
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
            dt = LINQToDataTable(query);

            query = from itemCTBamChi in db.CTBamChis
                    join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                    where itemCTBamChi.BamChi.MaDonTXL != null
                    && itemCTBamChi.NgayBC.Value.Date >= FromNgayBC.Date && itemCTBamChi.NgayBC.Value.Date <= ToNgayBC.Date
                    select new
                    {
                        itemCTBamChi.MaCTBC,
                        MaDon = "TXL" + itemCTBamChi.BamChi.MaDonTXL,
                        itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD,
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
            dt.Merge(LINQToDataTable(query));

            query = from itemCTBamChi in db.CTBamChis
                    join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                    where itemCTBamChi.BamChi.MaDonTBC != null
                    && itemCTBamChi.NgayBC.Value.Date >= FromNgayBC.Date && itemCTBamChi.NgayBC.Value.Date <= ToNgayBC.Date
                    select new
                    {
                        itemCTBamChi.MaCTBC,
                        MaDon = "TBC" + itemCTBamChi.BamChi.MaDonTBC,
                        itemCTBamChi.BamChi.DonTBC.LoaiDonTBC.TenLD,
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
            dt.Merge(LINQToDataTable(query));

            return dt;
        }

        public DataTable GetDS(string Loai, int CreateBy, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    var query = from itemCTBamChi in db.CTBamChis
                                join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                where itemCTBamChi.CreateBy == CreateBy && itemCTBamChi.BamChi.MaDon == MaDon
                                select new
                                {
                                    itemCTBamChi.MaCTBC,
                                    MaDon = "TKH" + itemCTBamChi.BamChi.MaDon,
                                    itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD,
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
                case "TXL":
                    query = from itemCTBamChi in db.CTBamChis
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.CreateBy == CreateBy && itemCTBamChi.BamChi.MaDonTXL == MaDon
                            select new
                            {
                                itemCTBamChi.MaCTBC,
                                MaDon = "TXL" + itemCTBamChi.BamChi.MaDonTXL,
                                itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD,
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
                case "TBC":
                    query = from itemCTBamChi in db.CTBamChis
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.CreateBy == CreateBy && itemCTBamChi.BamChi.MaDonTBC == MaDon
                            select new
                            {
                                itemCTBamChi.MaCTBC,
                                MaDon = "TBC" + itemCTBamChi.BamChi.MaDonTBC,
                                itemCTBamChi.BamChi.DonTBC.LoaiDonTBC.TenLD,
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
                    return null;
            }
        }

        public DataTable GetDS(string Loai, decimal MaDon)
        {
            switch (Loai)
            {
                case "TKH":
                    var query = from itemCTBamChi in db.CTBamChis
                                join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                where itemCTBamChi.BamChi.MaDon == MaDon
                                select new
                                {
                                    itemCTBamChi.MaCTBC,
                                    MaDon = "TKH" + itemCTBamChi.BamChi.MaDon,
                                    itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD,
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
                case "TXL":
                    query = from itemCTBamChi in db.CTBamChis
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.BamChi.MaDonTXL == MaDon
                            select new
                            {
                                itemCTBamChi.MaCTBC,
                                MaDon = "TXL" + itemCTBamChi.BamChi.MaDonTXL,
                                itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD,
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
                case "TBC":
                    query = from itemCTBamChi in db.CTBamChis
                            join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                            where itemCTBamChi.BamChi.MaDonTBC == MaDon
                            select new
                            {
                                itemCTBamChi.MaCTBC,
                                MaDon = "TBC" + itemCTBamChi.BamChi.MaDonTBC,
                                itemCTBamChi.BamChi.DonTBC.LoaiDonTBC.TenLD,
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
                    return null;
            }
        }

        public DataTable GetDS(int CreateBy, string DanhBo)
        {
            DataTable dt = new DataTable();

            var query = from itemCTBamChi in db.CTBamChis
                        join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                        where itemCTBamChi.BamChi.MaDon != null && itemCTBamChi.CreateBy == CreateBy
                        && itemCTBamChi.DanhBo == DanhBo
                        select new
                        {
                            itemCTBamChi.MaCTBC,
                            MaDon = "TKH" + itemCTBamChi.BamChi.MaDon,
                            itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD,
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
            dt = LINQToDataTable(query);

            query = from itemCTBamChi in db.CTBamChis
                    join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                    where itemCTBamChi.BamChi.MaDonTXL != null && itemCTBamChi.CreateBy == CreateBy
                    && itemCTBamChi.DanhBo == DanhBo
                    select new
                    {
                        itemCTBamChi.MaCTBC,
                        MaDon = "TXL" + itemCTBamChi.BamChi.MaDonTXL,
                        itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD,
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
            dt.Merge(LINQToDataTable(query));

            query = from itemCTBamChi in db.CTBamChis
                    join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                    where itemCTBamChi.BamChi.MaDonTBC != null && itemCTBamChi.CreateBy == CreateBy
                    && itemCTBamChi.DanhBo == DanhBo
                    select new
                    {
                        itemCTBamChi.MaCTBC,
                        MaDon = "TBC" + itemCTBamChi.BamChi.MaDonTBC,
                        itemCTBamChi.BamChi.DonTBC.LoaiDonTBC.TenLD,
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
            dt.Merge(LINQToDataTable(query));

            return dt;
        }

        public DataTable GetDS(int CreateBy, DateTime FromNgayBC, DateTime ToNgayBC)
        {
            DataTable dt = new DataTable();

            var query = from itemCTBamChi in db.CTBamChis
                        join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                        where itemCTBamChi.BamChi.MaDon != null && itemCTBamChi.CreateBy == CreateBy
                        && itemCTBamChi.NgayBC.Value.Date >= FromNgayBC.Date && itemCTBamChi.NgayBC.Value.Date <= ToNgayBC.Date
                        select new
                        {
                            itemCTBamChi.MaCTBC,
                            MaDon = "TKH" + itemCTBamChi.BamChi.MaDon,
                            itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD,
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
            dt = LINQToDataTable(query);

            query = from itemCTBamChi in db.CTBamChis
                    join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                    where itemCTBamChi.BamChi.MaDonTXL != null && itemCTBamChi.CreateBy == CreateBy
                    && itemCTBamChi.NgayBC.Value.Date >= FromNgayBC.Date && itemCTBamChi.NgayBC.Value.Date <= ToNgayBC.Date
                    select new
                    {
                        itemCTBamChi.MaCTBC,
                        MaDon = "TXL" + itemCTBamChi.BamChi.MaDonTXL,
                        itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD,
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
            dt.Merge(LINQToDataTable(query));

            query = from itemCTBamChi in db.CTBamChis
                    join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                    where itemCTBamChi.BamChi.MaDonTBC != null && itemCTBamChi.CreateBy == CreateBy
                    && itemCTBamChi.NgayBC.Value.Date >= FromNgayBC.Date && itemCTBamChi.NgayBC.Value.Date <= ToNgayBC.Date
                    select new
                    {
                        itemCTBamChi.MaCTBC,
                        MaDon = "TBC" + itemCTBamChi.BamChi.MaDonTBC,
                        itemCTBamChi.BamChi.DonTBC.LoaiDonTBC.TenLD,
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
            dt.Merge(LINQToDataTable(query));

            return dt;
        }

        /// <summary>
        /// Lấy Danh Sách CTBamChi theo User
        /// </summary>
        /// <param name="MaUser"></param>
        /// <returns></returns>
        public DataTable LoadDSCTBamChi(int MaUser)
        {
            try
            {
                var query_DonKH = from itemCTBamChi in db.CTBamChis
                                  join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                  where itemCTBamChi.BamChi.MaDon != null && itemCTBamChi.CreateBy == MaUser
                                  orderby itemCTBamChi.NgayBC descending
                                  select new
                                  {
                                      itemCTBamChi.MaCTBC,
                                      itemCTBamChi.BamChi.MaDon,
                                      itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD,
                                      itemCTBamChi.DanhBo,
                                      itemCTBamChi.HopDong,
                                      itemCTBamChi.HoTen,
                                      itemCTBamChi.DiaChi,
                                      itemCTBamChi.Hieu,
                                      itemCTBamChi.Co,
                                      itemCTBamChi.ChiSo,
                                      itemCTBamChi.TrangThaiBC,
                                      itemCTBamChi.VienChi,
                                      itemCTBamChi.DayChi,
                                      itemCTBamChi.MaSoBC,
                                      itemCTBamChi.TheoYeuCau,
                                      itemCTBamChi.NgayBC,
                                      CreateBy = itemUser.HoTen,
                                  };

                var query_DonTXL = from itemCTBamChi in db.CTBamChis
                                   join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                   where itemCTBamChi.BamChi.MaDonTXL != null && itemCTBamChi.CreateBy == MaUser
                                   orderby itemCTBamChi.NgayBC descending
                                   select new
                                   {
                                       itemCTBamChi.MaCTBC,
                                       MaDon = itemCTBamChi.BamChi.MaDonTXL,
                                       itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD,
                                       itemCTBamChi.DanhBo,
                                       itemCTBamChi.HopDong,
                                       itemCTBamChi.HoTen,
                                       itemCTBamChi.DiaChi,
                                       itemCTBamChi.Hieu,
                                       itemCTBamChi.Co,
                                       itemCTBamChi.ChiSo,
                                       itemCTBamChi.TrangThaiBC,
                                       itemCTBamChi.VienChi,
                                       itemCTBamChi.DayChi,
                                       itemCTBamChi.MaSoBC,
                                       itemCTBamChi.TheoYeuCau,
                                       itemCTBamChi.NgayBC,
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

        public DataTable LoadDSCTBamChiByDate(int MaUser, DateTime TuNgay)
        {
            try
            {
                var query_DonKH = from itemCTBamChi in db.CTBamChis
                                  join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                  where itemCTBamChi.BamChi.MaDon != null && itemCTBamChi.CreateBy == MaUser && itemCTBamChi.NgayBC.Value.Date == TuNgay.Date
                                  orderby itemCTBamChi.NgayBC descending
                                  select new
                                  {
                                      itemCTBamChi.MaCTBC,
                                      itemCTBamChi.BamChi.MaDon,
                                      itemCTBamChi.BamChi.DonKH.LoaiDon.TenLD,
                                      itemCTBamChi.DanhBo,
                                      itemCTBamChi.HopDong,
                                      itemCTBamChi.HoTen,
                                      itemCTBamChi.DiaChi,
                                      itemCTBamChi.Hieu,
                                      itemCTBamChi.Co,
                                      itemCTBamChi.ChiSo,
                                      itemCTBamChi.TrangThaiBC,
                                      itemCTBamChi.VienChi,
                                      itemCTBamChi.DayChi,
                                      itemCTBamChi.MaSoBC,
                                      itemCTBamChi.TheoYeuCau,
                                      itemCTBamChi.NgayBC,
                                      CreateBy = itemUser.HoTen,
                                  };

                var query_DonTXL = from itemCTBamChi in db.CTBamChis
                                   join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                   where itemCTBamChi.BamChi.MaDonTXL != null && itemCTBamChi.CreateBy == MaUser && itemCTBamChi.NgayBC.Value.Date == TuNgay.Date
                                   orderby itemCTBamChi.NgayBC descending
                                   select new
                                   {
                                       itemCTBamChi.MaCTBC,
                                       MaDon = itemCTBamChi.BamChi.MaDonTXL,
                                       itemCTBamChi.BamChi.DonTXL.LoaiDonTXL.TenLD,
                                       itemCTBamChi.DanhBo,
                                       itemCTBamChi.HopDong,
                                       itemCTBamChi.HoTen,
                                       itemCTBamChi.DiaChi,
                                       itemCTBamChi.Hieu,
                                       itemCTBamChi.Co,
                                       itemCTBamChi.ChiSo,
                                       itemCTBamChi.TrangThaiBC,
                                       itemCTBamChi.VienChi,
                                       itemCTBamChi.DayChi,
                                       itemCTBamChi.MaSoBC,
                                       itemCTBamChi.TheoYeuCau,
                                       itemCTBamChi.NgayBC,
                                       CreateBy = itemUser.HoTen,
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

        public bool CheckCTBamChibyID(decimal MaCTBC)
        {
            try
            {
                return db.CTBamChis.Any(itemCTBamChi => itemCTBamChi.MaCTBC == MaCTBC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion
    }
}

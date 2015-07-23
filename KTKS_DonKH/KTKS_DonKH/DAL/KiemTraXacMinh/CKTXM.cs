using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Windows.Forms;
using KTKS_DonKH.DAL.HeThong;
using System.Data;

namespace KTKS_DonKH.DAL.KiemTraXacMinh
{
    class CKTXM : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng DCBD & CTDCBD & CTDCHD

        #region KTXM (Kiểm Tra Xác Minh)

        public bool ThemKTXM(KTXM ktxm)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    if (db.KTXMs.Count() > 0)
                    {
                        string ID = "MaKTXM";
                        string Table = "KTXM";
                        decimal MaKTXM = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaKTXM = db.KTXMs.Max(itemKTXM => itemKTXM.MaKTXM);
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
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.KTXMs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaKTXM(KTXM ktxm)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    ktxm.ModifyDate = DateTime.Now;
                    ktxm.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa KTXM", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.KTXMs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        /// <summary>
        /// Hàm này được dùng trong nội bộ DAL
        /// </summary>
        /// <param name="ktxm"></param>
        /// <param name="inhertance">true</param>
        /// <returns></returns>
        public bool ThemKTXM(KTXM ktxm, bool inhertance)
        {
            try
            {
                if (inhertance)
                {
                    if (db.KTXMs.Count() > 0)
                    {
                        decimal MaKTXM = db.KTXMs.Max(itemKTXM => itemKTXM.MaKTXM);
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
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.KTXMs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        /// <summary>
        /// Hàm này được dùng trong nội bộ DAL
        /// </summary>
        /// <param name="ktxm"></param>
        /// <param name="inhertance">true</param>
        /// <returns></returns>
        public bool SuaKTXM(KTXM ktxm, bool inhertance)
        {
            try
            {
                if (inhertance)
                {
                    ktxm.ModifyDate = DateTime.Now;
                    ktxm.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.KTXMs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public DataTable LoadDSKTXMDaDuyet_Old()
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem||CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    var query = from itemKTXM in db.KTXMs
                                join itemDonKH in db.DonKHs on itemKTXM.MaKTXM equals itemDonKH.MaDon
                                join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                select new
                                {
                                    itemDonKH.MaDon,
                                    itemLoaiDon.TenLD,
                                    itemDonKH.CreateDate,
                                    itemDonKH.DanhBo,
                                    itemDonKH.HoTen,
                                    itemDonKH.DiaChi,
                                    itemDonKH.NoiDung,
                                    MaNoiChuyenDen = itemKTXM.MaNoiChuyenDen,
                                    NoiChuyenDen = itemKTXM.NoiChuyenDen,
                                    LyDoChuyenDen = itemKTXM.LyDoChuyenDen,
                                    itemKTXM.MaKTXM,
                                    NgayXuLy = itemKTXM.CreateDate,
                                    itemKTXM.KetQua,
                                    itemKTXM.MaChuyen,
                                    LyDoChuyenDi = itemKTXM.LyDoChuyen
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet LoadDSKTXMDaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table KTXM
                    var queryKTXM_DonKH = from itemKTXM in db.KTXMs
                                          //join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          where itemKTXM.ToXuLy == false
                                          orderby itemKTXM.MaDon ascending
                                          select new
                                          {
                                              itemKTXM.ToXuLy,
                                              itemKTXM.MaDon,
                                              itemKTXM.DonKH.LoaiDon.TenLD,
                                              itemKTXM.DonKH.CreateDate,
                                              itemKTXM.DonKH.DanhBo,
                                              itemKTXM.DonKH.HoTen,
                                              itemKTXM.DonKH.DiaChi,
                                              itemKTXM.DonKH.NoiDung,
                                              MaNoiChuyenDen = itemKTXM.MaNoiChuyenDen,
                                              NoiChuyenDen = itemKTXM.NoiChuyenDen,
                                              LyDoChuyenDen = itemKTXM.LyDoChuyenDen,
                                              itemKTXM.MaKTXM,
                                              NgayXuLy = itemKTXM.CreateDate,
                                              itemKTXM.KetQua,
                                              itemKTXM.MaChuyen,
                                              LyDoChuyenDi = itemKTXM.LyDoChuyen
                                          };

                    var queryKTXM_DonTXL = from itemKTXM in db.KTXMs
                                           //join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                           //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                           where itemKTXM.ToXuLy == true
                                           orderby itemKTXM.MaDonTXL ascending
                                           select new
                                           {
                                               itemKTXM.ToXuLy,
                                               MaDon = itemKTXM.MaDonTXL,
                                               itemKTXM.DonTXL.LoaiDonTXL.TenLD,
                                               itemKTXM.DonTXL.CreateDate,
                                               itemKTXM.DonTXL.DanhBo,
                                               itemKTXM.DonTXL.HoTen,
                                               itemKTXM.DonTXL.DiaChi,
                                               itemKTXM.DonTXL.NoiDung,
                                               MaNoiChuyenDen = itemKTXM.MaNoiChuyenDen,
                                               NoiChuyenDen = itemKTXM.NoiChuyenDen,
                                               LyDoChuyenDen = itemKTXM.LyDoChuyenDen,
                                               itemKTXM.MaKTXM,
                                               NgayXuLy = itemKTXM.CreateDate,
                                               itemKTXM.KetQua,
                                               itemKTXM.MaChuyen,
                                               LyDoChuyenDi = itemKTXM.LyDoChuyen
                                           };

                    DataTable dtKTXM = new DataTable();
                    dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM_DonKH);
                    dtKTXM.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM_DonTXL));
                    dtKTXM.TableName = "KTXM";
                    ds.Tables.Add(dtKTXM);

                    ///Table CTKTXM
                    var queryCTKTXM = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      //where itemCTKTXM.KTXM.MaDon != null
                                      select new
                                      {
                                          itemCTKTXM.MaKTXM,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.NgayKTXM,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.NoiDungKiemTra,
                                          CreateBy = itemUser.HoTen,
                                      };

                    DataTable dtCTKTXM = new DataTable();
                    dtCTKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTKTXM);
                    dtCTKTXM.TableName = "CTKTXM";
                    ds.Tables.Add(dtCTKTXM);

                    if (dtKTXM.Rows.Count > 0 && dtCTKTXM.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["KTXM"].Columns["MaKTXM"], ds.Tables["CTKTXM"].Columns["MaKTXM"]);
                    return ds;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet LoadDSKTXMDaDuyetByMaDon(decimal MaDon)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table KTXM
                    var queryKTXM_DonKH = from itemKTXM in db.KTXMs
                                          //join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          where itemKTXM.ToXuLy == false && itemKTXM.MaDon==MaDon
                                          select new
                                          {
                                              itemKTXM.ToXuLy,
                                              itemKTXM.MaDon,
                                              itemKTXM.DonKH.LoaiDon.TenLD,
                                              itemKTXM.DonKH.CreateDate,
                                              itemKTXM.DonKH.DanhBo,
                                              itemKTXM.DonKH.HoTen,
                                              itemKTXM.DonKH.DiaChi,
                                              itemKTXM.DonKH.NoiDung,
                                              MaNoiChuyenDen = itemKTXM.MaNoiChuyenDen,
                                              NoiChuyenDen = itemKTXM.NoiChuyenDen,
                                              LyDoChuyenDen = itemKTXM.LyDoChuyenDen,
                                              itemKTXM.MaKTXM,
                                              NgayXuLy = itemKTXM.CreateDate,
                                              itemKTXM.KetQua,
                                              itemKTXM.MaChuyen,
                                              LyDoChuyenDi = itemKTXM.LyDoChuyen
                                          };

                    var queryKTXM_DonTXL = from itemKTXM in db.KTXMs
                                           //join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                           //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                           where itemKTXM.ToXuLy == true && itemKTXM.MaDonTXL==MaDon
                                           select new
                                           {
                                               itemKTXM.ToXuLy,
                                               MaDon = itemKTXM.MaDonTXL,
                                               itemKTXM.DonTXL.LoaiDonTXL.TenLD,
                                               itemKTXM.DonTXL.CreateDate,
                                               itemKTXM.DonTXL.DanhBo,
                                               itemKTXM.DonTXL.HoTen,
                                               itemKTXM.DonTXL.DiaChi,
                                               itemKTXM.DonTXL.NoiDung,
                                               MaNoiChuyenDen = itemKTXM.MaNoiChuyenDen,
                                               NoiChuyenDen = itemKTXM.NoiChuyenDen,
                                               LyDoChuyenDen = itemKTXM.LyDoChuyenDen,
                                               itemKTXM.MaKTXM,
                                               NgayXuLy = itemKTXM.CreateDate,
                                               itemKTXM.KetQua,
                                               itemKTXM.MaChuyen,
                                               LyDoChuyenDi = itemKTXM.LyDoChuyen
                                           };

                    DataTable dtKTXM = new DataTable();
                    dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM_DonKH.Distinct());
                    dtKTXM.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM_DonTXL.Distinct()));
                    dtKTXM.TableName = "KTXM";
                    ds.Tables.Add(dtKTXM);

                    ///Table CTKTXM
                    var queryCTKTXM = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.KTXM.MaDon == MaDon || itemCTKTXM.KTXM.MaDonTXL==MaDon
                                      select new
                                      {
                                          itemCTKTXM.MaKTXM,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.NgayKTXM,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.NoiDungKiemTra,
                                          CreateBy = itemUser.HoTen,
                                      };

                    DataTable dtCTKTXM = new DataTable();
                    dtCTKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTKTXM);
                    dtCTKTXM.TableName = "CTKTXM";
                    ds.Tables.Add(dtCTKTXM);

                    if (dtKTXM.Rows.Count > 0 && dtCTKTXM.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["KTXM"].Columns["MaKTXM"], ds.Tables["CTKTXM"].Columns["MaKTXM"]);
                    return ds;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet LoadDSKTXMDaDuyetByMaDons(decimal TuMaDon, decimal DenMaDon)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table KTXM
                    var queryKTXM_DonKH = from itemKTXM in db.KTXMs
                                          //join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          where itemKTXM.ToXuLy == false && itemKTXM.MaDon >= TuMaDon && itemKTXM.MaDon <= DenMaDon
                                          select new
                                          {
                                              itemKTXM.ToXuLy,
                                              itemKTXM.MaDon,
                                              itemKTXM.DonKH.LoaiDon.TenLD,
                                              itemKTXM.DonKH.CreateDate,
                                              itemKTXM.DonKH.DanhBo,
                                              itemKTXM.DonKH.HoTen,
                                              itemKTXM.DonKH.DiaChi,
                                              itemKTXM.DonKH.NoiDung,
                                              MaNoiChuyenDen = itemKTXM.MaNoiChuyenDen,
                                              NoiChuyenDen = itemKTXM.NoiChuyenDen,
                                              LyDoChuyenDen = itemKTXM.LyDoChuyenDen,
                                              itemKTXM.MaKTXM,
                                              NgayXuLy = itemKTXM.CreateDate,
                                              itemKTXM.KetQua,
                                              itemKTXM.MaChuyen,
                                              LyDoChuyenDi = itemKTXM.LyDoChuyen
                                          };

                    var queryKTXM_DonTXL = from itemKTXM in db.KTXMs
                                           //join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                           //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                           where itemKTXM.ToXuLy == true && itemKTXM.MaDonTXL >= TuMaDon && itemKTXM.MaDonTXL <= DenMaDon
                                           select new
                                           {
                                               itemKTXM.ToXuLy,
                                               MaDon = itemKTXM.MaDonTXL,
                                               itemKTXM.DonTXL.LoaiDonTXL.TenLD,
                                               itemKTXM.DonTXL.CreateDate,
                                               itemKTXM.DonTXL.DanhBo,
                                               itemKTXM.DonTXL.HoTen,
                                               itemKTXM.DonTXL.DiaChi,
                                               itemKTXM.DonTXL.NoiDung,
                                               MaNoiChuyenDen = itemKTXM.MaNoiChuyenDen,
                                               NoiChuyenDen = itemKTXM.NoiChuyenDen,
                                               LyDoChuyenDen = itemKTXM.LyDoChuyenDen,
                                               itemKTXM.MaKTXM,
                                               NgayXuLy = itemKTXM.CreateDate,
                                               itemKTXM.KetQua,
                                               itemKTXM.MaChuyen,
                                               LyDoChuyenDi = itemKTXM.LyDoChuyen
                                           };

                    DataTable dtKTXM = new DataTable();
                    dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM_DonKH.Distinct());
                    dtKTXM.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM_DonTXL.Distinct()));
                    dtKTXM.TableName = "KTXM";
                    ds.Tables.Add(dtKTXM);

                    ///Table CTKTXM
                    var queryCTKTXM = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where (itemCTKTXM.KTXM.MaDon >= TuMaDon && itemCTKTXM.KTXM.MaDon <= DenMaDon) || (itemCTKTXM.KTXM.MaDonTXL >= TuMaDon && itemCTKTXM.KTXM.MaDonTXL <= DenMaDon)
                                      select new
                                      {
                                          itemCTKTXM.MaKTXM,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.NgayKTXM,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.NoiDungKiemTra,
                                          CreateBy = itemUser.HoTen,
                                      };

                    DataTable dtCTKTXM = new DataTable();
                    dtCTKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTKTXM);
                    dtCTKTXM.TableName = "CTKTXM";
                    ds.Tables.Add(dtCTKTXM);

                    if (dtKTXM.Rows.Count > 0 && dtCTKTXM.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["KTXM"].Columns["MaKTXM"], ds.Tables["CTKTXM"].Columns["MaKTXM"]);
                    return ds;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet LoadDSKTXMDaDuyetByDanhBo(string DanhBo)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table KTXM
                    var queryKTXM_DonKH = from itemKTXM in db.KTXMs
                                          //join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          join itemCTKTXM in db.CTKTXMs on itemKTXM.MaKTXM equals itemCTKTXM.MaKTXM
                                          where itemKTXM.ToXuLy == false && itemCTKTXM.DanhBo == DanhBo
                                          orderby itemCTKTXM.NgayKTXM descending
                                          select new
                                          {
                                              itemKTXM.ToXuLy,
                                              itemKTXM.MaDon,
                                              itemKTXM.DonKH.LoaiDon.TenLD,
                                              itemKTXM.DonKH.CreateDate,
                                              itemKTXM.DonKH.DanhBo,
                                              itemKTXM.DonKH.HoTen,
                                              itemKTXM.DonKH.DiaChi,
                                              itemKTXM.DonKH.NoiDung,
                                              MaNoiChuyenDen = itemKTXM.MaNoiChuyenDen,
                                              NoiChuyenDen = itemKTXM.NoiChuyenDen,
                                              LyDoChuyenDen = itemKTXM.LyDoChuyenDen,
                                              itemKTXM.MaKTXM,
                                              NgayXuLy = itemKTXM.CreateDate,
                                              itemKTXM.KetQua,
                                              itemKTXM.MaChuyen,
                                              LyDoChuyenDi = itemKTXM.LyDoChuyen
                                          };

                    var queryKTXM_DonTXL = from itemKTXM in db.KTXMs
                                           //join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                           //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                           join itemCTKTXM in db.CTKTXMs on itemKTXM.MaKTXM equals itemCTKTXM.MaKTXM
                                           where itemKTXM.ToXuLy == true && itemCTKTXM.DanhBo == DanhBo
                                           orderby itemCTKTXM.NgayKTXM descending
                                           select new
                                           {
                                               itemKTXM.ToXuLy,
                                               MaDon = itemKTXM.MaDonTXL,
                                               itemKTXM.DonTXL.LoaiDonTXL.TenLD,
                                               itemKTXM.DonTXL.CreateDate,
                                               itemKTXM.DonTXL.DanhBo,
                                               itemKTXM.DonTXL.HoTen,
                                               itemKTXM.DonTXL.DiaChi,
                                               itemKTXM.DonTXL.NoiDung,
                                               MaNoiChuyenDen = itemKTXM.MaNoiChuyenDen,
                                               NoiChuyenDen = itemKTXM.NoiChuyenDen,
                                               LyDoChuyenDen = itemKTXM.LyDoChuyenDen,
                                               itemKTXM.MaKTXM,
                                               NgayXuLy = itemKTXM.CreateDate,
                                               itemKTXM.KetQua,
                                               itemKTXM.MaChuyen,
                                               LyDoChuyenDi = itemKTXM.LyDoChuyen
                                           };

                    DataTable dtKTXM = new DataTable();
                    dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM_DonKH.Distinct());
                    dtKTXM.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM_DonTXL.Distinct()));
                    dtKTXM.TableName = "KTXM";
                    ds.Tables.Add(dtKTXM);

                    ///Table CTKTXM
                    var queryCTKTXM = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.DanhBo == DanhBo
                                      select new
                                      {
                                          itemCTKTXM.MaKTXM,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.NgayKTXM,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.NoiDungKiemTra,
                                          CreateBy = itemUser.HoTen,
                                      };

                    DataTable dtCTKTXM = new DataTable();
                    dtCTKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTKTXM);
                    dtCTKTXM.TableName = "CTKTXM";
                    ds.Tables.Add(dtCTKTXM);

                    if (dtKTXM.Rows.Count > 0 && dtCTKTXM.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["KTXM"].Columns["MaKTXM"], ds.Tables["CTKTXM"].Columns["MaKTXM"]);
                    return ds;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet LoadDSKTXMDaDuyetByDate(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table KTXM
                    var queryKTXM_DonKH = from itemKTXM in db.KTXMs
                                          //join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          join itemCTKTXM in db.CTKTXMs on itemKTXM.MaKTXM equals itemCTKTXM.MaKTXM
                                          where itemKTXM.ToXuLy == false && itemCTKTXM.NgayKTXM.Value.Date == TuNgay.Date
                                          orderby itemCTKTXM.NgayKTXM descending
                                          select new
                                          {
                                              itemKTXM.ToXuLy,
                                              itemKTXM.MaDon,
                                              itemKTXM.DonKH.LoaiDon.TenLD,
                                              itemKTXM.DonKH.CreateDate,
                                              itemKTXM.DonKH.DanhBo,
                                              itemKTXM.DonKH.HoTen,
                                              itemKTXM.DonKH.DiaChi,
                                              itemKTXM.DonKH.NoiDung,
                                              MaNoiChuyenDen = itemKTXM.MaNoiChuyenDen,
                                              NoiChuyenDen = itemKTXM.NoiChuyenDen,
                                              LyDoChuyenDen = itemKTXM.LyDoChuyenDen,
                                              itemKTXM.MaKTXM,
                                              NgayXuLy = itemKTXM.CreateDate,
                                              itemKTXM.KetQua,
                                              itemKTXM.MaChuyen,
                                              LyDoChuyenDi = itemKTXM.LyDoChuyen
                                          };

                    var queryKTXM_DonTXL = from itemKTXM in db.KTXMs
                                           //join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                           //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                           join itemCTKTXM in db.CTKTXMs on itemKTXM.MaKTXM equals itemCTKTXM.MaKTXM
                                           where itemKTXM.ToXuLy == true && itemCTKTXM.NgayKTXM.Value.Date == TuNgay.Date
                                           orderby itemCTKTXM.NgayKTXM descending
                                           select new
                                           {
                                               itemKTXM.ToXuLy,
                                               MaDon = itemKTXM.MaDonTXL,
                                               itemKTXM.DonTXL.LoaiDonTXL.TenLD,
                                               itemKTXM.DonTXL.CreateDate,
                                               itemKTXM.DonTXL.DanhBo,
                                               itemKTXM.DonTXL.HoTen,
                                               itemKTXM.DonTXL.DiaChi,
                                               itemKTXM.DonTXL.NoiDung,
                                               MaNoiChuyenDen = itemKTXM.MaNoiChuyenDen,
                                               NoiChuyenDen = itemKTXM.NoiChuyenDen,
                                               LyDoChuyenDen = itemKTXM.LyDoChuyenDen,
                                               itemKTXM.MaKTXM,
                                               NgayXuLy = itemKTXM.CreateDate,
                                               itemKTXM.KetQua,
                                               itemKTXM.MaChuyen,
                                               LyDoChuyenDi = itemKTXM.LyDoChuyen
                                           };

                    DataTable dtKTXM = new DataTable();
                    dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM_DonKH.Distinct());
                    dtKTXM.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM_DonTXL.Distinct()));
                    dtKTXM.TableName = "KTXM";
                    ds.Tables.Add(dtKTXM);

                    ///Table CTKTXM
                    var queryCTKTXM = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.NgayKTXM.Value.Date== TuNgay.Date
                                      select new
                                      {
                                          itemCTKTXM.MaKTXM,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.NgayKTXM,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.NoiDungKiemTra,
                                          CreateBy = itemUser.HoTen,
                                      };

                    DataTable dtCTKTXM = new DataTable();
                    dtCTKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTKTXM);
                    dtCTKTXM.TableName = "CTKTXM";
                    ds.Tables.Add(dtCTKTXM);

                    if (dtKTXM.Rows.Count > 0 && dtCTKTXM.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["KTXM"].Columns["MaKTXM"], ds.Tables["CTKTXM"].Columns["MaKTXM"]);
                    return ds;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet LoadDSKTXMDaDuyetByDates(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table KTXM
                    var queryKTXM_DonKH = from itemKTXM in db.KTXMs
                                          //join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          join itemCTKTXM in db.CTKTXMs on itemKTXM.MaKTXM equals itemCTKTXM.MaKTXM
                                          where itemKTXM.ToXuLy == false && itemCTKTXM.NgayKTXM.Value.Date >= TuNgay.Date && itemCTKTXM.NgayKTXM.Value.Date <= DenNgay.Date
                                          orderby itemCTKTXM.NgayKTXM descending
                                          select new
                                          {
                                              itemKTXM.ToXuLy,
                                              itemKTXM.MaDon,
                                              itemKTXM.DonKH.LoaiDon.TenLD,
                                              itemKTXM.DonKH.CreateDate,
                                              itemKTXM.DonKH.DanhBo,
                                              itemKTXM.DonKH.HoTen,
                                              itemKTXM.DonKH.DiaChi,
                                              itemKTXM.DonKH.NoiDung,
                                              MaNoiChuyenDen = itemKTXM.MaNoiChuyenDen,
                                              NoiChuyenDen = itemKTXM.NoiChuyenDen,
                                              LyDoChuyenDen = itemKTXM.LyDoChuyenDen,
                                              itemKTXM.MaKTXM,
                                              NgayXuLy = itemKTXM.CreateDate,
                                              itemKTXM.KetQua,
                                              itemKTXM.MaChuyen,
                                              LyDoChuyenDi = itemKTXM.LyDoChuyen
                                          };

                    var queryKTXM_DonTXL = from itemKTXM in db.KTXMs
                                           //join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                           //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                           join itemCTKTXM in db.CTKTXMs on itemKTXM.MaKTXM equals itemCTKTXM.MaKTXM
                                           where itemKTXM.ToXuLy == true && itemCTKTXM.NgayKTXM.Value.Date >= TuNgay.Date && itemCTKTXM.NgayKTXM.Value.Date <= DenNgay.Date
                                           orderby itemCTKTXM.NgayKTXM descending
                                           select new
                                           {
                                               itemKTXM.ToXuLy,
                                               MaDon = itemKTXM.MaDonTXL,
                                               itemKTXM.DonTXL.LoaiDonTXL.TenLD,
                                               itemKTXM.DonTXL.CreateDate,
                                               itemKTXM.DonTXL.DanhBo,
                                               itemKTXM.DonTXL.HoTen,
                                               itemKTXM.DonTXL.DiaChi,
                                               itemKTXM.DonTXL.NoiDung,
                                               MaNoiChuyenDen = itemKTXM.MaNoiChuyenDen,
                                               NoiChuyenDen = itemKTXM.NoiChuyenDen,
                                               LyDoChuyenDen = itemKTXM.LyDoChuyenDen,
                                               itemKTXM.MaKTXM,
                                               NgayXuLy = itemKTXM.CreateDate,
                                               itemKTXM.KetQua,
                                               itemKTXM.MaChuyen,
                                               LyDoChuyenDi = itemKTXM.LyDoChuyen
                                           };

                    DataTable dtKTXM = new DataTable();
                    dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM_DonKH.Distinct());
                    dtKTXM.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM_DonTXL.Distinct()));
                    dtKTXM.TableName = "KTXM";
                    ds.Tables.Add(dtKTXM);

                    ///Table CTKTXM
                    var queryCTKTXM = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.NgayKTXM.Value.Date >= TuNgay.Date && itemCTKTXM.NgayKTXM.Value.Date <= DenNgay.Date
                                      select new
                                      {
                                          itemCTKTXM.MaKTXM,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.NgayKTXM,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.NoiDungKiemTra,
                                          CreateBy = itemUser.HoTen,
                                      };

                    DataTable dtCTKTXM = new DataTable();
                    dtCTKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTKTXM);
                    dtCTKTXM.TableName = "CTKTXM";
                    ds.Tables.Add(dtCTKTXM);

                    if (dtKTXM.Rows.Count > 0 && dtCTKTXM.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["KTXM"].Columns["MaKTXM"], ds.Tables["CTKTXM"].Columns["MaKTXM"]);
                    return ds;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet LoadDSKTXMDaDuyet_TXL()
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table KTXM
                    var queryKTXM = from itemKTXM in db.KTXMs
                                    join itemDonTXL in db.DonTXLs on itemKTXM.MaDonTXL equals itemDonTXL.MaDon
                                    join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                    where itemKTXM.MaDonTXL != null
                                    orderby itemDonTXL.MaDon ascending
                                    select new
                                    {
                                        itemKTXM.ToXuLy,
                                        itemDonTXL.MaDon,
                                        itemLoaiDonTXL.TenLD,
                                        itemDonTXL.CreateDate,
                                        itemDonTXL.DanhBo,
                                        itemDonTXL.HoTen,
                                        itemDonTXL.DiaChi,
                                        itemDonTXL.NoiDung,
                                        MaNoiChuyenDen = itemKTXM.MaNoiChuyenDen,
                                        NoiChuyenDen = itemKTXM.NoiChuyenDen,
                                        LyDoChuyenDen = itemKTXM.LyDoChuyenDen,
                                        itemKTXM.MaKTXM,
                                        NgayXuLy = itemKTXM.CreateDate,
                                        itemKTXM.KetQua,
                                        itemKTXM.MaChuyen,
                                        LyDoChuyenDi = itemKTXM.LyDoChuyen,
                                    };
                    DataTable dtKTXM = new DataTable();
                    dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM);
                    dtKTXM.TableName = "KTXM";
                    ds.Tables.Add(dtKTXM);

                    ///Table CTKTXM
                    var queryCTKTXM = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.KTXM.MaDonTXL != null
                                      select new
                                      {
                                          itemCTKTXM.MaKTXM,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.NgayKTXM,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.NoiDungKiemTra,
                                          CreateBy = itemUser.HoTen,
                                      };

                    DataTable dtCTKTXM = new DataTable();
                    dtCTKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTKTXM);
                    dtCTKTXM.TableName = "CTKTXM";
                    ds.Tables.Add(dtCTKTXM);

                    if (dtKTXM.Rows.Count > 0 && dtCTKTXM.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["KTXM"].Columns["MaKTXM"], ds.Tables["CTKTXM"].Columns["MaKTXM"]);
                    return ds;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSKTXMChuaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    ///Bảng DonKH
                    var queryDonKH = from itemDonKH in db.DonKHs
                                     join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                     where itemDonKH.Nhan == false && itemDonKH.MaChuyen == "KTXM"
                                     orderby itemDonKH.MaDon ascending
                                     select new
                                     {
                                         itemDonKH.MaDon,
                                         itemLoaiDon.TenLD,
                                         itemDonKH.CreateDate,
                                         itemDonKH.DanhBo,
                                         itemDonKH.HoTen,
                                         itemDonKH.DiaChi,
                                         itemDonKH.NoiDung,
                                         MaNoiChuyenDen = itemDonKH.MaDon,
                                         NoiChuyenDen = "Khách Hàng",
                                         LyDoChuyenDen = itemDonKH.LyDoChuyen,
                                         MaKTXM = "",
                                         NgayXuLy = "",
                                         KetQua = "",
                                         MaChuyen = "",
                                         LyDoChuyenDi = ""
                                     };
                    ///Bảng DCBD
                    var queryDCBD = from itemDCBD in db.DCBDs
                                    join itemDonKH in db.DonKHs on itemDCBD.MaDCBD equals itemDonKH.MaDon
                                    join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                    where itemDCBD.Nhan == false && itemDCBD.MaChuyen == "KTXM"
                                    select new
                                    {
                                        itemDonKH.MaDon,
                                        itemLoaiDon.TenLD,
                                        itemDonKH.CreateDate,
                                        itemDonKH.DanhBo,
                                        itemDonKH.HoTen,
                                        itemDonKH.DiaChi,
                                        itemDonKH.NoiDung,
                                        MaNoiChuyenDen = itemDCBD.MaDCBD,
                                        NoiChuyenDen = "Điều Chỉnh Biến Động",
                                        LyDoChuyenDen = itemDCBD.LyDoChuyen,
                                        MaKTXM = "",
                                        NgayXuLy = "",
                                        KetQua = "",
                                        MaChuyen = "",
                                        LyDoChuyenDi = ""
                                    };
                    //if (queryDCBD.Count() > 0)
                    //    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonKH.Union(queryDCBD));
                    //else
                    //    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonKH);
                    DataTable tableDonKH = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonKH);
                    DataTable tableDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDCBD);
                    tableDonKH.Merge(tableDCBD);
                    return tableDonKH;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public KTXM getKTXMbyID(decimal MaKTXM)
        {
            try
            {
                return db.KTXMs.SingleOrDefault(itemKTXM => itemKTXM.MaKTXM == MaKTXM);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra Đơn KH có được KTXM xử lý hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns>true/có</returns>
        public bool CheckKTMXbyMaDon(decimal MaDon)
        {
            try
            {
                if (db.KTXMs.Any(itemKTXM => itemKTXM.MaDon == MaDon))
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
        /// Kiểm tra Đơn Tổ Xử Lý có được KTXM xử lý hay chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns>true/có</returns>
        public bool CheckKTMXbyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                if (db.KTXMs.Any(itemKTXM => itemKTXM.MaDonTXL == MaDonTXL))
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
        /// Lấy KTXM bằng MaDon
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public KTXM getKTXMbyMaDon(decimal MaDon)
        {
            try
            {
                return db.KTXMs.SingleOrDefault(itemKTXM => itemKTXM.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy KTXM bằng MaDon Tổ Xử Lý
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns></returns>
        public KTXM getKTXMbyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                return db.KTXMs.SingleOrDefault(itemKTXM => itemKTXM.MaDonTXL == MaDonTXL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy thông tin Đơn KH
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="MaNoiChuyenDen"></param>
        /// <param name="NoiChuyenDen"></param>
        /// <param name="LyDoChuyenDen"></param>
        public void GetInfobyMaDon(decimal MaDon, out string MaNoiChuyenDen, out string NoiChuyenDen, out string LyDoChuyenDen)
        {
            MaNoiChuyenDen = "";
            NoiChuyenDen = "";
            LyDoChuyenDen = "";
            if (db.DonKHs.Any(itemDonKH => itemDonKH.MaDon == MaDon && itemDonKH.Nhan == false))
            {
                MaNoiChuyenDen = db.DonKHs.SingleOrDefault(itemDonKH => itemDonKH.MaDon == MaDon && itemDonKH.Nhan == false).MaDon.ToString();
                NoiChuyenDen = "Khách Hàng";
                LyDoChuyenDen = db.DonKHs.SingleOrDefault(itemDonKH => itemDonKH.MaDon == MaDon && itemDonKH.Nhan == false).LyDoChuyen;
            }
        }

        #endregion

        #region CTKTXM (Chi Tiết Kiểm Tra Xác Minh)

        /// <summary>
        /// Lấy Danh Sách Tất Cả CTKTXM chỉ có quyền quản lý được dùng hàm này
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCTKTXM()
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.ToXuLy==false
                                orderby itemCTKTXM.CreateDate descending
                                select new
                                {
                                    itemCTKTXM.KTXM.ToXuLy,
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    itemCTKTXM.NgayKTXM,
                                    CreateBy = itemUser.HoTen,
                                };

                    var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.KTXM.ToXuLy == true
                                       orderby itemCTKTXM.CreateDate descending
                                      select new
                                      {
                                          itemCTKTXM.KTXM.ToXuLy,
                                          itemCTKTXM.MaCTKTXM,
                                          MaDon=itemCTKTXM.KTXM.MaDonTXL,
                                          itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.HoTen,
                                          itemCTKTXM.DiaChi,
                                          itemCTKTXM.NoiDungKiemTra,
                                          itemCTKTXM.NgayKTXM,
                                          CreateBy = itemUser.HoTen,
                                      };
                    DataTable dt= KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonKH);
                    dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonTXL));
                    return dt;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByMaDon(decimal MaDon)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.KTXM.ToXuLy == false && itemCTKTXM.KTXM.MaDon==MaDon
                                      select new
                                      {
                                          itemCTKTXM.KTXM.ToXuLy,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.KTXM.MaDon,
                                          itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.HoTen,
                                          itemCTKTXM.DiaChi,
                                          itemCTKTXM.NoiDungKiemTra,
                                          itemCTKTXM.NgayKTXM,
                                          CreateBy = itemUser.HoTen,
                                          itemUser.MaU,
                                      };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonKH.Distinct());
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByMaDons(decimal TuMaDon, decimal DenMaDon)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.KTXM.ToXuLy == false && itemCTKTXM.KTXM.MaDon >= TuMaDon && itemCTKTXM.KTXM.MaDon <= DenMaDon
                                      select new
                                      {
                                          itemCTKTXM.KTXM.ToXuLy,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.KTXM.MaDon,
                                          itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.HoTen,
                                          itemCTKTXM.DiaChi,
                                          itemCTKTXM.NoiDungKiemTra,
                                          itemCTKTXM.NgayKTXM,
                                          CreateBy = itemUser.HoTen,
                                          itemUser.MaU,
                                      };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonKH.Distinct());
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByMaDonTXL(decimal MaDonTXL)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                       join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                       where itemCTKTXM.KTXM.ToXuLy == true && itemCTKTXM.KTXM.MaDonTXL == MaDonTXL
                                       select new
                                       {
                                           itemCTKTXM.KTXM.ToXuLy,
                                           itemCTKTXM.MaCTKTXM,
                                           MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                           itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                           itemCTKTXM.DanhBo,
                                           itemCTKTXM.HoTen,
                                           itemCTKTXM.DiaChi,
                                           itemCTKTXM.NoiDungKiemTra,
                                           itemCTKTXM.NgayKTXM,
                                           CreateBy = itemUser.HoTen,
                                       };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonTXL.Distinct());
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByDanhBo(string DanhBo)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.KTXM.ToXuLy == false && itemCTKTXM.DanhBo==DanhBo
                                      orderby itemCTKTXM.NgayKTXM descending
                                      select new
                                      {
                                          itemCTKTXM.KTXM.ToXuLy,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.KTXM.MaDon,
                                          itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.HoTen,
                                          itemCTKTXM.DiaChi,
                                          itemCTKTXM.NoiDungKiemTra,
                                          itemCTKTXM.NgayKTXM,
                                          CreateBy = itemUser.HoTen,
                                          itemUser.MaU,
                                      };

                    var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                       join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                       where itemCTKTXM.KTXM.ToXuLy == true && itemCTKTXM.DanhBo == DanhBo
                                       orderby itemCTKTXM.NgayKTXM descending
                                       select new
                                       {
                                           itemCTKTXM.KTXM.ToXuLy,
                                           itemCTKTXM.MaCTKTXM,
                                           MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                           itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                           itemCTKTXM.DanhBo,
                                           itemCTKTXM.HoTen,
                                           itemCTKTXM.DiaChi,
                                           itemCTKTXM.NoiDungKiemTra,
                                           itemCTKTXM.NgayKTXM,
                                           CreateBy = itemUser.HoTen,
                                           itemUser.MaU,
                                       };
                    DataTable dt = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonKH.Distinct());
                    dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonTXL.Distinct()));
                    return dt;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByDate(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.KTXM.ToXuLy == false && itemCTKTXM.NgayKTXM.Value.Date==TuNgay.Date
                                      orderby itemCTKTXM.NgayKTXM descending
                                      select new
                                      {
                                          itemCTKTXM.KTXM.ToXuLy,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.KTXM.MaDon,
                                          itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.HoTen,
                                          itemCTKTXM.DiaChi,
                                          itemCTKTXM.NoiDungKiemTra,
                                          itemCTKTXM.NgayKTXM,
                                          CreateBy = itemUser.HoTen,
                                          itemUser.MaU,
                                      };

                    var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                       join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                       where itemCTKTXM.KTXM.ToXuLy == true && itemCTKTXM.NgayKTXM.Value.Date == TuNgay.Date
                                       orderby itemCTKTXM.NgayKTXM descending
                                       select new
                                       {
                                           itemCTKTXM.KTXM.ToXuLy,
                                           itemCTKTXM.MaCTKTXM,
                                           MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                           itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                           itemCTKTXM.DanhBo,
                                           itemCTKTXM.HoTen,
                                           itemCTKTXM.DiaChi,
                                           itemCTKTXM.NoiDungKiemTra,
                                           itemCTKTXM.NgayKTXM,
                                           CreateBy = itemUser.HoTen,
                                           itemUser.MaU,
                                       };
                    DataTable dt = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonKH.Distinct());
                    dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonTXL.Distinct()));
                    return dt;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByDates(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.KTXM.ToXuLy == false && itemCTKTXM.NgayKTXM.Value.Date>=TuNgay.Date&&itemCTKTXM.NgayKTXM.Value.Date<=DenNgay.Date
                                      orderby itemCTKTXM.NgayKTXM descending
                                      select new
                                      {
                                          itemCTKTXM.KTXM.ToXuLy,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.KTXM.MaDon,
                                          itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.HoTen,
                                          itemCTKTXM.DiaChi,
                                          itemCTKTXM.NoiDungKiemTra,
                                          itemCTKTXM.NgayKTXM,
                                          CreateBy = itemUser.HoTen,
                                          itemUser.MaU,
                                      };

                    var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                       join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                       where itemCTKTXM.KTXM.ToXuLy == true && itemCTKTXM.NgayKTXM.Value.Date >= TuNgay.Date && itemCTKTXM.NgayKTXM.Value.Date <= DenNgay.Date
                                       orderby itemCTKTXM.NgayKTXM descending
                                       select new
                                       {
                                           itemCTKTXM.KTXM.ToXuLy,
                                           itemCTKTXM.MaCTKTXM,
                                           MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                           itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                           itemCTKTXM.DanhBo,
                                           itemCTKTXM.HoTen,
                                           itemCTKTXM.DiaChi,
                                           itemCTKTXM.NoiDungKiemTra,
                                           itemCTKTXM.NgayKTXM,
                                           CreateBy = itemUser.HoTen,
                                           itemUser.MaU,
                                       };
                    DataTable dt = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonKH.Distinct());
                    dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonTXL.Distinct()));
                    return dt;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXM_TXL()
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    var query = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDonTXL != null
                                orderby itemCTKTXM.KTXM.MaDonTXL ascending
                                select new
                                {
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.KTXM.ToXuLy,
                                    MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    itemCTKTXM.NgayKTXM,
                                    CreateBy = itemUser.HoTen,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách CTKTXM theo MaDon
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public DataTable LoadDSCTKTXM(decimal MaDon)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    var query = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDon == MaDon
                                orderby itemCTKTXM.KTXM.MaDon ascending
                                select new
                                {
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    itemCTKTXM.NgayKTXM,
                                    CreateBy = itemUser.HoTen,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách CTKTXM theo User
        /// </summary>
        /// <param name="MaUser"></param>
        /// <returns></returns>
        public DataTable LoadDSCTKTXM(int MaUser)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.ToXuLy == false && itemCTKTXM.CreateBy == MaUser
                                orderby itemCTKTXM.CreateDate descending
                                select new
                                {
                                    itemCTKTXM.KTXM.ToXuLy,
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    itemCTKTXM.NgayKTXM,
                                    CreateBy = itemUser.HoTen,
                                };

                    var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.ToXuLy == true && itemCTKTXM.CreateBy == MaUser
                                orderby itemCTKTXM.CreateDate descending
                                select new
                                {
                                    itemCTKTXM.KTXM.ToXuLy,
                                    itemCTKTXM.MaCTKTXM,
                                    MaDon=itemCTKTXM.KTXM.MaDonTXL,
                                    itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    itemCTKTXM.NgayKTXM,
                                    CreateBy = itemUser.HoTen,
                                };
                    DataTable dt= KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonKH);
                    dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonTXL));
                    return dt;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByMaDon(int MaUser,decimal MaDon)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.KTXM.ToXuLy == false && itemCTKTXM.CreateBy==MaUser &&itemCTKTXM.KTXM.MaDon == MaDon
                                      select new
                                      {
                                          itemCTKTXM.KTXM.ToXuLy,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.KTXM.MaDon,
                                          itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.HoTen,
                                          itemCTKTXM.DiaChi,
                                          itemCTKTXM.NoiDungKiemTra,
                                          itemCTKTXM.NgayKTXM,
                                          CreateBy = itemUser.HoTen,
                                          itemUser.MaU,
                                      };

                    var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                       join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                       where itemCTKTXM.KTXM.ToXuLy == true && itemCTKTXM.CreateBy == MaUser && itemCTKTXM.KTXM.MaDonTXL == MaDon
                                       select new
                                       {
                                           itemCTKTXM.KTXM.ToXuLy,
                                           itemCTKTXM.MaCTKTXM,
                                           MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                           itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                           itemCTKTXM.DanhBo,
                                           itemCTKTXM.HoTen,
                                           itemCTKTXM.DiaChi,
                                           itemCTKTXM.NoiDungKiemTra,
                                           itemCTKTXM.NgayKTXM,
                                           CreateBy = itemUser.HoTen,
                                           itemUser.MaU,
                                       };
                    DataTable dt = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonKH.Distinct());
                    dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonTXL.Distinct()));
                    return dt;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByMaDons(int MaUser, decimal TuMaDon,decimal DenMaDon)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.KTXM.ToXuLy == false && itemCTKTXM.CreateBy == MaUser && itemCTKTXM.KTXM.MaDon >= TuMaDon && itemCTKTXM.KTXM.MaDon <= DenMaDon
                                      select new
                                      {
                                          itemCTKTXM.KTXM.ToXuLy,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.KTXM.MaDon,
                                          itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.HoTen,
                                          itemCTKTXM.DiaChi,
                                          itemCTKTXM.NoiDungKiemTra,
                                          itemCTKTXM.NgayKTXM,
                                          CreateBy = itemUser.HoTen,
                                          itemUser.MaU,
                                      };

                    var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                       join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                       where itemCTKTXM.KTXM.ToXuLy == true && itemCTKTXM.CreateBy == MaUser && itemCTKTXM.KTXM.MaDonTXL >= TuMaDon && itemCTKTXM.KTXM.MaDonTXL<= DenMaDon
                                       select new
                                       {
                                           itemCTKTXM.KTXM.ToXuLy,
                                           itemCTKTXM.MaCTKTXM,
                                           MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                           itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                           itemCTKTXM.DanhBo,
                                           itemCTKTXM.HoTen,
                                           itemCTKTXM.DiaChi,
                                           itemCTKTXM.NoiDungKiemTra,
                                           itemCTKTXM.NgayKTXM,
                                           CreateBy = itemUser.HoTen,
                                           itemUser.MaU,
                                       };
                    DataTable dt = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonKH.Distinct());
                    dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonTXL.Distinct()));
                    return dt;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByDanhBo(int MaUser, string DanhBo)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.KTXM.ToXuLy == false && itemCTKTXM.CreateBy == MaUser && itemCTKTXM.DanhBo == DanhBo
                                      orderby itemCTKTXM.NgayKTXM descending
                                      select new
                                      {
                                          itemCTKTXM.KTXM.ToXuLy,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.KTXM.MaDon,
                                          itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.HoTen,
                                          itemCTKTXM.DiaChi,
                                          itemCTKTXM.NoiDungKiemTra,
                                          itemCTKTXM.NgayKTXM,
                                          CreateBy = itemUser.HoTen,
                                          itemUser.MaU,
                                      };

                    var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                       join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                       where itemCTKTXM.KTXM.ToXuLy == true && itemCTKTXM.CreateBy == MaUser && itemCTKTXM.DanhBo == DanhBo
                                       orderby itemCTKTXM.NgayKTXM descending
                                       select new
                                       {
                                           itemCTKTXM.KTXM.ToXuLy,
                                           itemCTKTXM.MaCTKTXM,
                                           MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                           itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                           itemCTKTXM.DanhBo,
                                           itemCTKTXM.HoTen,
                                           itemCTKTXM.DiaChi,
                                           itemCTKTXM.NoiDungKiemTra,
                                           itemCTKTXM.NgayKTXM,
                                           CreateBy = itemUser.HoTen,
                                           itemUser.MaU,
                                       };
                    DataTable dt = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonKH.Distinct());
                    dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonTXL.Distinct()));
                    return dt;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByDate(int MaUser, DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.KTXM.ToXuLy == false && itemCTKTXM.CreateBy == MaUser && itemCTKTXM.NgayKTXM.Value.Date == TuNgay.Date
                                      orderby itemCTKTXM.NgayKTXM descending
                                      select new
                                      {
                                          itemCTKTXM.KTXM.ToXuLy,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.KTXM.MaDon,
                                          itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.HoTen,
                                          itemCTKTXM.DiaChi,
                                          itemCTKTXM.NoiDungKiemTra,
                                          itemCTKTXM.NgayKTXM,
                                          CreateBy = itemUser.HoTen,
                                          itemUser.MaU,
                                      };

                    var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                       join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                       where itemCTKTXM.KTXM.ToXuLy == true && itemCTKTXM.CreateBy == MaUser && itemCTKTXM.NgayKTXM.Value.Date == TuNgay.Date
                                       orderby itemCTKTXM.NgayKTXM descending
                                       select new
                                       {
                                           itemCTKTXM.KTXM.ToXuLy,
                                           itemCTKTXM.MaCTKTXM,
                                           MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                           itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                           itemCTKTXM.DanhBo,
                                           itemCTKTXM.HoTen,
                                           itemCTKTXM.DiaChi,
                                           itemCTKTXM.NoiDungKiemTra,
                                           itemCTKTXM.NgayKTXM,
                                           CreateBy = itemUser.HoTen,
                                           itemUser.MaU,
                                       };
                    DataTable dt = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonKH.Distinct());
                    dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonTXL.Distinct()));
                    return dt;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMByDates(int MaUser, DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    var query_DonKH = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.KTXM.ToXuLy == false && itemCTKTXM.CreateBy == MaUser && itemCTKTXM.NgayKTXM.Value.Date >= TuNgay.Date && itemCTKTXM.NgayKTXM.Value.Date <= DenNgay.Date
                                      orderby itemCTKTXM.NgayKTXM descending
                                      select new
                                      {
                                          itemCTKTXM.KTXM.ToXuLy,
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.KTXM.MaDon,
                                          itemCTKTXM.KTXM.DonKH.LoaiDon.TenLD,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.HoTen,
                                          itemCTKTXM.DiaChi,
                                          itemCTKTXM.NoiDungKiemTra,
                                          itemCTKTXM.NgayKTXM,
                                          CreateBy = itemUser.HoTen,
                                          itemUser.MaU,
                                      };

                    var query_DonTXL = from itemCTKTXM in db.CTKTXMs
                                       join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                       where itemCTKTXM.KTXM.ToXuLy == true && itemCTKTXM.CreateBy == MaUser && itemCTKTXM.NgayKTXM.Value.Date >= TuNgay.Date && itemCTKTXM.NgayKTXM.Value.Date <= DenNgay.Date
                                       orderby itemCTKTXM.NgayKTXM descending
                                       select new
                                       {
                                           itemCTKTXM.KTXM.ToXuLy,
                                           itemCTKTXM.MaCTKTXM,
                                           MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                           itemCTKTXM.KTXM.DonTXL.LoaiDonTXL.TenLD,
                                           itemCTKTXM.DanhBo,
                                           itemCTKTXM.HoTen,
                                           itemCTKTXM.DiaChi,
                                           itemCTKTXM.NoiDungKiemTra,
                                           itemCTKTXM.NgayKTXM,
                                           CreateBy = itemUser.HoTen,
                                           itemUser.MaU,
                                       };
                    DataTable dt = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonKH.Distinct());
                    dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query_DonTXL.Distinct()));
                    return dt;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXM_TXL(int MaUser)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    var query = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDonTXL != null && itemCTKTXM.CreateBy == MaUser
                                orderby itemCTKTXM.KTXM.MaDonTXL ascending
                                select new
                                {
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.KTXM.ToXuLy,
                                    MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    itemCTKTXM.NgayKTXM,
                                    CreateBy = itemUser.HoTen,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách CTKTXM theo Mã Đơn Khách Hàng & User. Nếu User có quyền quản lý KTXM thì được xem hết CTKTXM của Mã Đơn
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="MaUser"></param>
        /// <returns></returns>
        public DataTable LoadDSCTKTXM(decimal MaDon, int MaUser)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    var query = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDon == MaDon
                                orderby itemCTKTXM.KTXM.MaDon ascending
                                select new
                                {
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    itemCTKTXM.CreateDate,
                                    CreateBy = itemUser.HoTen,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                    if (CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
                    {
                        var query = from itemCTKTXM in db.CTKTXMs
                                    join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                    where itemCTKTXM.KTXM.MaDon == MaDon && itemCTKTXM.CreateBy == MaUser
                                    orderby itemCTKTXM.KTXM.MaDon ascending
                                    select new
                                    {
                                        itemCTKTXM.MaCTKTXM,
                                        itemCTKTXM.KTXM.MaDon,
                                        itemCTKTXM.DanhBo,
                                        itemCTKTXM.HoTen,
                                        itemCTKTXM.DiaChi,
                                        itemCTKTXM.NoiDungKiemTra,
                                        itemCTKTXM.CreateDate,
                                        CreateBy = itemUser.HoTen,
                                    };
                        return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách CTKTXM theo Mã Đơn Tổ Xử Lý & User
        /// Nếu User có quyền quản lý KTXM thì được xem hết CTKTXM của Mã Đơn
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <param name="MaUser"></param>
        /// <returns></returns>
        public DataTable LoadDSCTKTXM_TXL(decimal MaDonTXL, int MaUser)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    var query = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDonTXL == MaDonTXL
                                orderby itemCTKTXM.KTXM.MaDonTXL ascending
                                select new
                                {
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.KTXM.ToXuLy,
                                    MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    itemCTKTXM.CreateDate,
                                    CreateBy = itemUser.HoTen,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                    if (CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
                    {
                        var query = from itemCTKTXM in db.CTKTXMs
                                    join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                    where itemCTKTXM.KTXM.MaDonTXL == MaDonTXL && itemCTKTXM.CreateBy == MaUser
                                    orderby itemCTKTXM.KTXM.MaDonTXL ascending
                                    select new
                                    {
                                        itemCTKTXM.MaCTKTXM,
                                        itemCTKTXM.KTXM.ToXuLy,
                                        MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                        itemCTKTXM.DanhBo,
                                        itemCTKTXM.HoTen,
                                        itemCTKTXM.DiaChi,
                                        itemCTKTXM.NoiDungKiemTra,
                                        itemCTKTXM.CreateDate,
                                        CreateBy = itemUser.HoTen, 
                                    };
                        return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách CTKTXM theo Ngày Xử Lý & User. Hàm này phục vụ cho Thống Kê Biên Bản KTXM
        /// </summary>
        /// <param name="MaUser"></param>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        //public DataTable LoadDSCTKTXM(int MaUser, DateTime TuNgay)
        //{
        //    try
        //    {
        //        if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
        //        {
        //            var query = from itemCTKTXM in db.CTKTXMs
        //                        //join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
        //                        where itemCTKTXM.NgayKTXM.Value.Date == TuNgay.Date
        //                                && ((itemCTKTXM.HienTrangKiemTra.Contains("bồi thường") && !itemCTKTXM.HienTrangKiemTra.Contains("không"))
        //                                || itemCTKTXM.HienTrangKiemTra.Contains("gian lận")
        //                                || itemCTKTXM.HienTrangKiemTra=="BB chạy ngược"
        //                                || itemCTKTXM.HienTrangKiemTra == "BB tái lập Danh Bộ"
        //                                || itemCTKTXM.HienTrangKiemTra == "BB hủy Danh Bộ"
        //                                )
        //                        //orderby itemCTKTXM.KTXM.MaDon ascending
        //                        select new
        //                        {
        //                            LoaiBienBan=itemCTKTXM.HienTrangKiemTra,
        //                            itemCTKTXM.DanhBo,
        //                            itemCTKTXM.KTXM.MaDon,
        //                            itemCTKTXM.KTXM.MaDonTXL,
        //                            itemCTKTXM.LapBangGia,
        //                            itemCTKTXM.DongTienBoiThuong,
        //                            itemCTKTXM.ChuyenLapTBCat,
        //                            //CreateBy = itemUser.HoTen,
        //                        };
        //            return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
        //        }
        //        else
        //            if (CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
        //            {
        //                var query = from itemCTKTXM in db.CTKTXMs
        //                            //join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
        //                            where itemCTKTXM.NgayKTXM.Value.Date == TuNgay.Date && itemCTKTXM.CreateBy == MaUser
        //                                    && ((itemCTKTXM.HienTrangKiemTra.Contains("bồi thường") && !itemCTKTXM.HienTrangKiemTra.Contains("không"))
        //                                    || itemCTKTXM.HienTrangKiemTra.Contains("gian lận")
        //                                    || itemCTKTXM.HienTrangKiemTra == "BB chạy ngược"
        //                                    || itemCTKTXM.HienTrangKiemTra == "BB tái lập Danh Bộ"
        //                                    || itemCTKTXM.HienTrangKiemTra == "BB hủy Danh Bộ"
        //                                    )
        //                            //orderby itemCTKTXM.KTXM.MaDon ascending
        //                            select new
        //                            {
        //                                LoaiBienBan = itemCTKTXM.HienTrangKiemTra,
        //                                itemCTKTXM.DanhBo,
        //                                itemCTKTXM.KTXM.MaDon,
        //                                itemCTKTXM.KTXM.MaDonTXL,
        //                                itemCTKTXM.LapBangGia,
        //                                itemCTKTXM.DongTienBoiThuong,
        //                                itemCTKTXM.ChuyenLapTBCat,
        //                                //CreateBy = itemUser.HoTen,
        //                            };
        //                return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return null;
        //            }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}
        public DataTable LoadDSCTKTXM(int MaUser, DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    var query = from itemCTKTXM in db.CTKTXMs
                                //join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.NgayKTXM.Value.Date == TuNgay.Date
                                //orderby itemCTKTXM.KTXM.MaDon ascending
                                select new
                                {
                                    LoaiBienBan = itemCTKTXM.HienTrangKiemTra,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.KTXM.MaDonTXL,
                                    itemCTKTXM.LapBangGia,
                                    itemCTKTXM.DongTienBoiThuong,
                                    itemCTKTXM.ChuyenLapTBCat,
                                    //CreateBy = itemUser.HoTen,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                    if (CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
                    {
                        var query = from itemCTKTXM in db.CTKTXMs
                                    //join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                    where itemCTKTXM.NgayKTXM.Value.Date == TuNgay.Date && itemCTKTXM.CreateBy == MaUser
                                    //orderby itemCTKTXM.KTXM.MaDon ascending
                                    select new
                                    {
                                        LoaiBienBan = itemCTKTXM.HienTrangKiemTra,
                                        itemCTKTXM.DanhBo,
                                        itemCTKTXM.KTXM.MaDon,
                                        itemCTKTXM.KTXM.MaDonTXL,
                                        itemCTKTXM.LapBangGia,
                                        itemCTKTXM.DongTienBoiThuong,
                                        itemCTKTXM.ChuyenLapTBCat,
                                        //CreateBy = itemUser.HoTen,
                                    };
                        return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách CTKTXM theo Khoảng Thời Gian Xử Lý & User. Hàm này phục vụ cho Thống Kê Biên Bản KTXM
        /// </summary>
        /// <param name="MaUser"></param>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        //public DataTable LoadDSCTKTXM(int MaUser, DateTime TuNgay, DateTime DenNgay)
        //{
        //    try
        //    {
        //        if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
        //        {
        //            var query = from itemCTKTXM in db.CTKTXMs
        //                        //join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
        //                        where itemCTKTXM.NgayKTXM.Value.Date >= TuNgay.Date && itemCTKTXM.NgayKTXM.Value.Date <= DenNgay.Date
        //                                && ((itemCTKTXM.HienTrangKiemTra.Contains("bồi thường") && !itemCTKTXM.HienTrangKiemTra.Contains("không"))
        //                                || itemCTKTXM.HienTrangKiemTra.Contains("gian lận")
        //                                || itemCTKTXM.HienTrangKiemTra == "BB chạy ngược"
        //                                || itemCTKTXM.HienTrangKiemTra == "BB tái lập Danh Bộ"
        //                                || itemCTKTXM.HienTrangKiemTra == "BB hủy Danh Bộ"
        //                                )
        //                        //orderby itemCTKTXM.KTXM.MaDon ascending
        //                        select new
        //                        {
        //                            LoaiBienBan=itemCTKTXM.HienTrangKiemTra,
        //                            itemCTKTXM.DanhBo,
        //                            itemCTKTXM.KTXM.MaDon,
        //                            itemCTKTXM.KTXM.MaDonTXL,
        //                            itemCTKTXM.LapBangGia,
        //                            itemCTKTXM.DongTienBoiThuong,
        //                            itemCTKTXM.ChuyenLapTBCat,
        //                            //CreateBy = itemUser.HoTen,
        //                        };
        //            return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
        //        }
        //        else
        //            if (CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
        //            {
        //                var query = from itemCTKTXM in db.CTKTXMs
        //                            //join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
        //                            where itemCTKTXM.NgayKTXM.Value.Date >= TuNgay.Date && itemCTKTXM.NgayKTXM.Value <= DenNgay.Date && itemCTKTXM.CreateBy == MaUser
        //                                    && ((itemCTKTXM.HienTrangKiemTra.Contains("bồi thường") && !itemCTKTXM.HienTrangKiemTra.Contains("không"))
        //                                    || itemCTKTXM.HienTrangKiemTra.Contains("gian lận")
        //                                    || itemCTKTXM.HienTrangKiemTra == "BB chạy ngược"
        //                                    || itemCTKTXM.HienTrangKiemTra == "BB tái lập Danh Bộ"
        //                                    || itemCTKTXM.HienTrangKiemTra == "BB hủy Danh Bộ"
        //                                    )
        //                            //orderby itemCTKTXM.KTXM.MaDon ascending
        //                            select new
        //                            {
        //                                LoaiBienBan = itemCTKTXM.HienTrangKiemTra,
        //                                itemCTKTXM.DanhBo,
        //                                itemCTKTXM.KTXM.MaDon,
        //                                itemCTKTXM.KTXM.MaDonTXL,
        //                                itemCTKTXM.LapBangGia,
        //                                itemCTKTXM.DongTienBoiThuong,
        //                                itemCTKTXM.ChuyenLapTBCat,
        //                                //CreateBy = itemUser.HoTen,
        //                            };
        //                return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return null;
        //            }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}
        public DataTable LoadDSCTKTXM(int MaUser, DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    var query = from itemCTKTXM in db.CTKTXMs
                                //join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.NgayKTXM.Value.Date >= TuNgay.Date && itemCTKTXM.NgayKTXM.Value.Date <= DenNgay.Date
                                //orderby itemCTKTXM.KTXM.MaDon ascending
                                select new
                                {
                                    LoaiBienBan = itemCTKTXM.HienTrangKiemTra,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.KTXM.MaDonTXL,
                                    itemCTKTXM.LapBangGia,
                                    itemCTKTXM.DongTienBoiThuong,
                                    itemCTKTXM.ChuyenLapTBCat,
                                    //CreateBy = itemUser.HoTen,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                    if (CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
                    {
                        var query = from itemCTKTXM in db.CTKTXMs
                                    //join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                    where itemCTKTXM.NgayKTXM.Value.Date >= TuNgay.Date && itemCTKTXM.NgayKTXM.Value <= DenNgay.Date && itemCTKTXM.CreateBy == MaUser
                                    //orderby itemCTKTXM.KTXM.MaDon ascending
                                    select new
                                    {
                                        LoaiBienBan = itemCTKTXM.HienTrangKiemTra,
                                        itemCTKTXM.DanhBo,
                                        itemCTKTXM.KTXM.MaDon,
                                        itemCTKTXM.KTXM.MaDonTXL,
                                        itemCTKTXM.LapBangGia,
                                        itemCTKTXM.DongTienBoiThuong,
                                        itemCTKTXM.ChuyenLapTBCat,
                                        //CreateBy = itemUser.HoTen,
                                    };
                        return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách CTKTXM theo Danh Bộ & User. Hàm này phục vụ cho Cập Nhật Đóng Tiền Bồi Thường KTXM
        /// </summary>
        /// <param name="DanhBo"></param>
        /// <param name="MaUser"></param>
        /// <returns></returns>
        public DataTable LoadDSCTKTXM(string DanhBo, int MaUser)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    var queryKH = from itemCTKTXM in db.CTKTXMs
                                  join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                  where itemCTKTXM.DanhBo == DanhBo && itemCTKTXM.KTXM.ToXuLy == false
                                  orderby itemCTKTXM.KTXM.MaDon ascending
                                  select new
                                  {
                                      itemCTKTXM.MaCTKTXM,
                                      itemCTKTXM.KTXM.ToXuLy,
                                      itemCTKTXM.KTXM.MaDon,
                                      itemCTKTXM.DanhBo,
                                      itemCTKTXM.HoTen,
                                      itemCTKTXM.DiaChi,
                                      itemCTKTXM.NoiDungKiemTra,
                                      itemCTKTXM.CreateDate,
                                      CreateBy = itemUser.HoTen,
                                  };

                    var queryTXL = from itemCTKTXM in db.CTKTXMs
                                   join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                   where itemCTKTXM.DanhBo == DanhBo && itemCTKTXM.KTXM.ToXuLy == true
                                   orderby itemCTKTXM.KTXM.MaDonTXL ascending
                                   select new
                                   {
                                       itemCTKTXM.MaCTKTXM,
                                       itemCTKTXM.KTXM.ToXuLy,
                                       MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                       itemCTKTXM.DanhBo,
                                       itemCTKTXM.HoTen,
                                       itemCTKTXM.DiaChi,
                                       itemCTKTXM.NoiDungKiemTra,
                                       itemCTKTXM.CreateDate,
                                       CreateBy = itemUser.HoTen,
                                   };
                    DataTable dt = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKH);
                    dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTXL));
                    return dt;
                }
                else
                    if (CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
                    {
                        var queryKH = from itemCTKTXM in db.CTKTXMs
                                      join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                      where itemCTKTXM.DanhBo == DanhBo && itemCTKTXM.KTXM.ToXuLy == false && itemCTKTXM.CreateBy == MaUser
                                      orderby itemCTKTXM.KTXM.MaDon ascending
                                      select new
                                      {
                                          itemCTKTXM.MaCTKTXM,
                                          itemCTKTXM.KTXM.ToXuLy,
                                          itemCTKTXM.KTXM.MaDon,
                                          itemCTKTXM.DanhBo,
                                          itemCTKTXM.HoTen,
                                          itemCTKTXM.DiaChi,
                                          itemCTKTXM.NoiDungKiemTra,
                                          itemCTKTXM.CreateDate,
                                          CreateBy = itemUser.HoTen,
                                      };

                        var queryTXL = from itemCTKTXM in db.CTKTXMs
                                       join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                       where itemCTKTXM.DanhBo == DanhBo && itemCTKTXM.KTXM.ToXuLy == true && itemCTKTXM.CreateBy == MaUser
                                       orderby itemCTKTXM.KTXM.MaDonTXL ascending
                                       select new
                                       {
                                           itemCTKTXM.MaCTKTXM,
                                           itemCTKTXM.KTXM.ToXuLy,
                                           MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                           itemCTKTXM.DanhBo,
                                           itemCTKTXM.HoTen,
                                           itemCTKTXM.DiaChi,
                                           itemCTKTXM.NoiDungKiemTra,
                                           itemCTKTXM.CreateDate,
                                           CreateBy = itemUser.HoTen,
                                       };
                        DataTable dt = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKH);
                        dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTXL));
                        return dt;
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemCTKTXM(CTKTXM ctktxm)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_CapNhat || CTaiKhoan.RoleKTXM_CapNhat)
                {
                    if (db.CTKTXMs.Count() > 0)
                    {
                        string ID = "MaCTKTXM";
                        string Table = "CTKTXM";
                        decimal MaCTKTXM = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaCTKTXM = db.CTKTXMs.Max(itemCTKTXM => itemCTKTXM.MaCTKTXM);
                        ctktxm.MaCTKTXM = getMaxNextIDTable(MaCTKTXM);
                    }
                    else
                        ctktxm.MaCTKTXM = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ctktxm.CreateDate = DateTime.Now;
                    ctktxm.CreateBy = CTaiKhoan.MaUser;
                    db.CTKTXMs.InsertOnSubmit(ctktxm);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTKTXMs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaCTKTXM(CTKTXM ctktxm)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    ctktxm.ModifyDate = DateTime.Now;
                    ctktxm.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    return true;
                }
                else
                    if (CTaiKhoan.RoleKTXM_CapNhat && ctktxm.CreateBy == CTaiKhoan.MaUser)
                    {
                        ctktxm.ModifyDate = DateTime.Now;
                        ctktxm.ModifyBy = CTaiKhoan.MaUser;
                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này không có quyền hoặc CTKTXM này không thuộc của bạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTKTXMs);
                        return false;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool XoaCTKTXM(CTKTXM ctktxm,int MaU)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    db.CTKTXMs.DeleteOnSubmit(ctktxm);
                    db.SubmitChanges();
                    return true;
                }
                else
                    if (CTaiKhoan.RoleKTXM_CapNhat && ctktxm.CreateBy == MaU)
                    {
                        db.CTKTXMs.DeleteOnSubmit(ctktxm);
                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này không có quyền hoặc CTKTXM này không thuộc của bạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTKTXMs);
                        return false;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public CTKTXM getCTKTXMbyID(decimal MaCTKTXM)
        {
            try
            {
                return db.CTKTXMs.SingleOrDefault(itemCTKTXM => itemCTKTXM.MaCTKTXM == MaCTKTXM);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public CTKTXM getCTKTXMbyMaDonKHDanhBo(decimal MaDonKH, string DanhBo)
        {
            try
            {
                return db.CTKTXMs.FirstOrDefault(itemCTKTXM => itemCTKTXM.KTXM.MaDon == MaDonKH && itemCTKTXM.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public CTKTXM getCTKTXMbyMaDonTXLDanhBo(decimal MaDonTXL, string DanhBo)
        {
            try
            {
                return db.CTKTXMs.FirstOrDefault(itemCTKTXM => itemCTKTXM.KTXM.MaDonTXL == MaDonTXL && itemCTKTXM.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra CTKTXM đã được tạo cho Mã Đơn Tổ Khách Hàng, Danh Bộ, Cùng Ngày chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <param name="NgayKTXM"></param>
        /// <returns></returns>
        public bool CheckCTKTXMbyMaDonDanhBo(decimal MaDon, string DanhBo, DateTime NgayKTXM)
        {
            try
            {
                return db.CTKTXMs.Any(itemCTKTXM => itemCTKTXM.KTXM.MaDon == MaDon && itemCTKTXM.DanhBo == DanhBo && itemCTKTXM.NgayKTXM == NgayKTXM);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra CTKTXM đã được tạo cho Mã Đơn Tổ Xử Lý, Danh Bộ, Cùng Ngày chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <param name="DanhBo"></param>
        /// <param name="NgayKTXM"></param>
        /// <returns></returns>
        public bool CheckCTKTXMbyMaDonDanhBo_TXL(decimal MaDonTXL, string DanhBo, DateTime NgayKTXM)
        {
            try
            {
                return db.CTKTXMs.Any(itemCTKTXM => itemCTKTXM.KTXM.MaDonTXL == MaDonTXL && itemCTKTXM.DanhBo == DanhBo && itemCTKTXM.NgayKTXM == NgayKTXM);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckCTKTXMbyID(decimal MaCTKTXM)
        {
            try
            {
                return db.CTKTXMs.Any(itemCTKTXM => itemCTKTXM.MaCTKTXM == MaCTKTXM);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable LoadDSCTKTXMbyNgayLapBangGia(int MaUser, DateTime NgayLapBangGia)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    var query = from itemCTKTXM in db.CTKTXMs
                                //join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.NgayLapBangGia.Value.Date == NgayLapBangGia.Date
                                //orderby itemCTKTXM.KTXM.MaDon ascending
                                select new
                                {
                                    LoaiBienBan = itemCTKTXM.HienTrangKiemTra,
                                    //itemCTKTXM.DanhBo,
                                    //itemCTKTXM.KTXM.MaDon,
                                    //itemCTKTXM.KTXM.MaDonTXL,
                                    itemCTKTXM.LapBangGia,
                                    itemCTKTXM.DongTienBoiThuong,
                                    itemCTKTXM.ChuyenLapTBCat,
                                    //CreateBy = itemUser.HoTen,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                    if (CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
                    {
                        var query = from itemCTKTXM in db.CTKTXMs
                                    //join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                    where itemCTKTXM.NgayLapBangGia.Value.Date == NgayLapBangGia.Date && itemCTKTXM.CreateBy == MaUser
                                    //orderby itemCTKTXM.KTXM.MaDon ascending
                                    select new
                                    {
                                        LoaiBienBan = itemCTKTXM.HienTrangKiemTra,
                                        //itemCTKTXM.DanhBo,
                                        //itemCTKTXM.KTXM.MaDon,
                                        //itemCTKTXM.KTXM.MaDonTXL,
                                        itemCTKTXM.LapBangGia,
                                        itemCTKTXM.DongTienBoiThuong,
                                        itemCTKTXM.ChuyenLapTBCat,
                                        //CreateBy = itemUser.HoTen,
                                    };
                        return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTKTXMbyNgayLapBangGia(int MaUser, DateTime TuNgayLapBangGia, DateTime DenNgayLapBangGia)
        {
            try
            {
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                {
                    var query = from itemCTKTXM in db.CTKTXMs
                                //join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.NgayLapBangGia.Value.Date >= TuNgayLapBangGia.Date && itemCTKTXM.NgayLapBangGia.Value.Date <= DenNgayLapBangGia.Date
                                //orderby itemCTKTXM.KTXM.MaDon ascending
                                select new
                                {
                                    LoaiBienBan = itemCTKTXM.HienTrangKiemTra,
                                    //itemCTKTXM.DanhBo,
                                    //itemCTKTXM.KTXM.MaDon,
                                    //itemCTKTXM.KTXM.MaDonTXL,
                                    itemCTKTXM.LapBangGia,
                                    itemCTKTXM.DongTienBoiThuong,
                                    itemCTKTXM.ChuyenLapTBCat,
                                    //CreateBy = itemUser.HoTen,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                    if (CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
                    {
                        var query = from itemCTKTXM in db.CTKTXMs
                                    //join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                    where itemCTKTXM.NgayLapBangGia.Value.Date >= TuNgayLapBangGia.Date && itemCTKTXM.NgayLapBangGia.Value <= DenNgayLapBangGia.Date && itemCTKTXM.CreateBy == MaUser
                                    //orderby itemCTKTXM.KTXM.MaDon ascending
                                    select new
                                    {
                                        LoaiBienBan = itemCTKTXM.HienTrangKiemTra,
                                        //itemCTKTXM.DanhBo,
                                        //itemCTKTXM.KTXM.MaDon,
                                        //itemCTKTXM.KTXM.MaDonTXL,
                                        itemCTKTXM.LapBangGia,
                                        itemCTKTXM.DongTienBoiThuong,
                                        itemCTKTXM.ChuyenLapTBCat,
                                        //CreateBy = itemUser.HoTen,
                                    };
                        return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public int countCTKTXMbyNgayLapBangGia(DateTime NgayLapBangGia)
        {
            try
            {
                return db.CTKTXMs.Count(itemCTKTXM => itemCTKTXM.LapBangGia == true && itemCTKTXM.NgayLapBangGia.Value.Date == NgayLapBangGia.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int countCTKTXMbyNgayLapBangGia(DateTime TuNgayLapBangGia, DateTime DenNgayLapBangGia)
        {
            try
            {
                return db.CTKTXMs.Count(itemCTKTXM => itemCTKTXM.LapBangGia == true && itemCTKTXM.NgayLapBangGia.Value.Date >= TuNgayLapBangGia.Date && itemCTKTXM.NgayLapBangGia.Value.Date <= DenNgayLapBangGia.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int countCTKTXMbyNgayDongTien(DateTime NgayDongTien)
        {
            try
            {
                return db.CTKTXMs.Count(itemCTKTXM => itemCTKTXM.DongTienBoiThuong == true && itemCTKTXM.NgayDongTien.Value.Date == NgayDongTien.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int countCTKTXMbyNgayDongTien(DateTime TuNgayDongTien, DateTime DenNgayDongTien)
        {
            try
            {
                return db.CTKTXMs.Count(itemCTKTXM => itemCTKTXM.DongTienBoiThuong == true && itemCTKTXM.NgayDongTien.Value.Date >= TuNgayDongTien.Date && itemCTKTXM.NgayDongTien.Value.Date <= DenNgayDongTien.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int countCTKTXMbyNgayChuyenLapTBCat(DateTime NgayChuyenLapTBCat)
        {
            try
            {
                return db.CTKTXMs.Count(itemCTKTXM => itemCTKTXM.ChuyenLapTBCat==true && itemCTKTXM.NgayChuyenLapTBCat.Value.Date == NgayChuyenLapTBCat.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int countCTKTXMbyNgayChuyenLapTBCat(DateTime TuNgayChuyenLapTBCat, DateTime DenNgayChuyenLapTBCat)
        {
            try
            {
                return db.CTKTXMs.Count(itemCTKTXM => itemCTKTXM.ChuyenLapTBCat == true && itemCTKTXM.NgayChuyenLapTBCat.Value.Date >= TuNgayChuyenLapTBCat.Date && itemCTKTXM.NgayChuyenLapTBCat.Value.Date <= DenNgayChuyenLapTBCat.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int countCTKTXMbyMaDon(decimal MaDon)
        {
            try
            {
                return db.CTKTXMs.Where(itemCTKTXM => itemCTKTXM.KTXM.MaDon == MaDon).Count();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        #endregion
    }
}

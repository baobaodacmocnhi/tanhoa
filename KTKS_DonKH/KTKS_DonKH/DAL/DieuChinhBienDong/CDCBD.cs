using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    class CDCBD : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng DCBD & CTDCBD & CTDCHD
        
        #region DCBD

        public DataSet LoadDSDCBDDaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    DataSet ds = new DataSet();
                    ///Table DCBD
                    var queryDCBD = from itemDCBD in db.DCBDs
                                join itemDonKH in db.DonKHs on itemDCBD.MaDon equals itemDonKH.MaDon
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
                                    MaNoiChuyenDen = itemDCBD.MaNoiChuyenDen,
                                    NoiChuyenDen = itemDCBD.NoiChuyenDen,
                                    LyDoChuyenDen = itemDCBD.LyDoChuyenDen,
                                    itemDCBD.MaDCBD,
                                    NgayXuLy = itemDCBD.CreateDate,
                                    itemDCBD.KetQua,
                                    itemDCBD.MaChuyen,
                                    LyDoChuyenDi = itemDCBD.LyDoChuyen
                                };
                    DataTable dtDCBD = new DataTable();
                    dtDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDCBD);
                    dtDCBD.TableName = "DCBD";
                    ds.Tables.Add(dtDCBD);

                    ///Table CTDCBD
                    var queryCTDCBD = from itemCTDCBD in db.CTDCBDs
                                 select itemCTDCBD;         

                    DataTable dtCTDCBD = new DataTable();
                    dtCTDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCBD);
                    dtCTDCBD.TableName = "CTDCBD";
                    ds.Tables.Add(dtCTDCBD);

                    if (dtDCBD.Rows.Count > 0 && dtCTDCBD.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết", ds.Tables["DCBD"].Columns["MaDCBD"], ds.Tables["CTDCBD"].Columns["MaDCBD"]);
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

        public DataTable LoadDSDCBDChuaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    ///Bảng DonKH
                    var queryDonKH = from itemDonKH in db.DonKHs
                                 join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                 where itemDonKH.Nhan == false && itemDonKH.MaChuyen == "DCBD"
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
                                     MaDCBD = "",
                                     NgayXuLy = "",
                                     KetQua = "",
                                     MaChuyen = "",
                                     LyDoChuyenDi = ""
                                 };
                    ///Bảng KTXM
                    var queryKTXM = from itemKTXM in db.KTXMs
                                 join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                 join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                 where itemKTXM.Nhan == false && itemKTXM.MaChuyen == "DCBD"
                                 select new
                                 {
                                     itemDonKH.MaDon,
                                     itemLoaiDon.TenLD,
                                     itemDonKH.CreateDate,
                                     itemDonKH.DanhBo,
                                     itemDonKH.HoTen,
                                     itemDonKH.DiaChi,
                                     itemDonKH.NoiDung,
                                     MaNoiChuyenDen = itemKTXM.MaKTXM,
                                     NoiChuyenDen = "Kiểm Tra Xác Minh",
                                     LyDoChuyenDen = itemKTXM.LyDoChuyen,
                                     MaDCBD = "",
                                     NgayXuLy = "",
                                     KetQua = "",
                                     MaChuyen = "",
                                     LyDoChuyenDi = ""
                                 };
                    //if (queryKTXM.Count() > 0)
                    //    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonKH.Union(queryKTXM));
                    //else
                    //    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonKH);
                    DataTable tableDonKH = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonKH);
                    DataTable tableKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM);
                    tableDonKH.Merge(tableKTXM);
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

        public bool CheckDCBDbyID(decimal MaDCBD)
        {
            try
            {
                if (db.DCBDs.Any(itemDCBD => itemDCBD.MaDCBD == MaDCBD))
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

        public bool ThemDCBD(DCBD dcbd)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    if (db.DCBDs.Count() > 0)
                    {
                        decimal MaDCBD = db.DCBDs.Max(itemDCBD => itemDCBD.MaDCBD);
                        dcbd.MaDCBD = getMaxNextIDTable(MaDCBD);
                    }
                    else
                        dcbd.MaDCBD = decimal.Parse(DateTime.Now.Year + "1");
                    dcbd.CreateDate = DateTime.Now;
                    dcbd.CreateBy = CTaiKhoan.TaiKhoan;
                    db.DCBDs.InsertOnSubmit(dcbd);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public decimal getMaxNextMaDCBD()
        {
            try
            {
                if (db.DCBDs.Count() > 0)
                {
                    decimal MaDCBD = db.DCBDs.Max(itemDCBD => itemDCBD.MaDCBD);
                    return getMaxNextIDTable(MaDCBD);
                }
                else
                    return decimal.Parse(DateTime.Now.Year + "1");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public decimal getMaxMaDCBD()
        {
            try
            {
                return db.DCBDs.Max(itemDCBD => itemDCBD.MaDCBD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        #endregion

        #region CTDCBD

        public bool ThemCTDCBD(CTDCBD ctdcbd)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    if (db.CTDCBDs.Count() > 0)
                    {
                        decimal MaCTDCBD = db.CTDCBDs.Max(itemCTDCBD => itemCTDCBD.MaCTDCBD);
                        ctdcbd.MaCTDCBD = getMaxNextIDTable(MaCTDCBD);
                    }
                    else
                        ctdcbd.MaCTDCBD = decimal.Parse(DateTime.Now.Year + "1");
                    ctdcbd.CreateDate = DateTime.Now;
                    ctdcbd.CreateBy = CTaiKhoan.TaiKhoan;
                    db.CTDCBDs.InsertOnSubmit(ctdcbd);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public decimal getMaxMaCTDCBD()
        {
            try
            {
                return db.CTDCBDs.Max(itemCTDCBD => itemCTDCBD.MaCTDCBD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        #endregion

        #region CTDCHD

        public bool ThemCTDCHD(CTDCHD ctdchd)
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    if (db.CTDCHDs.Count() > 0)
                    {
                        decimal MaCTDCHD = db.CTDCHDs.Max(itemCTDCHD => itemCTDCHD.MaCTDCHD);
                        ctdchd.MaCTDCHD = getMaxNextIDTable(MaCTDCHD);
                    }
                    else
                        ctdchd.MaCTDCHD = decimal.Parse(DateTime.Now.Year + "1");
                    ctdchd.CreateDate = DateTime.Now;
                    ctdchd.CreateBy = CTaiKhoan.TaiKhoan;
                    db.CTDCHDs.InsertOnSubmit(ctdchd);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #endregion
    }
}

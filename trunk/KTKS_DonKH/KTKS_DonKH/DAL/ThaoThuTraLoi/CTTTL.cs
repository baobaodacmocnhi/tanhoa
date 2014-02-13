using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.ThaoThuTraLoi
{
    class CTTTL : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng TTTL & CTTTL

        #region TTTL (Thảo Thư Trả Lời)

        public DataSet LoadDSTTTLDaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleTTTL)
                {
                    DataSet ds = new DataSet();
                    ///Table TTTL
                    var queryTTTL = from itemTTTL in db.TTTLs
                                    join itemDonKH in db.DonKHs on itemTTTL.MaDon equals itemDonKH.MaDon
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
                                        MaNoiChuyenDen = itemTTTL.MaNoiChuyenDen,
                                        NoiChuyenDen = itemTTTL.NoiChuyenDen,
                                        LyDoChuyenDen = itemTTTL.LyDoChuyenDen,
                                        itemTTTL.MaTTTL,
                                        NgayXuLy = itemTTTL.CreateDate,
                                        itemTTTL.KetQua,
                                        itemTTTL.MaChuyen,
                                        LyDoChuyenDi = itemTTTL.LyDoChuyen
                                    };
                    DataTable dtTTTL = new DataTable();
                    dtTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL);
                    dtTTTL.TableName = "TTTL";
                    ds.Tables.Add(dtTTTL);

                    ///Table CTTTTL
                    var queryCTTTTL = from itemCTTTTL in db.CTTTTLs
                                      select itemCTTTTL;

                    DataTable dtCTTTTL = new DataTable();
                    dtCTTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTTTTL);
                    dtCTTTTL.TableName = "CTTTTL";
                    ds.Tables.Add(dtCTTTTL);

                    if (dtTTTL.Rows.Count > 0 && dtCTTTTL.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["TTTL"].Columns["MaTTTL"], ds.Tables["CTTTTL"].Columns["MaTTTL"]);
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

        public DataTable LoadDSTTTLChuaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleTTTL)
                {
                    ///Bảng DonKH
                    var queryDonKH = from itemDonKH in db.DonKHs
                                     join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                     where itemDonKH.Nhan == false && itemDonKH.MaChuyen == "TTTL"
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
                                         MaTTTL = "",
                                         NgayXuLy = "",
                                         KetQua = "",
                                         MaChuyen = "",
                                         LyDoChuyenDi = ""
                                     };
                    ///Bảng KTXM
                    var queryKTXM = from itemKTXM in db.KTXMs
                                    join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                    join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                    where itemKTXM.Nhan == false && itemKTXM.MaChuyen == "TTTL"
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
                                        MaTTTL = "",
                                        NgayXuLy = "",
                                        KetQua = "",
                                        MaChuyen = "",
                                        LyDoChuyenDi = ""
                                    };
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

        public bool ThemTTTL(TTTL tttl)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL)
                {
                    if (db.TTTLs.Count() > 0)
                    {
                        decimal MaTTTL = db.TTTLs.Max(itemTTTL => itemTTTL.MaTTTL);
                        tttl.MaTTTL = getMaxNextIDTable(MaTTTL);
                    }
                    else
                        tttl.MaTTTL = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    tttl.CreateDate = DateTime.Now;
                    tttl.CreateBy = CTaiKhoan.TaiKhoan;
                    db.TTTLs.InsertOnSubmit(tttl);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Thêm TTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public bool SuaTTTL(TTTL tttl)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL)
                {

                    tttl.ModifyDate = DateTime.Now;
                    tttl.ModifyBy = CTaiKhoan.TaiKhoan;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Sửa TTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public TTTL getTTTLbyID(decimal MaTTTL)
        {
            try
            {
                return db.TTTLs.Single(itemTTTL => itemTTTL.MaTTTL == MaTTTL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Mã Thảo Thư Trả Lời lớn nhất hiện tại
        /// </summary>
        /// <returns></returns>
        public decimal getMaxMaTTTL()
        {
            try
            {
                return db.TTTLs.Max(itemTTTL => itemTTTL.MaTTTL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        #endregion

        #region CTTTTL (Chi Tiết Thảo Thư Trả Lời)

        public bool ThemCTTTTL(CTTTTL cttttl)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL)
                {
                    if (db.CTTTTLs.Count() > 0)
                    {
                        decimal MaCTTTTL = db.CTTTTLs.Max(itemCTTTTL => itemCTTTTL.MaCTTTTL);
                        cttttl.MaCTTTTL = getMaxNextIDTable(MaCTTTTL);
                    }
                    else
                        cttttl.MaCTTTTL = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    cttttl.CreateDate = DateTime.Now;
                    cttttl.CreateBy = CTaiKhoan.TaiKhoan;
                    db.CTTTTLs.InsertOnSubmit(cttttl);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Thêm CTCTDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public bool SuaCTTTTL(CTTTTL cttttl)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL)
                {
                    cttttl.ModifyDate = DateTime.Now;
                    cttttl.ModifyBy = CTaiKhoan.TaiKhoan;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công Sửa CTCTDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public CTTTTL getCTTTTLbyID(decimal MaCTTTTL)
        {
            try
            {
                return db.CTTTTLs.Single(itemCTTTTL => itemCTTTTL.MaCTTTTL == MaCTTTTL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public decimal getMaxMaCTTTTL()
        {
            try
            {
                return db.CTTTTLs.Max(itemCTTTTL => itemCTTTTL.MaCTTTTL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Chi Tiết Thảo Thư Trả Lời
        /// </summary>
        /// <returns></returns>
        public List<CTTTTL> LoadDSCTTTTL()
        {
            try
            {
                if (CTaiKhoan.RoleTTTL)
                {
                    return db.CTTTTLs.ToList();
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


        #endregion
    }
}

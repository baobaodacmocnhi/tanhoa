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
        public bool ThemKTXM(KTXM ktxm)
        {
            try
            {
                if (CTaiKhoan.RoleKTXM)
                {
                    if (db.KTXMs.Count() > 0)
                    {
                        decimal MaKTXM = db.KTXMs.Max(itemKTXM => itemKTXM.MaKTXM);
                        ktxm.MaKTXM = getMaxNextIDTable(MaKTXM);
                    }
                    else
                        ktxm.MaKTXM = decimal.Parse(DateTime.Now.Year + "1");
                    ktxm.CreateDate = DateTime.Now;
                    ktxm.CreateBy = CTaiKhoan.TaiKhoan;
                    db.KTXMs.InsertOnSubmit(ktxm);
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

        public bool SuaKTXM(KTXM ktxm)
        {
            try
            {
                if (CTaiKhoan.RoleKTXM)
                {
                    ktxm.ModifyDate = DateTime.Now;
                    ktxm.ModifyBy = CTaiKhoan.TaiKhoan;
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

        public DataTable LoadDSKTXMDaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleKTXM)
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

        public DataTable LoadDSKTXMChuaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleKTXM)
                {
                    ///Bảng DonKH
                    var queryDonKH = from itemDonKH in db.DonKHs
                                     join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                     where itemDonKH.Nhan == false && itemDonKH.MaChuyen == "KTXM"
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
            if (db.KTXMs.Any(itemKTXM => itemKTXM.MaKTXM == MaKTXM))
                return db.KTXMs.Single(itemKTXM => itemKTXM.MaKTXM == MaKTXM);
            else
                return null;
        }

    }
}

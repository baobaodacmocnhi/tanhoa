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
                    ///Phải load số cột như nhau ở 2 hàm LoadDSKTXM thì dategridview mới không bị lỗi cột
                    //DataTable table = new DataTable();
                    //table.Columns.Add("MaDon", typeof(string));
                    //table.Columns.Add("TenLD", typeof(string));
                    //table.Columns.Add("CreateDate", typeof(string));
                    //table.Columns.Add("DanhBo", typeof(string));
                    //table.Columns.Add("HoTen", typeof(string));
                    //table.Columns.Add("DiaChi", typeof(string));
                    //table.Columns.Add("NoiDung", typeof(string));
                    //table.Columns.Add("LyDoChuyenDen", typeof(string));
                    //table.Columns.Add("NgayXuLy", typeof(string));
                    //table.Columns.Add("KetQua", typeof(string));
                    //table.Columns.Add("MaChuyen", typeof(string));
                    //table.Columns.Add("LyDoChuyenDi", typeof(string));

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
                                    LyDoChuyenDen = itemDonKH.LyDoChuyen,
                                    NgayXuLy = itemKTXM.CreateDate,
                                    itemKTXM.KetQua,
                                    itemKTXM.MaChuyen,
                                    LyDoChuyenDi = itemKTXM.LyDoChuyen
                                };
                    //DataTable tableTemp = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                    //foreach (DataRow itemRow in tableTemp.Rows)
                    //{
                    //    table.Rows.Add(
                    //        itemRow["MaDon"],
                    //        itemRow["TenLD"],
                    //        itemRow["CreateDate"],
                    //        itemRow["DanhBo"],
                    //        itemRow["HoTen"],
                    //        itemRow["DiaChi"],
                    //        itemRow["NoiDung"],
                    //        itemRow["LyDoChuyenDen"],
                    //        itemRow["NgayXuLy"],
                    //        itemRow["KetQua"],
                    //        itemRow["MaChuyen"],
                    //        itemRow["LyDoChuyenDi"]
                    //        );
                    //}
                    //return table;
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
                    //DataTable table = new DataTable();
                    //table.Columns.Add("MaDon", typeof(string));
                    //table.Columns.Add("TenLD", typeof(string));
                    //table.Columns.Add("CreateDate", typeof(string));
                    //table.Columns.Add("DanhBo", typeof(string));
                    //table.Columns.Add("HoTen", typeof(string));
                    //table.Columns.Add("DiaChi", typeof(string));
                    //table.Columns.Add("NoiDung", typeof(string));
                    //table.Columns.Add("LyDoChuyenDen", typeof(string));
                    //table.Columns.Add("NgayXuLy", typeof(string));
                    //table.Columns.Add("KetQua", typeof(string));
                    //table.Columns.Add("MaChuyen", typeof(string));
                    //table.Columns.Add("LyDoChuyenDi", typeof(string));

                    var query = from itemDonKH in db.DonKHs
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
                                    LyDoChuyenDen = itemDonKH.LyDoChuyen,
                                };
                    //DataTable tableTemp = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                    //foreach (DataRow itemRow in tableTemp.Rows)
                    //{
                    //    table.Rows.Add(
                    //        itemRow["MaDon"],
                    //        itemRow["TenLD"],
                    //        itemRow["CreateDate"],
                    //        itemRow["DanhBo"],
                    //        itemRow["HoTen"],
                    //        itemRow["DiaChi"],
                    //        itemRow["NoiDung"],
                    //        itemRow["LyDoChuyenDen"],
                    //        "", "", "", ""
                    //        );
                    //}
                    //return table;
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

        public KTXM getKTXMbyID(int MaKTXM)
        {
            if (db.KTXMs.Any(itemKTXM => itemKTXM.MaKTXM == MaKTXM))
                return db.KTXMs.Single(itemKTXM => itemKTXM.MaKTXM == MaKTXM);
            else
                return null;
        }

    }
}

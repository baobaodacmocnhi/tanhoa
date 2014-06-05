using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;
using System.Data;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.Function;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    class CCatChuyenDM : CDAL
    {
        public bool ThemCatChuyenDM(CatChuyenDM catchuyendm)
        {
            try
            {
                ///Vì đã lấy Số Phiếu ở LichSuChungTu làm khóa chính ở đây
                //if (db.CatChuyenDMs.Count() > 0)
                //{
                //    decimal SoPhieu = db.CatChuyenDMs.Max(itemCCDM => itemCCDM.SoPhieu);
                //    catchuyendm.SoPhieu = getMaxNextIDTable(SoPhieu);
                //}
                //else
                //    catchuyendm.SoPhieu = decimal.Parse(DateTime.Now.Year + "1");
                catchuyendm.CreateDate = DateTime.Now;
                catchuyendm.CreateBy = CTaiKhoan.MaUser;
                db.CatChuyenDMs.InsertOnSubmit(catchuyendm);
                db.SubmitChanges();
                //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaCatChuyemDM(CatChuyenDM catchuyendm)
        {
            try
            {
                catchuyendm.ModifyDate = DateTime.Now;
                catchuyendm.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public CatChuyenDM getCatChuyenDMbySoPhieu(decimal SoPhieu)
        {
            try
            {
                return db.CatChuyenDMs.SingleOrDefault(itemCCDM => itemCCDM.SoPhieu == SoPhieu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Phiếu Cắt Chuyển Định Mức
        /// </summary>
        /// <returns></returns>
        //public DataTable LoadDSCatChuyenDM()
        //{
        //    //string a = "";
        //    try
        //    {
        //        if (CTaiKhoan.RoleDCBD_Xem || CTaiKhoan.RoleDCBD_CapNhat)
        //        {
        //            var query = from itemCCDM in db.CatChuyenDMs
        //                        //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
        //                        //where itemLSCT.SoPhieu != null
        //                        //where itemLSCT.MaLSCT == 126114
        //                        //orderby itemLSCT.SoPhieu ascending
        //                        select new
        //                        {
        //                            MaLSCT=itemCCDM.SoPhieu,
        //                            itemCCDM.SoPhieu,
        //                            //SoPhieuDCBD = itemDCBD.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
        //                            itemCCDM.CreateDate,
        //                            itemCCDM.MaCT,
        //                            itemCCDM.CatDM,
        //                            itemCCDM.SoNKCat,
        //                            itemCCDM.NhanNK_MaCN,
        //                            itemCCDM.NhanNK_DanhBo,
        //                            itemCCDM.NhanNK_HoTen,
        //                            itemCCDM.NhanNK_DiaChi,
        //                            itemCCDM.NhanDM,
        //                            itemCCDM.YeuCauCat,
        //                            itemCCDM.SoNKNhan,
        //                            itemCCDM.CatNK_MaCN,
        //                            itemCCDM.CatNK_DanhBo,
        //                            itemCCDM.CatNK_HoTen,
        //                            itemCCDM.CatNK_DiaChi,
        //                            itemCCDM.PhieuDuocKy,
        //                            itemCCDM.MaDon,
        //                        };
        //            if (query.Count() > 0)
        //            {
        //                DataTable table = new DataTable();
        //                table.Columns.Add("In", typeof(bool));
        //                table.Columns.Add("MaLSCT", typeof(string));
        //                table.Columns.Add("SoPhieu", typeof(string));
        //                table.Columns.Add("SoPhieuDCBD", typeof(string));
        //                table.Columns.Add("CreateDate", typeof(string));
        //                table.Columns.Add("MaCT", typeof(string));
        //                table.Columns.Add("CatNhan", typeof(string));
        //                table.Columns.Add("SoNK", typeof(string));
        //                table.Columns.Add("NhanNK_MaCN", typeof(string));
        //                table.Columns.Add("NhanNK_DanhBo", typeof(string));
        //                table.Columns.Add("NhanNK_HoTen", typeof(string));
        //                table.Columns.Add("NhanNK_DiaChi", typeof(string));
        //                table.Columns.Add("CatNK_MaCN", typeof(string));
        //                table.Columns.Add("CatNK_DanhBo", typeof(string));
        //                table.Columns.Add("CatNK_HoTen", typeof(string));
        //                table.Columns.Add("CatNK_DiaChi", typeof(string));
        //                table.Columns.Add("PhieuDuocKy", typeof(bool));

        //                DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
        //                CChiNhanh _cChiNhanh = new CChiNhanh();
        //                foreach (DataRow itemRow in table2.Rows)
        //                {
        //                    //a = itemRow["MaLSCT"].ToString();
        //                    DataRow Row = table.NewRow();
        //                    Row["In"] = false;
        //                    Row["MaLSCT"] = itemRow["MaLSCT"];
        //                    Row["SoPhieu"] = itemRow["SoPhieu"];
        //                    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
        //                        if (db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
        //                            Row["SoPhieuDCBD"] = db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
        //                        else
        //                            Row["SoPhieuDCBD"] = "";
        //                    else
        //                        Row["SoPhieuDCBD"] = "";
        //                    Row["CreateDate"] = itemRow["CreateDate"];
        //                    Row["MaCT"] = itemRow["MaCT"];
        //                    if (itemRow["CatDM"].ToString() != "")
        //                        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
        //                        {
        //                            Row["CatNhan"] = "Cắt";
        //                            Row["SoNK"] = itemRow["SoNKCat"];
        //                        }
        //                    if (itemRow["NhanDM"].ToString() != "")
        //                        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
        //                        {
        //                            Row["CatNhan"] = "Nhận";
        //                            Row["SoNK"] = itemRow["SoNKNhan"];
        //                        }
        //                    if (itemRow["YeuCauCat"].ToString() != "")
        //                        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
        //                        {
        //                            Row["CatNhan"] = "YC Cắt";
        //                            Row["SoNK"] = itemRow["SoNKNhan"];
        //                        }
        //                    if (itemRow["NhanNK_MaCN"].ToString() != "")
        //                        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
        //                    else
        //                        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
        //                    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
        //                    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
        //                    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
        //                    if (itemRow["CatNK_MaCN"].ToString() != "")
        //                        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
        //                    else
        //                        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
        //                    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
        //                    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
        //                    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
        //                    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

        //                    table.Rows.Add(Row);
        //                }
        //                return table;
        //            }
        //            else
        //                return null;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}

        /// <summary>
        /// Lấy Danh Sách Phiếu Cắt Chuyển Định Mức trong Ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        //public DataTable LoadDSCatChuyenDM(DateTime TuNgay)
        //{
        //    //string a = "";
        //    try
        //    {
        //        if (CTaiKhoan.RoleDCBD_Xem || CTaiKhoan.RoleDCBD_CapNhat)
        //        {
        //            var query = from itemCCDM in db.CatChuyenDMs
        //                        where itemCCDM.CreateDate.Value.Date == TuNgay.Date //&& itemLSCT.SoPhieu != null
        //                        //orderby itemLSCT.SoPhieu ascending
        //                        select new
        //                        {
        //                            MaLSCT=itemCCDM.SoPhieu,
        //                            itemCCDM.SoPhieu,
        //                            itemCCDM.CatDM,
        //                            itemCCDM.YeuCauCat,
        //                            itemCCDM.NhanDM,
        //                        };
        //            return CLinQToDataTable.LINQToDataTable(query);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}

        /// <summary>
        /// Lấy Danh Sách Phiếu Cắt Chuyển Định Mức trong Khoảng Thời Gian
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        //public DataTable LoadDSCatChuyenDM(DateTime TuNgay, DateTime DenNgay)
        //{
        //    try
        //    {
        //        if (CTaiKhoan.RoleDCBD_Xem || CTaiKhoan.RoleDCBD_CapNhat)
        //        {
        //            var query = from itemCCDM in db.CatChuyenDMs
        //                        where itemCCDM.CreateDate.Value.Date >= TuNgay.Date && itemCCDM.CreateDate.Value.Date <= DenNgay.Date //&& itemLSCT.SoPhieu != null
        //                        //orderby itemLSCT.SoPhieu ascending
        //                        select new
        //                        {
        //                            MaLSCT=itemCCDM.SoPhieu,
        //                            itemCCDM.SoPhieu,
        //                            itemCCDM.CatDM,
        //                            itemCCDM.YeuCauCat,
        //                            itemCCDM.NhanDM,
        //                        };
        //            return CLinQToDataTable.LINQToDataTable(query);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}
    }
}

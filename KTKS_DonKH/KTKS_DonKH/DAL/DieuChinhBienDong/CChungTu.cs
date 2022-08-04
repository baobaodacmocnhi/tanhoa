using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.DieuChinhBienDong;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    class CChungTu : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng ChungTu & ChungTu_ChiTiet & ChungTu_LichSu

        #region ChungTu

        public bool Them(ChungTu chungtu)
        {
            try
            {
                chungtu.CreateDate = DateTime.Now;
                chungtu.CreateBy = CTaiKhoan.MaUser;
                db.ChungTus.InsertOnSubmit(chungtu);
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

        public bool Sua(ChungTu chungtu)
        {
            try
            {
                chungtu.ModifyDate = DateTime.Now;
                chungtu.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(string MaCT, int MaLCT)
        {
            return db.ChungTus.Any(itemCT => itemCT.MaCT == MaCT && itemCT.MaLCT == MaLCT);
        }

        public ChungTu Get(string MaCT, int MaLCT)
        {
            return db.ChungTus.Single(itemCT => itemCT.MaCT == MaCT && itemCT.MaLCT == MaLCT);
        }

        #endregion

        #region ChungTu_ChiTiet

        public bool ThemCT(ChungTu_ChiTiet ctchungtu)
        {
            try
            {
                ctchungtu.CreateDate = DateTime.Now;
                ctchungtu.CreateBy = CTaiKhoan.MaUser;
                db.ChungTu_ChiTiets.InsertOnSubmit(ctchungtu);
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

        public bool SuaCT(ChungTu_ChiTiet ctchungtu)
        {
            try
            {
                ctchungtu.ModifyDate = DateTime.Now;
                ctchungtu.ModifyBy = CTaiKhoan.MaUser;
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

        public bool XoaCT(ChungTu_ChiTiet ctchungtu)
        {
            try
            {
                db.ChungTu_ChiTiets.DeleteOnSubmit(ctchungtu);
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

        public bool checkExist_KhacDanhBo_Active(string DanhBo, string MaCT, int MaLCT)
        {
            return db.ChungTu_ChiTiets.Any(itemCT => itemCT.DanhBo != DanhBo && itemCT.MaCT == MaCT && itemCT.MaLCT == MaLCT && itemCT.Cat == false);
        }

        public bool CheckExist_CT(string DanhBo, string MaCT, int MaLCT)
        {
            return db.ChungTu_ChiTiets.Any(itemCT => itemCT.DanhBo == DanhBo && itemCT.MaCT == MaCT && itemCT.MaLCT == MaLCT);
        }

        public bool CheckExist_CT(string MaCT, int MaLCT)
        {
            return db.ChungTu_ChiTiets.Any(itemCT => itemCT.MaCT == MaCT && itemCT.MaLCT == MaLCT);
        }

        public bool CheckExist_CT_HoKhau_HoKhauNgheo(string MaCT, int MaLCT)
        {
            return db.ChungTu_ChiTiets.Any(itemCT => itemCT.MaCT == MaCT && (MaLCT == 1 || MaLCT == 10));
        }

        public bool CheckExist_CT_HoKhau_HoKhauNgheo(string DanhBo, string MaCT, int MaLCT)
        {
            return db.ChungTu_ChiTiets.Any(itemCT => itemCT.DanhBo == DanhBo && itemCT.MaCT == MaCT && (MaLCT == 1 || MaLCT == 10));
        }

        public bool CheckDinhMucNhaTro(string DanhBo)
        {
            return db.ChungTu_ChiTiets.Any(item => item.DanhBo == DanhBo && item.Cat == false && (item.ChungTu.LoaiChungTu.MaLCT == 7 || item.ChungTu.LoaiChungTu.MaLCT == 8));
        }

        public ChungTu_ChiTiet GetCT(string DanhBo, string MaCT, int MaLCT)
        {
            return db.ChungTu_ChiTiets.SingleOrDefault(itemCT => itemCT.DanhBo == DanhBo && itemCT.MaCT == MaCT && itemCT.MaLCT == MaLCT);
        }

        /// <summary>
        /// Lấy Danh Sách các Danh Bộ được đăng ký định mức với Sổ Đăng Ký truyền vào
        /// </summary>
        /// <param name="MaCT"></param>
        /// <returns></returns>
        public DataTable getDS_ChiTiet(string MaCT, int MaLCT)
        {
            return LINQToDataTable(db.ChungTu_ChiTiets.Where(itemCTChungTu => itemCTChungTu.MaCT == MaCT && itemCTChungTu.MaLCT == MaLCT).ToList());
        }

        public DataTable getDS_ChiTiet_HoKhau_HoKhauNgheo(string MaCT)
        {
            return LINQToDataTable(db.ChungTu_ChiTiets.Where(itemCTChungTu => itemCTChungTu.MaCT == MaCT && (itemCTChungTu.MaLCT == 1 || itemCTChungTu.MaLCT == 10)).ToList());
        }

        public DataTable getDS_ChiTiet_DanhBo(string DanhBo)
        {
            var query = from itemCTCT in db.ChungTu_ChiTiets
                        join itemCT in db.ChungTus on new { itemCTCT.MaCT, itemCTCT.MaLCT } equals new { itemCT.MaCT, itemCT.MaLCT }
                        join itemLCT in db.LoaiChungTus on itemCT.MaLCT equals itemLCT.MaLCT
                        where itemCTCT.DanhBo == DanhBo
                        orderby itemCTCT.MaCT ascending
                        select new
                        {
                            itemCTCT.DanhBo,
                            itemCT.MaLCT,
                            itemLCT.TenLCT,
                            itemCTCT.MaCT,
                            itemCT.DiaChi,
                            itemCT.SoNKTong,
                            itemCT.SoNKCat,
                            itemCT.SoNKNhan,
                            itemCT.SoNKConLai,
                            itemCTCT.SoNKDangKy,
                            itemCTCT.NgayHetHan,
                            itemCTCT.ThoiHan,
                            itemCTCT.DienThoai,
                            itemCTCT.Cat,
                            itemCTCT.GhiChu,
                            itemCTCT.GiaHan,
                            itemCTCT.Lo,
                            itemCTCT.Phong,
                            itemCTCT.CreateDate,
                        };

            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet(string MaCT)
        {
            var query = from itemCTCT in db.ChungTu_ChiTiets
                        where itemCTCT.MaCT == MaCT
                        select new
                        {
                            itemCTCT.DanhBo,
                        };

            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet_CCCD()
        {
            var query = from itemCTCT in db.ChungTu_ChiTiets
                        where itemCTCT.ChungTu.MaLCT == 15 && itemCTCT.Cat == false
                        select new
                        {
                            itemCTCT.DanhBo,
                            itemCTCT.MaCT,
                            itemCTCT.ChungTu.HoTen,
                        };

            return LINQToDataTable(query);
        }

        public DataTable getDS_ChiTiet_CMND()
        {
            var query = from itemCTCT in db.ChungTu_ChiTiets
                        where itemCTCT.ChungTu.MaLCT == 16 && itemCTCT.Cat == false
                        select new
                        {
                            itemCTCT.DanhBo,
                            itemCTCT.MaCT,
                            itemCTCT.ChungTu.HoTen,
                        };

            return LINQToDataTable(query);
        }

        #endregion

        #region ChungTu_LichSu

        public bool ThemLichSuChungTu(ChungTu_LichSu lichsuchungtu)
        {
            try
            {
                if (db.ChungTu_LichSus.Count() > 0)
                {
                    string ID = "MaLSCT";
                    string Table = "ChungTu_LichSu";
                    decimal MaLSCT = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    lichsuchungtu.MaLSCT = getMaxNextIDTable(MaLSCT);
                }
                else
                    lichsuchungtu.MaLSCT = decimal.Parse(DateTime.Now.Year + "1");
                lichsuchungtu.CreateDate = DateTime.Now;
                lichsuchungtu.CreateBy = CTaiKhoan.MaUser;
                db.ChungTu_LichSus.InsertOnSubmit(lichsuchungtu);
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

        public bool SuaLichSuChungTu(ChungTu_LichSu lichsuchungtu)
        {
            try
            {
                lichsuchungtu.ModifyDate = DateTime.Now;
                lichsuchungtu.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool XoaLichSuChungTu(ChungTu_LichSu lichsuchungtu)
        {
            try
            {
                db.ChungTu_LichSus.DeleteOnSubmit(lichsuchungtu);
                db.SubmitChanges();
                //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        /// <summary>
        /// Lấy Số Phiếu kế tiếp cho Cắt Chuyển Định Mức
        /// </summary>
        /// <returns></returns>
        public decimal getMaxNextSoPhieuLSCT()
        {
            try
            {
                if (db.ChungTu_LichSus.Count() > 0)
                {
                    if (db.ChungTu_LichSus.Max(itemLSCT => itemLSCT.SoPhieu) == null)
                        return decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    else
                    {
                        string ID = "SoPhieu";
                        string Table = "ChungTu_LichSu";
                        decimal SoPhieu = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        return getMaxNextIDTable(SoPhieu);
                    }
                }
                else
                    return decimal.Parse("1" + DateTime.Now.ToString("yy"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
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
        //        var query = from itemLSCT in db.ChungTu_LichSus
        //                    //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
        //                    where itemLSCT.SoPhieu != null
        //                    //where itemLSCT.MaLSCT == 126114
        //                    orderby itemLSCT.CreateDate descending
        //                    select new
        //                    {
        //                        In = false,
        //                        itemLSCT.MaLSCT,
        //                        itemLSCT.SoPhieu,
        //                        Ma = itemLSCT.SoPhieu,
        //                        //SoPhieuDCBD = itemDCBD.DCBD_ChiTietBienDongs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
        //                        itemLSCT.CreateDate,
        //                        itemLSCT.MaCT,
        //                        itemLSCT.CatDM,
        //                        itemLSCT.SoNKCat,
        //                        itemLSCT.NhanNK_MaCN,
        //                        itemLSCT.NhanNK_DanhBo,
        //                        DanhBo = itemLSCT.NhanNK_DanhBo,
        //                        itemLSCT.NhanNK_HoTen,
        //                        HoTen = itemLSCT.NhanNK_HoTen,
        //                        itemLSCT.NhanNK_DiaChi,
        //                        itemLSCT.NhanDM,
        //                        itemLSCT.YeuCauCat,
        //                        itemLSCT.SoNKNhan,
        //                        itemLSCT.CatNK_MaCN,
        //                        itemLSCT.CatNK_DanhBo,
        //                        itemLSCT.CatNK_HoTen,
        //                        itemLSCT.CatNK_DiaChi,
        //                        itemLSCT.PhieuDuocKy,
        //                        itemLSCT.MaDon,
        //                        itemLSCT.NguoiKy,
        //                        itemLSCT.CreateBy,
        //                    };
        //        if (query.Count() > 0)
        //        {
        //            //DataTable table = new DataTable();
        //            //table.Columns.Add("In", typeof(bool));
        //            //table.Columns.Add("MaLSCT", typeof(string));
        //            //table.Columns.Add("SoPhieu", typeof(string));
        //            //table.Columns.Add("SoPhieuDCBD", typeof(string));
        //            //table.Columns.Add("CreateDate", typeof(string));
        //            //table.Columns.Add("MaCT", typeof(string));
        //            //table.Columns.Add("CatNhan", typeof(string));
        //            //table.Columns.Add("SoNK", typeof(string));
        //            //table.Columns.Add("NhanNK_MaCN", typeof(string));
        //            //table.Columns.Add("NhanNK_DanhBo", typeof(string));
        //            //table.Columns.Add("NhanNK_HoTen", typeof(string));
        //            //table.Columns.Add("NhanNK_DiaChi", typeof(string));
        //            //table.Columns.Add("CatNK_MaCN", typeof(string));
        //            //table.Columns.Add("CatNK_DanhBo", typeof(string));
        //            //table.Columns.Add("CatNK_HoTen", typeof(string));
        //            //table.Columns.Add("CatNK_DiaChi", typeof(string));
        //            //table.Columns.Add("PhieuDuocKy", typeof(bool));

        //            //DataTable table2 = LINQToDataTable(query);
        //            //CChiNhanh _cChiNhanh = new CChiNhanh();
        //            //foreach (DataRow itemRow in table2.Rows)
        //            //{
        //            //    //a = itemRow["MaLSCT"].ToString();
        //            //    DataRow Row = table.NewRow();
        //            //    Row["In"] = false;
        //            //    Row["MaLSCT"] = itemRow["MaLSCT"];
        //            //    Row["SoPhieu"] = itemRow["SoPhieu"];
        //            //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
        //            //        if (db.DCBD_ChiTietBienDongs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
        //            //            Row["SoPhieuDCBD"] = db.DCBD_ChiTietBienDongs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
        //            //        else
        //            //            Row["SoPhieuDCBD"] = "";
        //            //    else
        //            //        Row["SoPhieuDCBD"] = "";
        //            //    Row["CreateDate"] = itemRow["CreateDate"];
        //            //    Row["MaCT"] = itemRow["MaCT"];
        //            //    if (itemRow["CatDM"].ToString() != "")
        //            //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
        //            //        {
        //            //            Row["CatNhan"] = "Cắt";
        //            //            Row["SoNK"] = itemRow["SoNKCat"];
        //            //        }
        //            //    if (itemRow["NhanDM"].ToString() != "")
        //            //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
        //            //        {
        //            //            Row["CatNhan"] = "Nhận";
        //            //            Row["SoNK"] = itemRow["SoNKNhan"];
        //            //        }
        //            //    if (itemRow["YeuCauCat"].ToString() != "")
        //            //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
        //            //        {
        //            //            Row["CatNhan"] = "YC Cắt";
        //            //            Row["SoNK"] = itemRow["SoNKNhan"];
        //            //        }
        //            //    if (itemRow["NhanNK_MaCN"].ToString() != "")
        //            //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
        //            //    else
        //            //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
        //            //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
        //            //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
        //            //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
        //            //    if (itemRow["CatNK_MaCN"].ToString() != "")
        //            //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
        //            //    else
        //            //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
        //            //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
        //            //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
        //            //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
        //            //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

        //            //    table.Rows.Add(Row);
        //            //}
        //            //return table;
        //            return LINQToDataTable(query);
        //        }
        //        else
        //            return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}

        //public DataTable LoadDSCatChuyenDMByMaDon(decimal MaDon)
        //{
        //    //string a = "";
        //    try
        //    {
        //        var query = from itemLSCT in db.ChungTu_LichSus
        //                    //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
        //                    join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
        //                    from itemtableND in tableND.DefaultIfEmpty()
        //                    where itemLSCT.SoPhieu != null && (itemLSCT.MaDon == MaDon || itemLSCT.MaDonTXL == MaDon)
        //                    //where itemLSCT.MaLSCT == 126114
        //                    orderby itemLSCT.CreateDate ascending
        //                    select new
        //                    {
        //                        In = false,
        //                        itemLSCT.MaLSCT,
        //                        itemLSCT.SoPhieu,
        //                        Ma = itemLSCT.SoPhieu,
        //                        //SoPhieuDCBD = itemDCBD.DCBD_ChiTietBienDongs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
        //                        itemLSCT.CreateDate,
        //                        itemLSCT.MaCT,
        //                        itemLSCT.CatDM,
        //                        itemLSCT.SoNKCat,
        //                        itemLSCT.NhanNK_MaCN,
        //                        itemLSCT.NhanNK_DanhBo,
        //                        DanhBo = itemLSCT.NhanNK_DanhBo,
        //                        itemLSCT.NhanNK_HoTen,
        //                        HoTen = itemLSCT.NhanNK_HoTen,
        //                        itemLSCT.NhanNK_DiaChi,
        //                        itemLSCT.NhanDM,
        //                        itemLSCT.YeuCauCat,
        //                        itemLSCT.SoNKNhan,
        //                        itemLSCT.CatNK_MaCN,
        //                        itemLSCT.CatNK_DanhBo,
        //                        itemLSCT.CatNK_HoTen,
        //                        itemLSCT.CatNK_DiaChi,
        //                        itemLSCT.PhieuDuocKy,
        //                        itemLSCT.MaDon,
        //                        itemLSCT.NguoiKy,
        //                        CreateBy = itemtableND.HoTen,
        //                    };
        //        if (query.Count() > 0)
        //        {
        //            //DataTable table = new DataTable();
        //            //table.Columns.Add("In", typeof(bool));
        //            //table.Columns.Add("MaLSCT", typeof(string));
        //            //table.Columns.Add("SoPhieu", typeof(string));
        //            //table.Columns.Add("SoPhieuDCBD", typeof(string));
        //            //table.Columns.Add("CreateDate", typeof(string));
        //            //table.Columns.Add("MaCT", typeof(string));
        //            //table.Columns.Add("CatNhan", typeof(string));
        //            //table.Columns.Add("SoNK", typeof(string));
        //            //table.Columns.Add("NhanNK_MaCN", typeof(string));
        //            //table.Columns.Add("NhanNK_DanhBo", typeof(string));
        //            //table.Columns.Add("NhanNK_HoTen", typeof(string));
        //            //table.Columns.Add("NhanNK_DiaChi", typeof(string));
        //            //table.Columns.Add("CatNK_MaCN", typeof(string));
        //            //table.Columns.Add("CatNK_DanhBo", typeof(string));
        //            //table.Columns.Add("CatNK_HoTen", typeof(string));
        //            //table.Columns.Add("CatNK_DiaChi", typeof(string));
        //            //table.Columns.Add("PhieuDuocKy", typeof(bool));

        //            //DataTable table2 = LINQToDataTable(query);
        //            //CChiNhanh _cChiNhanh = new CChiNhanh();
        //            //foreach (DataRow itemRow in table2.Rows)
        //            //{
        //            //    //a = itemRow["MaLSCT"].ToString();
        //            //    DataRow Row = table.NewRow();
        //            //    Row["In"] = false;
        //            //    Row["MaLSCT"] = itemRow["MaLSCT"];
        //            //    Row["SoPhieu"] = itemRow["SoPhieu"];
        //            //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
        //            //        if (db.DCBD_ChiTietBienDongs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
        //            //            Row["SoPhieuDCBD"] = db.DCBD_ChiTietBienDongs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
        //            //        else
        //            //            Row["SoPhieuDCBD"] = "";
        //            //    else
        //            //        Row["SoPhieuDCBD"] = "";
        //            //    Row["CreateDate"] = itemRow["CreateDate"];
        //            //    Row["MaCT"] = itemRow["MaCT"];
        //            //    if (itemRow["CatDM"].ToString() != "")
        //            //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
        //            //        {
        //            //            Row["CatNhan"] = "Cắt";
        //            //            Row["SoNK"] = itemRow["SoNKCat"];
        //            //        }
        //            //    if (itemRow["NhanDM"].ToString() != "")
        //            //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
        //            //        {
        //            //            Row["CatNhan"] = "Nhận";
        //            //            Row["SoNK"] = itemRow["SoNKNhan"];
        //            //        }
        //            //    if (itemRow["YeuCauCat"].ToString() != "")
        //            //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
        //            //        {
        //            //            Row["CatNhan"] = "YC Cắt";
        //            //            Row["SoNK"] = itemRow["SoNKNhan"];
        //            //        }
        //            //    if (itemRow["NhanNK_MaCN"].ToString() != "")
        //            //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
        //            //    else
        //            //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
        //            //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
        //            //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
        //            //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
        //            //    if (itemRow["CatNK_MaCN"].ToString() != "")
        //            //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
        //            //    else
        //            //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
        //            //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
        //            //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
        //            //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
        //            //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

        //            //    table.Rows.Add(Row);
        //            //}
        //            //return table;
        //            return LINQToDataTable(query);
        //        }
        //        else
        //            return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}

        public DataTable getDS_CatChuyenDM_MaDon(string To, decimal MaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from itemLSCT in db.ChungTu_LichSus
                                join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemLSCT.SoPhieu != null && itemLSCT.MaDon == MaDon
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                    itemLSCT.SoNK,
                                    CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                    : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                    : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                    : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                    CreateBy = itemtableND.HoTen,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.SoPhieu != null && itemLSCT.MaDonTXL == MaDon
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.SoPhieu != null && itemLSCT.MaDonTBC == MaDon
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.SoPhieu != null && itemLSCT.MaDonMoi == MaDon
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_CatChuyenDM_MaDon(string To, decimal TuMaDon, decimal DenMaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from itemLSCT in db.ChungTu_LichSus
                                join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemLSCT.SoPhieu != null &&
                                (itemLSCT.MaDon.Value.ToString().Substring(itemLSCT.MaDon.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemLSCT.MaDon.Value.ToString().Substring(itemLSCT.MaDon.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                                && (itemLSCT.MaDon >= TuMaDon && itemLSCT.MaDon <= DenMaDon)
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                    itemLSCT.SoNK,
                                    CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                    : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                    : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                    : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                    CreateBy = itemtableND.HoTen,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.SoPhieu != null &&
                            (itemLSCT.MaDonTXL.Value.ToString().Substring(itemLSCT.MaDonTXL.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemLSCT.MaDonTXL.Value.ToString().Substring(itemLSCT.MaDonTXL.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemLSCT.MaDonTXL >= TuMaDon && itemLSCT.MaDonTXL <= DenMaDon)
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.SoPhieu != null &&
                            (itemLSCT.MaDonTBC.Value.ToString().Substring(itemLSCT.MaDonTBC.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemLSCT.MaDonTBC.Value.ToString().Substring(itemLSCT.MaDonTBC.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemLSCT.MaDonTBC >= TuMaDon && itemLSCT.MaDonTBC <= DenMaDon)
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.SoPhieu != null && itemLSCT.MaDonMoi >= TuMaDon && itemLSCT.MaDonMoi <= DenMaDon
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_CatChuyenDM_MaDon(string To, int CreateBy, decimal MaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from itemLSCT in db.ChungTu_LichSus
                                join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null && itemLSCT.MaDon == MaDon
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                    itemLSCT.SoNK,
                                    CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                    : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                    : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                    : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                    CreateBy = itemtableND.HoTen,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null && itemLSCT.MaDonTXL == MaDon
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null && itemLSCT.MaDonTBC == MaDon
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null && itemLSCT.MaDonMoi == MaDon
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_CatChuyenDM_MaDon(string To, int CreateBy, decimal TuMaDon, decimal DenMaDon)
        {
            switch (To)
            {
                case "TKH":
                    var query = from itemLSCT in db.ChungTu_LichSus
                                join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                                from itemtableND in tableND.DefaultIfEmpty()
                                where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null &&
                                (itemLSCT.MaDon.Value.ToString().Substring(itemLSCT.MaDon.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemLSCT.MaDon.Value.ToString().Substring(itemLSCT.MaDon.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                                && (itemLSCT.MaDon >= TuMaDon && itemLSCT.MaDon <= DenMaDon)
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                    itemLSCT.SoNK,
                                    CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                    : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                    : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                    : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                    CreateBy = itemtableND.HoTen,
                                };
                    return LINQToDataTable(query);
                case "TXL":
                    query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null && (itemLSCT.MaDonTXL.Value.ToString().Substring(itemLSCT.MaDonTXL.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemLSCT.MaDonTXL.Value.ToString().Substring(itemLSCT.MaDonTXL.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemLSCT.MaDonTXL >= TuMaDon && itemLSCT.MaDonTXL <= DenMaDon)
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
                case "TBC":
                    query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null &&
                            (itemLSCT.MaDonTBC.Value.ToString().Substring(itemLSCT.MaDonTBC.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemLSCT.MaDonTBC.Value.ToString().Substring(itemLSCT.MaDonTBC.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                            && (itemLSCT.MaDonTBC >= TuMaDon && itemLSCT.MaDonTBC <= DenMaDon)
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
                default:
                    query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null && itemLSCT.MaDonMoi >= TuMaDon && itemLSCT.MaDonMoi <= DenMaDon
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                    return LINQToDataTable(query);
            }
        }

        public DataTable getDS_CatChuyenDM_SoPhieu(decimal SoPhieu)
        {
            try
            {
                var query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.SoPhieu != null && itemLSCT.SoPhieu == SoPhieu
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                ID = itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS_CatChuyenDM_SoPhieu(decimal TuSoPhieu, decimal DenSoPhieu)
        {
            try
            {
                var query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.SoPhieu != null &&
                            itemLSCT.SoPhieu.ToString().Substring(itemLSCT.SoPhieu.ToString().Length - 2, 2) == TuSoPhieu.ToString().Substring(TuSoPhieu.ToString().Length - 2, 2)
                            && itemLSCT.SoPhieu.ToString().Substring(itemLSCT.SoPhieu.ToString().Length - 2, 2) == DenSoPhieu.ToString().Substring(DenSoPhieu.ToString().Length - 2, 2)
                            && itemLSCT.SoPhieu >= TuSoPhieu && itemLSCT.SoPhieu <= DenSoPhieu
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS_CatChuyenDM_SoPhieu(int CreateBy, decimal SoPhieu)
        {
            try
            {
                var query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null && itemLSCT.SoPhieu == SoPhieu
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS_CatChuyenDM_SoPhieu(int CreateBy, decimal TuSoPhieu, decimal DenSoPhieu)
        {
            try
            {
                var query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null &&
                            itemLSCT.SoPhieu.ToString().Substring(itemLSCT.SoPhieu.ToString().Length - 2, 2) == TuSoPhieu.ToString().Substring(TuSoPhieu.ToString().Length - 2, 2)
                            && itemLSCT.SoPhieu.ToString().Substring(itemLSCT.SoPhieu.ToString().Length - 2, 2) == DenSoPhieu.ToString().Substring(DenSoPhieu.ToString().Length - 2, 2)
                            && itemLSCT.SoPhieu >= TuSoPhieu && itemLSCT.SoPhieu <= DenSoPhieu
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS_CatChuyenDM_DanhBo(string DanhBo)
        {
            try
            {
                var query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.SoPhieu != null && itemLSCT.DanhBo == DanhBo
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS_CatChuyenDM_DanhBo(int CreateBy, string DanhBo)
        {
            try
            {
                var query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null && itemLSCT.DanhBo == DanhBo
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS_CatChuyenDM_CreateDate(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            try
            {
                var query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.SoPhieu != null && itemLSCT.CreateDate.Value.Date >= FromCreateDate.Date && itemLSCT.CreateDate.Value.Date <= ToCreateDate.Date
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDS_CatChuyenDM_CreateDate(int CreateBy, DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemLSCT in db.ChungTu_LichSus
                            join itemND in db.Users on itemLSCT.CreateBy equals itemND.MaU into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null && itemLSCT.CreateDate.Value.Date >= TuNgay.Date && itemLSCT.CreateDate.Value.Date <= DenNgay.Date
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.PhieuDuocKy,
                                itemLSCT.MaLSCT,
                                itemLSCT.SoPhieu,
                                itemLSCT.CreateDate,
                                itemLSCT.MaCT,
                                Loai = itemLSCT.CatDM == true ? "Cắt" : (itemLSCT.YeuCauCat == true ? "YC Cắt" : ""),
                                itemLSCT.SoNK,
                                CatNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.CatNK_MaCN).TenCN,
                                itemLSCT.CatNK_DanhBo,
                                itemLSCT.CatNK_HoTen,
                                itemLSCT.CatNK_DiaChi,
                                NhanNK_MaCN = db.ChiNhanhs.SingleOrDefault(item => item.MaCN == itemLSCT.NhanNK_MaCN).TenCN,
                                itemLSCT.NhanNK_DanhBo,
                                itemLSCT.NhanNK_HoTen,
                                itemLSCT.NhanNK_DiaChi,
                                MaCTDCBD = itemLSCT.MaDonMoi != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonMoi == itemLSCT.MaDonMoi).MaCTDCBD : 0
                                : itemLSCT.MaDon != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDon == itemLSCT.MaDon) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDon == itemLSCT.MaDon).MaCTDCBD : 0
                                : itemLSCT.MaDonTXL != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTXL == itemLSCT.MaDonTXL).MaCTDCBD : 0
                                : itemLSCT.MaDonTBC != null ? db.DCBD_ChiTietBienDongs.Any(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC) == true ? db.DCBD_ChiTietBienDongs.FirstOrDefault(item => item.DCBD.MaDonTBC == itemLSCT.MaDonTBC).MaCTDCBD : 0 : 0,
                                CreateBy = itemtableND.HoTen,
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
        /// Lấy Danh Sách Phiếu Cắt Chuyển Định Mức trong Ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        //public DataTable LoadDSCatChuyenDM(DateTime TuNgay)
        //{
        //    //string a = "";
        //    try
        //    {
        //        var query = from itemLSCT in db.ChungTu_LichSus
        //                    where itemLSCT.CreateDate.Value.Date == TuNgay.Date && itemLSCT.SoPhieu != null
        //                    //orderby itemLSCT.SoPhieu ascending
        //                    select new
        //                    {
        //                        In = false,
        //                        itemLSCT.SoPhieu,
        //                        Ma = itemLSCT.SoPhieu,
        //                        DanhBo = itemLSCT.NhanNK_DanhBo,
        //                        HoTen = itemLSCT.NhanNK_HoTen,
        //                        itemLSCT.NguoiKy,
        //                        itemLSCT.CatDM,
        //                        itemLSCT.YeuCauCat,
        //                        itemLSCT.NhanDM,
        //                        itemLSCT.SoNKCat,
        //                        itemLSCT.SoNKNhan,
        //                    };
        //        return LINQToDataTable(query);
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
        public DataTable getDSCatChuyenDM(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            try
            {
                var query = from itemLSCT in db.ChungTu_LichSus
                            where itemLSCT.SoPhieu != null && itemLSCT.CreateDate.Value.Date >= FromCreateDate.Date && itemLSCT.CreateDate.Value.Date <= ToCreateDate.Date
                            select new
                            {
                                In = false,
                                itemLSCT.SoPhieu,
                                Ma = itemLSCT.SoPhieu,
                                ID = itemLSCT.SoPhieu,
                                DanhBo = itemLSCT.NhanNK_DanhBo,
                                HoTen = itemLSCT.NhanNK_HoTen,
                                itemLSCT.NguoiKy,
                                itemLSCT.CatDM,
                                itemLSCT.YeuCauCat,
                                itemLSCT.NhanDM,
                                itemLSCT.SoNK,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDSCatChuyenDM(DateTime FromCreateDate, DateTime ToCreateDate, int MaQuan)
        {
            //string sql = "select t1.*,t3.TenQuan from ChungTu_LichSu t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " where CAST(t1.CreateDate as date)>='" + FromCreateDate.ToString("yyyy-MM-dd") + "' and CAST(t1.CreateDate as date)<='" + ToCreateDate.ToString("yyyy-MM-dd") + "'"
            //            + " and SoPhieu is not null and MaQuan=" + MaQuan;
            //return ExecuteQuery_DataTable(sql);
            try
            {
                var query = from itemLSCT in db.ChungTu_LichSus
                            where itemLSCT.SoPhieu != null && itemLSCT.CreateDate.Value.Date >= FromCreateDate.Date && itemLSCT.CreateDate.Value.Date <= ToCreateDate.Date && Convert.ToInt32(itemLSCT.Quan) == MaQuan
                            select new
                            {
                                In = false,
                                itemLSCT.SoPhieu,
                                Ma = itemLSCT.SoPhieu,
                                ID = itemLSCT.SoPhieu,
                                DanhBo = itemLSCT.NhanNK_DanhBo,
                                HoTen = itemLSCT.NhanNK_HoTen,
                                itemLSCT.NguoiKy,
                                itemLSCT.CatDM,
                                itemLSCT.YeuCauCat,
                                itemLSCT.NhanDM,
                                itemLSCT.SoNK,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDSCatChuyenDM(DateTime FromCreateDate, DateTime ToCreateDate, int MaQuan, int MaPhuong)
        {
            //string sql = "select t1.*,t3.TenQuan from ChungTu_LichSu t1"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.QUAN t3 on t2.QUAN=t3.MAQUAN"
            //            + " left join SERVER8.CAPNUOCTANHOA.dbo.PHUONG t4 on t2.PHUONG=t4.MAPHUONG and t2.QUAN=t4.MAQUAN"
            //            + " where CAST(t1.CreateDate as date)>='" + FromCreateDate.ToString("yyyy-MM-dd") + "' and CAST(t1.CreateDate as date)<='" + ToCreateDate.ToString("yyyy-MM-dd") + "'"
            //            + " and SoPhieu is not null and t4.MaQuan=" + MaQuan + " and t4.MaPhuong=" + MaPhuong;
            //return ExecuteQuery_DataTable(sql);
            try
            {
                var query = from itemLSCT in db.ChungTu_LichSus
                            where itemLSCT.SoPhieu != null && itemLSCT.CreateDate.Value.Date >= FromCreateDate.Date && itemLSCT.CreateDate.Value.Date <= ToCreateDate.Date && Convert.ToInt32(itemLSCT.Quan) == MaQuan && Convert.ToInt32(itemLSCT.Phuong) == MaPhuong
                            select new
                            {
                                In = false,
                                itemLSCT.SoPhieu,
                                Ma = itemLSCT.SoPhieu,
                                ID = itemLSCT.SoPhieu,
                                DanhBo = itemLSCT.NhanNK_DanhBo,
                                HoTen = itemLSCT.NhanNK_HoTen,
                                itemLSCT.NguoiKy,
                                itemLSCT.CatDM,
                                itemLSCT.YeuCauCat,
                                itemLSCT.NhanDM,
                                itemLSCT.SoNK,
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
        /// Lấy Lịch Sử Chứng Từ
        /// </summary>
        /// <param name="MaLSCT"></param>
        /// <returns></returns>
        public ChungTu_LichSu getLSCTbyID(decimal MaLSCT)
        {
            try
            {
                return db.ChungTu_LichSus.SingleOrDefault(itemLSCT => itemLSCT.MaLSCT == MaLSCT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Lịch Sử Chứng Từ với Sổ Đăng Ký truyền vào
        /// </summary>
        /// <param name="MaCT"></param>
        /// <returns></returns>
        public List<ChungTu_LichSu> LoadDSLichSuChungTubyID(string MaCT, int MaLCT)
        {
            return db.ChungTu_LichSus.Where(itemLSCT => itemLSCT.MaCT == MaCT && itemLSCT.MaLCT == MaLCT).ToList();
        }

        /// <summary>
        /// Lấy ChungTu_LichSu dự theo Số Phiếu
        /// </summary>
        /// <param name="SoPhieu"></param>
        /// <returns></returns>
        public ChungTu_LichSu getLichSuChungTubySoPhieu(decimal SoPhieu)
        {
            try
            {
                return db.ChungTu_LichSus.SingleOrDefault(itemLSCT => itemLSCT.SoPhieu == SoPhieu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy ChungTu_LichSu dự theo Số Phiếu!=null & Danh Bộ
        /// </summary>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public List<ChungTu_LichSu> getLichSuChungTubyDanhBo(string DanhBo)
        {
            try
            {
                return db.ChungTu_LichSus.Where(itemLSCT => itemLSCT.SoPhieu != null && itemLSCT.DanhBo == DanhBo).OrderBy(itemLSCT => itemLSCT.CreateDate).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra lichsuchungtu có số phiếu chưa
        /// </summary>
        /// <param name="SoPhieu"></param>
        /// <returns></returns>
        public bool CheckLichSuChungTu(decimal SoPhieu)
        {
            try
            {
                return db.ChungTu_LichSus.Any(itemLSCT => itemLSCT.SoPhieu == SoPhieu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckMaDonbyDanhBoChungTu(string DanhBo, string MaCT)
        {
            try
            {
                return db.ChungTu_LichSus.Any(itemLSCT => itemLSCT.DanhBo == DanhBo && itemLSCT.MaCT == MaCT && itemLSCT.MaDon != null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Lấy Mã Đơn với Danh Bộ và Chứng Từ
        /// </summary>
        /// <param name="DanhBo"></param>
        /// <param name="MaCT"></param>
        /// <returns></returns>
        public decimal getMaDonbyDanhBoChungTu(string DanhBo, string MaCT)
        {
            try
            {
                return db.ChungTu_LichSus.FirstOrDefault(itemLSCT => itemLSCT.DanhBo == DanhBo && itemLSCT.MaCT == MaCT && itemLSCT.MaDon != null).MaDon.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        #endregion

        #region Method

        /// <summary>
        /// Dùng cho Form Cập Nhật Sổ Đăng Ký, khi có >2 yêu cầu cắt nhân khẩu
        /// </summary>
        /// <param name="chungtu"></param>
        /// <param name="ctchungtu"></param>
        /// <param name="lichsuchungtu"></param>
        /// <param name="lstLichSuChungTu"></param>
        /// <returns></returns>
        //public bool ThemChungTu(ChungTu chungtu, ChungTu_ChiTiet ctchungtu, ChungTu_LichSu lichsuchungtu)
        //{
        //    try
        //    {
        //        ///Kiểm tra nếu ChungTu(sổ đăng ký) chưa có thì thêm vào
        //        if (!CheckChungTu(chungtu.MaCT))
        //        {
        //            chungtu.SoNKConLai = chungtu.SoNKTong;
        //            ////chungtu.CreateDate = DateTime.Now;
        //            ////chungtu.CreateBy = CTaiKhoan.TaiKhoan;
        //            ////db.ChungTus.InsertOnSubmit(chungtu);
        //            ////db.SubmitChanges();
        //            ThemChungTu(chungtu);
        //        }
        //        ///Kiểm tra nếu ChungTu_ChiTiet(danh bộ, sổ đăng ký) chưa có thì thêm vào
        //        if (!CheckCTChungTu(ctchungtu.DanhBo, ctchungtu.MaCT))
        //        {
        //            ChungTu chungtuCN = getChungTubyID(ctchungtu.MaCT);
        //            ///Kiểm tra Số Nhân Khẩu còn có thể cấp
        //            if (chungtuCN.SoNKConLai >= ctchungtu.SoNKDangKy)
        //            {
        //                ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
        //                if (ctchungtu.ThoiHan != null)
        //                    ctchungtu.NgayHetHan = DateTime.Now.AddMonths(ctchungtu.ThoiHan.Value);
        //                else
        //                    ctchungtu.NgayHetHan = null;
        //                //ctchungtu.CreateDate = DateTime.Now;
        //                //ctchungtu.CreateBy = CTaiKhoan.TaiKhoan;
        //                //db.ChungTu_ChiTiets.InsertOnSubmit(ctchungtu);
        //                ThemCTChungTu(ctchungtu);

        //                ///Cập nhật Số Nhân Khẩu Cấp cho bảng ChungTu
        //                chungtuCN.SoNKConLai = chungtuCN.SoNKConLai - ctchungtu.SoNKDangKy;
        //                chungtuCN.SoNKDaCap = ctchungtu.SoNKDangKy;
        //                db.SubmitChanges();

        //                ///Cập nhật bảng ChungTu_LichSu
        //                lichsuchungtu.MaCT = ctchungtu.MaCT;
        //                lichsuchungtu.DanhBo = ctchungtu.DanhBo;
        //                lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
        //                lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
        //                lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
        //                lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
        //                lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;
        //                if (ctchungtu.YeuCauCat)
        //                {
        //                    lichsuchungtu.SoPhieu = getMaxNextSoPhieuLSCT();
        //                    ctchungtu.SoPhieu = lichsuchungtu.SoPhieu;
        //                    lichsuchungtu.YeuCauCat = true;

        //                    lichsuchungtu.CatNK_MaCN = ctchungtu.CatNK_MaCN;
        //                    lichsuchungtu.CatNK_DanhBo = ctchungtu.CatNK_DanhBo;
        //                    lichsuchungtu.CatNK_HoTen = ctchungtu.CatNK_HoTen;
        //                    lichsuchungtu.CatNK_DiaChi = ctchungtu.CatNK_DiaChi;
        //                    lichsuchungtu.SoNK = ctchungtu.CatNK_SoNKCat;
        //                    CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        //                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
        //                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
        //                        lichsuchungtu.ChucVu = "GIÁM ĐỐC";
        //                    else
        //                        lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
        //                    lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
        //                    lichsuchungtu.PhieuDuocKy = true;


        //                }
        //                if (ThemLichSuChungTu(lichsuchungtu) && ctchungtu.YeuCauCat)
        //                {
        //                    ctchungtu.SoPhieu = lichsuchungtu.SoPhieu;
        //                    //CatChuyenDM catchuyendm = new CatChuyenDM();
        //                    //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
        //                    //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
        //                }

        //                if (ctchungtu.YeuCauCat2)
        //                {
        //                    ChungTu_LichSu lichsuchungtu2 = new ChungTu_LichSu();
        //                    if (lichsuchungtu.MaDon != null)
        //                        lichsuchungtu2.MaDon = lichsuchungtu.MaDon;
        //                    if (lichsuchungtu.MaDonTXL != null)
        //                        lichsuchungtu2.MaDonTXL = lichsuchungtu.MaDonTXL;
        //                    else
        //                        if (lichsuchungtu.MaDonTBC != null)
        //                            lichsuchungtu2.MaDonTBC = lichsuchungtu.MaDonTBC;

        //                    lichsuchungtu2.MaCT = ctchungtu.MaCT;
        //                    lichsuchungtu2.DanhBo = ctchungtu.DanhBo;
        //                    lichsuchungtu2.SoNKTong = chungtuCN.SoNKTong;
        //                    lichsuchungtu2.SoNKDangKy = ctchungtu.SoNKDangKy;
        //                    lichsuchungtu2.SoNKConLai = chungtuCN.SoNKConLai;
        //                    lichsuchungtu2.ThoiHan = ctchungtu.ThoiHan;
        //                    lichsuchungtu2.NgayHetHan = ctchungtu.NgayHetHan;
        //                    ///
        //                    lichsuchungtu2.SoPhieu = getMaxNextSoPhieuLSCT();
        //                    ctchungtu.SoPhieu2 = lichsuchungtu2.SoPhieu;
        //                    ///
        //                    lichsuchungtu2.NhanNK_DanhBo = lichsuchungtu.NhanNK_DanhBo;
        //                    lichsuchungtu2.NhanNK_HoTen = lichsuchungtu.NhanNK_HoTen;
        //                    lichsuchungtu2.NhanNK_DiaChi = lichsuchungtu.NhanNK_DiaChi;
        //                    ///
        //                    lichsuchungtu2.YeuCauCat = true;
        //                    lichsuchungtu2.CatNK_MaCN = ctchungtu.CatNK_MaCN2;
        //                    lichsuchungtu2.CatNK_DanhBo = ctchungtu.CatNK_DanhBo2;
        //                    lichsuchungtu2.CatNK_HoTen = ctchungtu.CatNK_HoTen2;
        //                    lichsuchungtu2.CatNK_DiaChi = ctchungtu.CatNK_DiaChi2;
        //                    lichsuchungtu2.SoNK = ctchungtu.CatNK_SoNKCat2;

        //                    CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        //                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
        //                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
        //                        lichsuchungtu2.ChucVu = "GIÁM ĐỐC";
        //                    else
        //                        lichsuchungtu2.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
        //                    lichsuchungtu2.NguoiKy = bangiamdoc.HoTen.ToUpper();
        //                    lichsuchungtu2.PhieuDuocKy = true;

        //                    if (ThemLichSuChungTu(lichsuchungtu2))
        //                    {
        //                        ctchungtu.SoPhieu2 = lichsuchungtu2.SoPhieu;
        //                        //CatChuyenDM catchuyendm = new CatChuyenDM();
        //                        //LSCTtoCCDM(lichsuchungtu2, ref catchuyendm);
        //                        //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
        //                    }
        //                }

        //                if (ctchungtu.YeuCauCat3)
        //                {
        //                    ChungTu_LichSu lichsuchungtu3 = new ChungTu_LichSu();
        //                    if (lichsuchungtu.MaDon != null)
        //                        lichsuchungtu3.MaDon = lichsuchungtu.MaDon;
        //                    if (lichsuchungtu.MaDonTXL != null)
        //                        lichsuchungtu3.MaDonTXL = lichsuchungtu.MaDonTXL;
        //                    else
        //                        if (lichsuchungtu.MaDonTBC != null)
        //                            lichsuchungtu3.MaDonTBC = lichsuchungtu.MaDonTBC;
        //                    lichsuchungtu3.MaCT = ctchungtu.MaCT;
        //                    lichsuchungtu3.DanhBo = ctchungtu.DanhBo;
        //                    lichsuchungtu3.SoNKTong = chungtuCN.SoNKTong;
        //                    lichsuchungtu3.SoNKDangKy = ctchungtu.SoNKDangKy;
        //                    lichsuchungtu3.SoNKConLai = chungtuCN.SoNKConLai;
        //                    lichsuchungtu3.ThoiHan = ctchungtu.ThoiHan;
        //                    lichsuchungtu3.NgayHetHan = ctchungtu.NgayHetHan;
        //                    ///
        //                    lichsuchungtu3.SoPhieu = getMaxNextSoPhieuLSCT();
        //                    ctchungtu.SoPhieu3 = lichsuchungtu3.SoPhieu;
        //                    ///
        //                    lichsuchungtu3.NhanNK_DanhBo = lichsuchungtu.NhanNK_DanhBo;
        //                    lichsuchungtu3.NhanNK_HoTen = lichsuchungtu.NhanNK_HoTen;
        //                    lichsuchungtu3.NhanNK_DiaChi = lichsuchungtu.NhanNK_DiaChi;
        //                    ///
        //                    lichsuchungtu3.YeuCauCat = true;
        //                    lichsuchungtu3.CatNK_MaCN = ctchungtu.CatNK_MaCN3;
        //                    lichsuchungtu3.CatNK_DanhBo = ctchungtu.CatNK_DanhBo3;
        //                    lichsuchungtu3.CatNK_HoTen = ctchungtu.CatNK_HoTen3;
        //                    lichsuchungtu3.CatNK_DiaChi = ctchungtu.CatNK_DiaChi3;
        //                    lichsuchungtu3.SoNK = ctchungtu.CatNK_SoNKCat3;

        //                    CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        //                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
        //                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
        //                        lichsuchungtu3.ChucVu = "GIÁM ĐỐC";
        //                    else
        //                        lichsuchungtu3.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
        //                    lichsuchungtu3.NguoiKy = bangiamdoc.HoTen.ToUpper();
        //                    lichsuchungtu3.PhieuDuocKy = true;

        //                    if (ThemLichSuChungTu(lichsuchungtu3))
        //                    {
        //                        ctchungtu.SoPhieu3 = lichsuchungtu3.SoPhieu;
        //                        //CatChuyenDM catchuyendm = new CatChuyenDM();
        //                        //LSCTtoCCDM(lichsuchungtu3, ref catchuyendm);
        //                        //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
        //                    }
        //                }

        //                if (ctchungtu.YeuCauCat4)
        //                {
        //                    ChungTu_LichSu lichsuchungtu4 = new ChungTu_LichSu();
        //                    if (lichsuchungtu.MaDon != null)
        //                        lichsuchungtu4.MaDon = lichsuchungtu.MaDon;
        //                    if (lichsuchungtu.MaDonTXL != null)
        //                        lichsuchungtu4.MaDonTXL = lichsuchungtu.MaDonTXL;
        //                    else
        //                        if (lichsuchungtu.MaDonTBC != null)
        //                            lichsuchungtu4.MaDonTBC = lichsuchungtu.MaDonTBC;
        //                    lichsuchungtu4.MaCT = ctchungtu.MaCT;
        //                    lichsuchungtu4.DanhBo = ctchungtu.DanhBo;
        //                    lichsuchungtu4.SoNKTong = chungtuCN.SoNKTong;
        //                    lichsuchungtu4.SoNKDangKy = ctchungtu.SoNKDangKy;
        //                    lichsuchungtu4.SoNKConLai = chungtuCN.SoNKConLai;
        //                    lichsuchungtu4.ThoiHan = ctchungtu.ThoiHan;
        //                    lichsuchungtu4.NgayHetHan = ctchungtu.NgayHetHan;
        //                    ///
        //                    lichsuchungtu4.SoPhieu = getMaxNextSoPhieuLSCT();
        //                    ctchungtu.SoPhieu2 = lichsuchungtu4.SoPhieu;
        //                    ///
        //                    lichsuchungtu4.NhanNK_DanhBo = lichsuchungtu.NhanNK_DanhBo;
        //                    lichsuchungtu4.NhanNK_HoTen = lichsuchungtu.NhanNK_HoTen;
        //                    lichsuchungtu4.NhanNK_DiaChi = lichsuchungtu.NhanNK_DiaChi;
        //                    ///
        //                    lichsuchungtu4.YeuCauCat = true;
        //                    lichsuchungtu4.CatNK_MaCN = ctchungtu.CatNK_MaCN4;
        //                    lichsuchungtu4.CatNK_DanhBo = ctchungtu.CatNK_DanhBo4;
        //                    lichsuchungtu4.CatNK_HoTen = ctchungtu.CatNK_HoTen4;
        //                    lichsuchungtu4.CatNK_DiaChi = ctchungtu.CatNK_DiaChi4;
        //                    lichsuchungtu4.SoNK = ctchungtu.CatNK_SoNKCat4;

        //                    CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        //                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
        //                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
        //                        lichsuchungtu4.ChucVu = "GIÁM ĐỐC";
        //                    else
        //                        lichsuchungtu4.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
        //                    lichsuchungtu4.NguoiKy = bangiamdoc.HoTen.ToUpper();
        //                    lichsuchungtu4.PhieuDuocKy = true;

        //                    if (ThemLichSuChungTu(lichsuchungtu4))
        //                    {
        //                        ctchungtu.SoPhieu4 = lichsuchungtu4.SoPhieu;
        //                        //CatChuyenDM catchuyendm = new CatChuyenDM();
        //                        //LSCTtoCCDM(lichsuchungtu4, ref catchuyendm);
        //                        //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
        //                    }
        //                }

        //                if (ctchungtu.YeuCauCat5)
        //                {
        //                    ChungTu_LichSu lichsuchungtu5 = new ChungTu_LichSu();
        //                    if (lichsuchungtu.MaDon != null)
        //                        lichsuchungtu5.MaDon = lichsuchungtu.MaDon;
        //                    if (lichsuchungtu.MaDonTXL != null)
        //                        lichsuchungtu5.MaDonTXL = lichsuchungtu.MaDonTXL;
        //                    else
        //                        if (lichsuchungtu.MaDonTBC != null)
        //                            lichsuchungtu5.MaDonTBC = lichsuchungtu.MaDonTBC;
        //                    lichsuchungtu5.MaCT = ctchungtu.MaCT;
        //                    lichsuchungtu5.DanhBo = ctchungtu.DanhBo;
        //                    lichsuchungtu5.SoNKTong = chungtuCN.SoNKTong;
        //                    lichsuchungtu5.SoNKDangKy = ctchungtu.SoNKDangKy;
        //                    lichsuchungtu5.SoNKConLai = chungtuCN.SoNKConLai;
        //                    lichsuchungtu5.ThoiHan = ctchungtu.ThoiHan;
        //                    lichsuchungtu5.NgayHetHan = ctchungtu.NgayHetHan;
        //                    ///
        //                    lichsuchungtu5.SoPhieu = getMaxNextSoPhieuLSCT();
        //                    ctchungtu.SoPhieu2 = lichsuchungtu5.SoPhieu;
        //                    ///
        //                    lichsuchungtu5.NhanNK_DanhBo = lichsuchungtu.NhanNK_DanhBo;
        //                    lichsuchungtu5.NhanNK_HoTen = lichsuchungtu.NhanNK_HoTen;
        //                    lichsuchungtu5.NhanNK_DiaChi = lichsuchungtu.NhanNK_DiaChi;
        //                    ///
        //                    lichsuchungtu5.YeuCauCat = true;
        //                    lichsuchungtu5.CatNK_MaCN = ctchungtu.CatNK_MaCN5;
        //                    lichsuchungtu5.CatNK_DanhBo = ctchungtu.CatNK_DanhBo5;
        //                    lichsuchungtu5.CatNK_HoTen = ctchungtu.CatNK_HoTen5;
        //                    lichsuchungtu5.CatNK_DiaChi = ctchungtu.CatNK_DiaChi5;
        //                    lichsuchungtu5.SoNK = ctchungtu.CatNK_SoNKCat5;

        //                    CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        //                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
        //                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
        //                        lichsuchungtu5.ChucVu = "GIÁM ĐỐC";
        //                    else
        //                        lichsuchungtu5.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
        //                    lichsuchungtu5.NguoiKy = bangiamdoc.HoTen.ToUpper();
        //                    lichsuchungtu5.PhieuDuocKy = true;

        //                    if (ThemLichSuChungTu(lichsuchungtu5))
        //                    {
        //                        ctchungtu.SoPhieu5 = lichsuchungtu5.SoPhieu;
        //                        //CatChuyenDM catchuyendm = new CatChuyenDM();
        //                        //LSCTtoCCDM(lichsuchungtu5, ref catchuyendm);
        //                        //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
        //                    }
        //                }
        //                db.SubmitChanges();

        //                //for (int i = 0; i < lstLichSuChungTu.Count; i++)
        //                //{
        //                //    ///Cập nhật bảng ChungTu_LichSu
        //                //    lstLichSuChungTu[i].MaCT = ctchungtu.MaCT;
        //                //    lstLichSuChungTu[i].DanhBo = ctchungtu.DanhBo;
        //                //    lstLichSuChungTu[i].SoNKTong = chungtuCN.SoNKTong;
        //                //    lstLichSuChungTu[i].SoNKDangKy = ctchungtu.SoNKDangKy;
        //                //    lstLichSuChungTu[i].SoNKConLai = chungtuCN.SoNKConLai;
        //                //    lstLichSuChungTu[i].ThoiHan = ctchungtu.ThoiHan;
        //                //    lstLichSuChungTu[i].NgayHetHan = ctchungtu.NgayHetHan;
        //                //    ///
        //                //    lstLichSuChungTu[i].SoPhieu = getMaxNextSoPhieuLSCT();
        //                //    switch (i)
        //                //    {
        //                //        case 0:
        //                //            ctchungtu.SoPhieu2 = lstLichSuChungTu[i].SoPhieu;
        //                //            break;
        //                //        case 1:
        //                //            ctchungtu.SoPhieu3 = lstLichSuChungTu[i].SoPhieu;
        //                //            break;
        //                //        case 2:
        //                //            ctchungtu.SoPhieu4 = lstLichSuChungTu[i].SoPhieu;
        //                //            break;
        //                //        case 3:
        //                //            ctchungtu.SoPhieu5 = lstLichSuChungTu[i].SoPhieu;
        //                //            break;
        //                //    }

        //                //    lstLichSuChungTu[i].NhanDM = true;
        //                //    lstLichSuChungTu[i].YCCat = true;

        //                //    lstLichSuChungTu[i].CatNK_MaCN = ctchungtu.CatNK_MaCN;
        //                //    lstLichSuChungTu[i].CatNK_DanhBo = ctchungtu.CatNK_DanhBo;
        //                //    lstLichSuChungTu[i].CatNK_HoTen = ctchungtu.CatNK_HoTen;
        //                //    lstLichSuChungTu[i].CatNK_DiaChi = ctchungtu.CatNK_DiaChi;
        //                //    lstLichSuChungTu[i].SoNKNhan = ctchungtu.CatNK_SoNKCat;
        //                //    CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        //                //    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
        //                //    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
        //                //        lstLichSuChungTu[i].ChucVu = "GIÁM ĐỐC";
        //                //    else
        //                //        lstLichSuChungTu[i].ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
        //                //    lstLichSuChungTu[i].NguoiKy = bangiamdoc.HoTen.ToUpper();

        //                //    ThemLichSuChungTu(lstLichSuChungTu[i]);
        //                //}
        //                //MessageBox.Show("Thành công Thêm ChungTu Method", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                return true;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Sổ này đã được đăng ký với Danh Bộ này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        db = new dbKinhDoanhDataContext();
        //        return false;
        //    }
        //}

        /// <summary>
        /// Dùng cho Form Cập Nhật Sổ Đăng Ký, khi có >2 yêu cầu cắt nhân khẩu
        /// </summary>
        /// <param name="chungtu"></param>
        /// <param name="ctchungtu"></param>
        /// <param name="lichsuchungtu"></param>
        /// <param name="lstLichSuChungTu"></param>
        /// <returns></returns>
        //public bool SuaChungTu(ChungTu chungtu, ChungTu_ChiTiet ctchungtu, ChungTu_LichSu lichsuchungtu)
        //{
        //    try
        //    {
        //        bool flagEdited = false;
        //        bool flagGiam = false;
        //        ///Cập Nhật bảng ChungTu khi thay đổi Tổng Nhân Khẩu (frmSoDK)
        //        ChungTu chungtuCN = getChungTubyID(chungtu.MaCT);
        //        ///Kiểm tra Tổng Nhân Khẩu có thay đổi hay không
        //        if (chungtuCN.SoNKTong != chungtu.SoNKTong)
        //            if (chungtu.SoNKTong - chungtuCN.SoNKTong + chungtuCN.SoNKConLai >= 0)
        //            {
        //                chungtuCN.SoNKConLai = chungtu.SoNKTong - chungtuCN.SoNKTong + chungtuCN.SoNKConLai;
        //                chungtuCN.SoNKTong = chungtu.SoNKTong;
        //                chungtuCN.ModifyDate = DateTime.Now;
        //                chungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //                flagEdited = true;
        //            }
        //            else
        //            {
        //                chungtuCN.SoNKConLai = chungtu.SoNKTong;
        //                chungtuCN.SoNKTong = chungtu.SoNKTong;
        //                chungtuCN.ModifyDate = DateTime.Now;
        //                chungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //                flagEdited = true;
        //                flagGiam = true;
        //                //MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                //return false;
        //            }
        //        ///Kiểm tra Địa Chỉ có thay đổi hay không
        //        if (chungtuCN.DiaChi != chungtu.DiaChi || chungtuCN.MaLCT != chungtu.MaLCT)
        //        {
        //            if (chungtuCN.DiaChi != chungtu.DiaChi)
        //                chungtuCN.DiaChi = chungtu.DiaChi;
        //            if (chungtuCN.MaLCT != chungtu.MaLCT)
        //                chungtuCN.MaLCT = chungtu.MaLCT;
        //            chungtuCN.ModifyDate = DateTime.Now;
        //            chungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //        }

        //        ///Cập Nhật bảng ChungTu_ChiTiet khi thay đổi Số Nhân Khẩu đăng ký (frmSoDK)
        //        ChungTu_ChiTiet ctchungtuCN = getCTChungTubyID(ctchungtu.DanhBo, ctchungtu.MaCT);
        //        ///Kiểm tra Số Nhân Khẩu đăng ký có thay đổi hay không
        //        if (ctchungtuCN.SoNKDangKy != ctchungtu.SoNKDangKy)
        //            if (flagGiam)
        //            {
        //                ///Cập nhật Số Nhân Khẩu Cấp cho bảng ChungTu
        //                chungtuCN.SoNKConLai = chungtuCN.SoNKConLai - ctchungtu.SoNKDangKy;
        //                chungtuCN.SoNKDaCap = ctchungtu.SoNKDangKy;
        //                chungtuCN.ModifyDate = DateTime.Now;
        //                chungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //                ///Cập nhật bảng ChungTu_ChiTiet
        //                ctchungtuCN.SoNKDangKy = ctchungtu.SoNKDangKy;
        //                ctchungtuCN.ModifyDate = DateTime.Now;
        //                ctchungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //                flagEdited = true;
        //            }
        //            else
        //                if (chungtuCN.SoNKConLai >= ctchungtu.SoNKDangKy - ctchungtuCN.SoNKDangKy)
        //                {
        //                    ///Cập nhật Số Nhân Khẩu Cấp cho bảng ChungTu
        //                    chungtuCN.SoNKConLai = chungtuCN.SoNKConLai - (ctchungtu.SoNKDangKy - ctchungtuCN.SoNKDangKy);
        //                    chungtuCN.SoNKDaCap = ctchungtu.SoNKDangKy;
        //                    chungtuCN.ModifyDate = DateTime.Now;
        //                    chungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //                    ///Cập nhật bảng ChungTu_ChiTiet
        //                    ctchungtuCN.SoNKDangKy = ctchungtu.SoNKDangKy;

        //                    //ctchungtuCN.ThoiHan = ctchungtu.ThoiHan;
        //                    //if (ctchungtu.ThoiHan != null)
        //                    //    ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
        //                    //    ctchungtuCN.NgayHetHan = ctchungtuCN.CreateDate.Value.AddMonths(ctchungtu.ThoiHan.Value);
        //                    //else
        //                    //    ctchungtuCN.NgayHetHan = null;

        //                    ctchungtuCN.ModifyDate = DateTime.Now;
        //                    ctchungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //                    flagEdited = true;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return false;
        //                }
        //        if (ctchungtuCN.ThoiHan != ctchungtu.ThoiHan || ctchungtuCN.Lo != ctchungtu.Lo || ctchungtuCN.Phong != ctchungtu.Phong || ctchungtuCN.GhiChu != ctchungtu.GhiChu || (ctchungtuCN.NgayHetHan != ctchungtu.NgayHetHan && ctchungtu.NgayHetHan != null))
        //        {
        //            if (ctchungtuCN.ThoiHan != ctchungtu.ThoiHan)
        //            {
        //                ctchungtuCN.ThoiHan = ctchungtu.ThoiHan;
        //                if (ctchungtu.ThoiHan != null)
        //                {
        //                    ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
        //                    ///Khi gia hạn refresh lại ngày tạo để tính ngày gia hạn
        //                    if (ctchungtuCN.CreateDateGoc == null)
        //                        ctchungtuCN.CreateDateGoc = ctchungtuCN.CreateDate;
        //                    ctchungtuCN.CreateDate = DateTime.Now;
        //                    ctchungtuCN.NgayHetHan = ctchungtuCN.CreateDate.Value.AddMonths(ctchungtu.ThoiHan.Value);
        //                }
        //                else
        //                    ctchungtuCN.NgayHetHan = null;
        //                flagEdited = true;
        //            }
        //            if (ctchungtu.NgayHetHan != null)
        //            {
        //                if (ctchungtuCN.CreateDateGoc == null)
        //                    ctchungtuCN.CreateDateGoc = ctchungtuCN.CreateDate;
        //                ctchungtuCN.CreateDate = DateTime.Now;
        //                ctchungtuCN.NgayHetHan = ctchungtu.NgayHetHan;
        //                flagEdited = true;
        //            }
        //            if (ctchungtuCN.Lo != ctchungtu.Lo)
        //                ctchungtuCN.Lo = ctchungtu.Lo;
        //            if (ctchungtuCN.Phong != ctchungtu.Phong)
        //                ctchungtuCN.Phong = ctchungtu.Phong;
        //            if (ctchungtuCN.GhiChu != ctchungtu.GhiChu)
        //                ctchungtuCN.GhiChu = ctchungtu.GhiChu;
        //            ctchungtuCN.ModifyDate = DateTime.Now;
        //            ctchungtuCN.ModifyBy = CTaiKhoan.MaUser;

        //        }
        //        //if (ctchungtu.YeuCauCat != ctchungtuCN.YeuCauCat)
        //        if (ctchungtu.YeuCauCat)
        //        {
        //            //chungtuCN.YeuCauCat = true;
        //            //chungtuCN.CatNK_MaCN = chungtu.CatNK_MaCN;
        //            //chungtuCN.CatNK_DanhBo = chungtu.CatNK_DanhBo;
        //            //chungtuCN.CatNK_HoTen = chungtu.CatNK_HoTen;
        //            //chungtuCN.CatNK_DiaChi = chungtu.CatNK_DiaChi;
        //            //chungtuCN.CatNK_SoNKCat = chungtu.CatNK_SoNKCat;
        //            ///
        //            ctchungtuCN.YeuCauCat = true;
        //            ctchungtuCN.CatNK_MaCN = ctchungtu.CatNK_MaCN;
        //            ctchungtuCN.CatNK_DanhBo = ctchungtu.CatNK_DanhBo;
        //            ctchungtuCN.CatNK_HoTen = ctchungtu.CatNK_HoTen;
        //            ctchungtuCN.CatNK_DiaChi = ctchungtu.CatNK_DiaChi;
        //            ctchungtuCN.CatNK_SoNKCat = ctchungtu.CatNK_SoNKCat;
        //            ///Nếu phiếu đã có
        //            if (ctchungtuCN.SoPhieu.HasValue)
        //            {
        //                ChungTu_LichSu lichsuchungtuCN = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu.Value);
        //                lichsuchungtuCN.CatNK_MaCN = ctchungtu.CatNK_MaCN;
        //                lichsuchungtuCN.CatNK_DanhBo = ctchungtu.CatNK_DanhBo;
        //                lichsuchungtuCN.CatNK_HoTen = ctchungtu.CatNK_HoTen;
        //                lichsuchungtuCN.CatNK_DiaChi = ctchungtu.CatNK_DiaChi;
        //                lichsuchungtuCN.SoNK = ctchungtu.CatNK_SoNKCat;
        //                if (SuaLichSuChungTu(lichsuchungtuCN))
        //                {
        //                    //CatChuyenDM catchuyendm = _cCatChuyenDM.getCatChuyenDMbySoPhieu(ctchungtuCN.SoPhieu.Value);
        //                    //catchuyendm.CatNK_MaCN = lichsuchungtuCN.CatNK_MaCN;
        //                    //catchuyendm.CatNK_DanhBo = lichsuchungtuCN.CatNK_DanhBo;
        //                    //catchuyendm.CatNK_HoTen = lichsuchungtuCN.CatNK_HoTen;
        //                    //catchuyendm.CatNK_DiaChi = lichsuchungtuCN.CatNK_DiaChi;
        //                    //catchuyendm.SoNKNhan = lichsuchungtuCN.SoNKNhan;

        //                    //_cCatChuyenDM.SuaCatChuyemDM(catchuyendm);
        //                }
        //            }
        //            ///Nếu chưa có phiếu
        //            else
        //            {
        //                lichsuchungtu.MaCT = ctchungtu.MaCT;
        //                lichsuchungtu.DanhBo = ctchungtu.DanhBo;
        //                lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
        //                lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
        //                lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
        //                lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
        //                lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;
        //                ///
        //                lichsuchungtu.SoPhieu = getMaxNextSoPhieuLSCT();
        //                //ctchungtuCN.SoPhieu = lichsuchungtu.SoPhieu;
        //                lichsuchungtu.YeuCauCat = true;

        //                lichsuchungtu.CatNK_MaCN = ctchungtu.CatNK_MaCN;
        //                lichsuchungtu.CatNK_DanhBo = ctchungtu.CatNK_DanhBo;
        //                lichsuchungtu.CatNK_HoTen = ctchungtu.CatNK_HoTen;
        //                lichsuchungtu.CatNK_DiaChi = ctchungtu.CatNK_DiaChi;
        //                lichsuchungtu.SoNK = ctchungtu.CatNK_SoNKCat;
        //                CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        //                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
        //                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
        //                    lichsuchungtu.ChucVu = "GIÁM ĐỐC";
        //                else
        //                    lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
        //                lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
        //                if (ThemLichSuChungTu(lichsuchungtu))
        //                {
        //                    ctchungtuCN.SoPhieu = lichsuchungtu.SoPhieu;

        //                    //CatChuyenDM catchuyendm = new CatChuyenDM();
        //                    //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
        //                    //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ctchungtuCN.YeuCauCat = false;
        //            if (ctchungtuCN.SoPhieu.HasValue)
        //            {
        //                ChungTu_LichSu lichsuchungtuCN = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu.Value);
        //                XoaLichSuChungTu(lichsuchungtuCN);
        //            }
        //        }

        //        #region Yêu Cầu Cắt 2,3,4,5

        //        //if (ctchungtu.YeuCauCat2 != ctchungtuCN.YeuCauCat2)
        //        if (ctchungtu.YeuCauCat2)
        //        {
        //            ctchungtuCN.YeuCauCat2 = true;
        //            ctchungtuCN.CatNK_MaCN2 = ctchungtu.CatNK_MaCN2;
        //            ctchungtuCN.CatNK_DanhBo2 = ctchungtu.CatNK_DanhBo2;
        //            ctchungtuCN.CatNK_HoTen2 = ctchungtu.CatNK_HoTen2;
        //            ctchungtuCN.CatNK_DiaChi2 = ctchungtu.CatNK_DiaChi2;
        //            ctchungtuCN.CatNK_SoNKCat2 = ctchungtu.CatNK_SoNKCat2;
        //            ///
        //            if (ctchungtuCN.SoPhieu2.HasValue)
        //            {
        //                ChungTu_LichSu lichsuchungtuCN2 = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu2.Value);
        //                lichsuchungtuCN2.CatNK_MaCN = ctchungtu.CatNK_MaCN2;
        //                lichsuchungtuCN2.CatNK_DanhBo = ctchungtu.CatNK_DanhBo2;
        //                lichsuchungtuCN2.CatNK_HoTen = ctchungtu.CatNK_HoTen2;
        //                lichsuchungtuCN2.CatNK_DiaChi = ctchungtu.CatNK_DiaChi2;
        //                lichsuchungtuCN2.SoNK = ctchungtu.CatNK_SoNKCat2;
        //                if (SuaLichSuChungTu(lichsuchungtuCN2))
        //                {
        //                    //CatChuyenDM catchuyendm = _cCatChuyenDM.getCatChuyenDMbySoPhieu(ctchungtuCN.SoPhieu2.Value);
        //                    //catchuyendm.CatNK_MaCN = lichsuchungtuCN2.CatNK_MaCN;
        //                    //catchuyendm.CatNK_DanhBo = lichsuchungtuCN2.CatNK_DanhBo;
        //                    //catchuyendm.CatNK_HoTen = lichsuchungtuCN2.CatNK_HoTen;
        //                    //catchuyendm.CatNK_DiaChi = lichsuchungtuCN2.CatNK_DiaChi;
        //                    //catchuyendm.SoNKNhan = lichsuchungtuCN2.SoNKNhan;

        //                    //_cCatChuyenDM.SuaCatChuyemDM(catchuyendm);
        //                }
        //            }
        //            else
        //            {
        //                lichsuchungtu.MaCT = ctchungtu.MaCT;
        //                lichsuchungtu.DanhBo = ctchungtu.DanhBo;
        //                lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
        //                lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
        //                lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
        //                lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
        //                lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;
        //                ///
        //                lichsuchungtu.SoPhieu = getMaxNextSoPhieuLSCT();
        //                //ctchungtuCN.SoPhieu2 = lichsuchungtu.SoPhieu;
        //                lichsuchungtu.YeuCauCat = true;

        //                lichsuchungtu.CatNK_MaCN = ctchungtu.CatNK_MaCN2;
        //                lichsuchungtu.CatNK_DanhBo = ctchungtu.CatNK_DanhBo2;
        //                lichsuchungtu.CatNK_HoTen = ctchungtu.CatNK_HoTen2;
        //                lichsuchungtu.CatNK_DiaChi = ctchungtu.CatNK_DiaChi2;
        //                lichsuchungtu.SoNK = ctchungtu.CatNK_SoNKCat2;
        //                CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        //                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
        //                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
        //                    lichsuchungtu.ChucVu = "GIÁM ĐỐC";
        //                else
        //                    lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
        //                lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
        //                if (ThemLichSuChungTu(lichsuchungtu))
        //                {
        //                    ctchungtuCN.SoPhieu2 = lichsuchungtu.SoPhieu;
        //                    //CatChuyenDM catchuyendm = new CatChuyenDM();
        //                    //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
        //                    //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ctchungtuCN.YeuCauCat2 = false;
        //            if (ctchungtuCN.SoPhieu2.HasValue)
        //            {
        //                ChungTu_LichSu lichsuchungtuCN = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu2.Value);
        //                XoaLichSuChungTu(lichsuchungtuCN);
        //            }
        //        }

        //        //if (ctchungtu.YeuCauCat3 != ctchungtuCN.YeuCauCat3)
        //        if (ctchungtu.YeuCauCat3)
        //        {
        //            ctchungtuCN.YeuCauCat3 = true;
        //            ctchungtuCN.CatNK_MaCN3 = ctchungtu.CatNK_MaCN3;
        //            ctchungtuCN.CatNK_DanhBo3 = ctchungtu.CatNK_DanhBo3;
        //            ctchungtuCN.CatNK_HoTen3 = ctchungtu.CatNK_HoTen3;
        //            ctchungtuCN.CatNK_DiaChi3 = ctchungtu.CatNK_DiaChi3;
        //            ctchungtuCN.CatNK_SoNKCat3 = ctchungtu.CatNK_SoNKCat3;
        //            ///
        //            if (ctchungtuCN.SoPhieu3.HasValue)
        //            {
        //                ChungTu_LichSu lichsuchungtuCN3 = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu3.Value);
        //                lichsuchungtuCN3.CatNK_MaCN = ctchungtu.CatNK_MaCN3;
        //                lichsuchungtuCN3.CatNK_DanhBo = ctchungtu.CatNK_DanhBo3;
        //                lichsuchungtuCN3.CatNK_HoTen = ctchungtu.CatNK_HoTen3;
        //                lichsuchungtuCN3.CatNK_DiaChi = ctchungtu.CatNK_DiaChi3;
        //                lichsuchungtuCN3.SoNK = ctchungtu.CatNK_SoNKCat3;
        //                if (SuaLichSuChungTu(lichsuchungtuCN3))
        //                {
        //                    //CatChuyenDM catchuyendm = _cCatChuyenDM.getCatChuyenDMbySoPhieu(ctchungtuCN.SoPhieu3.Value);
        //                    //catchuyendm.CatNK_MaCN = lichsuchungtuCN3.CatNK_MaCN;
        //                    //catchuyendm.CatNK_DanhBo = lichsuchungtuCN3.CatNK_DanhBo;
        //                    //catchuyendm.CatNK_HoTen = lichsuchungtuCN3.CatNK_HoTen;
        //                    //catchuyendm.CatNK_DiaChi = lichsuchungtuCN3.CatNK_DiaChi;
        //                    //catchuyendm.SoNKNhan = lichsuchungtuCN3.SoNKNhan;

        //                    //_cCatChuyenDM.SuaCatChuyemDM(catchuyendm);
        //                }
        //            }
        //            else
        //            {
        //                lichsuchungtu.MaCT = ctchungtu.MaCT;
        //                lichsuchungtu.DanhBo = ctchungtu.DanhBo;
        //                lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
        //                lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
        //                lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
        //                lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
        //                lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;
        //                ///
        //                lichsuchungtu.SoPhieu = getMaxNextSoPhieuLSCT();
        //                //ctchungtuCN.SoPhieu3 = lichsuchungtu.SoPhieu;
        //                lichsuchungtu.YeuCauCat = true;

        //                lichsuchungtu.CatNK_MaCN = ctchungtu.CatNK_MaCN3;
        //                lichsuchungtu.CatNK_DanhBo = ctchungtu.CatNK_DanhBo3;
        //                lichsuchungtu.CatNK_HoTen = ctchungtu.CatNK_HoTen3;
        //                lichsuchungtu.CatNK_DiaChi = ctchungtu.CatNK_DiaChi3;
        //                lichsuchungtu.SoNK = ctchungtu.CatNK_SoNKCat3;
        //                CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        //                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
        //                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
        //                    lichsuchungtu.ChucVu = "GIÁM ĐỐC";
        //                else
        //                    lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
        //                lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
        //                if (ThemLichSuChungTu(lichsuchungtu))
        //                {
        //                    ctchungtuCN.SoPhieu3 = lichsuchungtu.SoPhieu;
        //                    //CatChuyenDM catchuyendm = new CatChuyenDM();
        //                    //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
        //                    //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ctchungtuCN.YeuCauCat3 = false;
        //            if (ctchungtuCN.SoPhieu3.HasValue)
        //            {
        //                ChungTu_LichSu lichsuchungtuCN = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu3.Value);
        //                XoaLichSuChungTu(lichsuchungtuCN);
        //            }
        //        }

        //        //if (ctchungtu.YeuCauCat4 != ctchungtuCN.YeuCauCat4)
        //        if (ctchungtu.YeuCauCat4)
        //        {
        //            ctchungtuCN.YeuCauCat4 = true;
        //            ctchungtuCN.CatNK_MaCN4 = ctchungtu.CatNK_MaCN4;
        //            ctchungtuCN.CatNK_DanhBo4 = ctchungtu.CatNK_DanhBo4;
        //            ctchungtuCN.CatNK_HoTen4 = ctchungtu.CatNK_HoTen4;
        //            ctchungtuCN.CatNK_DiaChi4 = ctchungtu.CatNK_DiaChi4;
        //            ctchungtuCN.CatNK_SoNKCat4 = ctchungtu.CatNK_SoNKCat4;
        //            ///
        //            if (ctchungtuCN.SoPhieu4.HasValue)
        //            {
        //                ChungTu_LichSu lichsuchungtuCN4 = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu4.Value);
        //                lichsuchungtuCN4.CatNK_MaCN = ctchungtu.CatNK_MaCN4;
        //                lichsuchungtuCN4.CatNK_DanhBo = ctchungtu.CatNK_DanhBo4;
        //                lichsuchungtuCN4.CatNK_HoTen = ctchungtu.CatNK_HoTen4;
        //                lichsuchungtuCN4.CatNK_DiaChi = ctchungtu.CatNK_DiaChi4;
        //                lichsuchungtuCN4.SoNK = ctchungtu.CatNK_SoNKCat4;
        //                if (SuaLichSuChungTu(lichsuchungtuCN4))
        //                {
        //                    //CatChuyenDM catchuyendm = _cCatChuyenDM.getCatChuyenDMbySoPhieu(ctchungtuCN.SoPhieu4.Value);
        //                    //catchuyendm.CatNK_MaCN = lichsuchungtuCN4.CatNK_MaCN;
        //                    //catchuyendm.CatNK_DanhBo = lichsuchungtuCN4.CatNK_DanhBo;
        //                    //catchuyendm.CatNK_HoTen = lichsuchungtuCN4.CatNK_HoTen;
        //                    //catchuyendm.CatNK_DiaChi = lichsuchungtuCN4.CatNK_DiaChi;
        //                    //catchuyendm.SoNKNhan = lichsuchungtuCN4.SoNKNhan;

        //                    //_cCatChuyenDM.SuaCatChuyemDM(catchuyendm);
        //                }
        //            }
        //            else
        //            {
        //                lichsuchungtu.MaCT = ctchungtu.MaCT;
        //                lichsuchungtu.DanhBo = ctchungtu.DanhBo;
        //                lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
        //                lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
        //                lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
        //                lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
        //                lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;
        //                ///
        //                lichsuchungtu.SoPhieu = getMaxNextSoPhieuLSCT();
        //                //ctchungtuCN.SoPhieu4 = lichsuchungtu.SoPhieu;
        //                lichsuchungtu.YeuCauCat = true;

        //                lichsuchungtu.CatNK_MaCN = ctchungtu.CatNK_MaCN4;
        //                lichsuchungtu.CatNK_DanhBo = ctchungtu.CatNK_DanhBo4;
        //                lichsuchungtu.CatNK_HoTen = ctchungtu.CatNK_HoTen4;
        //                lichsuchungtu.CatNK_DiaChi = ctchungtu.CatNK_DiaChi4;
        //                lichsuchungtu.SoNK = ctchungtu.CatNK_SoNKCat4;
        //                CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        //                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
        //                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
        //                    lichsuchungtu.ChucVu = "GIÁM ĐỐC";
        //                else
        //                    lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
        //                lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
        //                if (ThemLichSuChungTu(lichsuchungtu))
        //                {
        //                    ctchungtuCN.SoPhieu4 = lichsuchungtu.SoPhieu;
        //                    //CatChuyenDM catchuyendm = new CatChuyenDM();
        //                    //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
        //                    //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ctchungtuCN.YeuCauCat4 = false;
        //            if (ctchungtuCN.SoPhieu4.HasValue)
        //            {
        //                ChungTu_LichSu lichsuchungtuCN = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu4.Value);
        //                XoaLichSuChungTu(lichsuchungtuCN);
        //            }
        //        }

        //        //if (ctchungtu.YeuCauCat5 != ctchungtuCN.YeuCauCat5)
        //        if (ctchungtu.YeuCauCat5)
        //        {
        //            ctchungtuCN.YeuCauCat5 = true;
        //            ctchungtuCN.CatNK_MaCN5 = ctchungtu.CatNK_MaCN5;
        //            ctchungtuCN.CatNK_DanhBo5 = ctchungtu.CatNK_DanhBo5;
        //            ctchungtuCN.CatNK_HoTen5 = ctchungtu.CatNK_HoTen5;
        //            ctchungtuCN.CatNK_DiaChi5 = ctchungtu.CatNK_DiaChi5;
        //            ctchungtuCN.CatNK_SoNKCat5 = ctchungtu.CatNK_SoNKCat5;
        //            ///
        //            if (ctchungtuCN.SoPhieu5.HasValue)
        //            {
        //                ChungTu_LichSu lichsuchungtuCN5 = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu5.Value);
        //                lichsuchungtuCN5.CatNK_MaCN = ctchungtu.CatNK_MaCN5;
        //                lichsuchungtuCN5.CatNK_DanhBo = ctchungtu.CatNK_DanhBo5;
        //                lichsuchungtuCN5.CatNK_HoTen = ctchungtu.CatNK_HoTen5;
        //                lichsuchungtuCN5.CatNK_DiaChi = ctchungtu.CatNK_DiaChi5;
        //                lichsuchungtuCN5.SoNK = ctchungtu.CatNK_SoNKCat5;
        //                if (SuaLichSuChungTu(lichsuchungtuCN5))
        //                {
        //                    //CatChuyenDM catchuyendm = _cCatChuyenDM.getCatChuyenDMbySoPhieu(ctchungtuCN.SoPhieu5.Value);
        //                    //catchuyendm.CatNK_MaCN = lichsuchungtuCN5.CatNK_MaCN;
        //                    //catchuyendm.CatNK_DanhBo = lichsuchungtuCN5.CatNK_DanhBo;
        //                    //catchuyendm.CatNK_HoTen = lichsuchungtuCN5.CatNK_HoTen;
        //                    //catchuyendm.CatNK_DiaChi = lichsuchungtuCN5.CatNK_DiaChi;
        //                    //catchuyendm.SoNKNhan = lichsuchungtuCN5.SoNKNhan;

        //                    //_cCatChuyenDM.SuaCatChuyemDM(catchuyendm);
        //                }
        //            }
        //            else
        //            {
        //                lichsuchungtu.MaCT = ctchungtu.MaCT;
        //                lichsuchungtu.DanhBo = ctchungtu.DanhBo;
        //                lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
        //                lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
        //                lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
        //                lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
        //                lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;
        //                ///
        //                lichsuchungtu.SoPhieu = getMaxNextSoPhieuLSCT();
        //                //ctchungtuCN.SoPhieu5 = lichsuchungtu.SoPhieu;
        //                lichsuchungtu.YeuCauCat = true;

        //                lichsuchungtu.CatNK_MaCN = ctchungtu.CatNK_MaCN5;
        //                lichsuchungtu.CatNK_DanhBo = ctchungtu.CatNK_DanhBo5;
        //                lichsuchungtu.CatNK_HoTen = ctchungtu.CatNK_HoTen5;
        //                lichsuchungtu.CatNK_DiaChi = ctchungtu.CatNK_DiaChi5;
        //                lichsuchungtu.SoNK = ctchungtu.CatNK_SoNKCat5;
        //                CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        //                BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
        //                if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
        //                    lichsuchungtu.ChucVu = "GIÁM ĐỐC";
        //                else
        //                    lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
        //                lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
        //                if (ThemLichSuChungTu(lichsuchungtu))
        //                {
        //                    ctchungtuCN.SoPhieu5 = lichsuchungtu.SoPhieu;
        //                    //CatChuyenDM catchuyendm = new CatChuyenDM();
        //                    //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
        //                    //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ctchungtuCN.YeuCauCat5 = false;
        //            if (ctchungtuCN.SoPhieu5.HasValue)
        //            {
        //                ChungTu_LichSu lichsuchungtuCN = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu5.Value);
        //                XoaLichSuChungTu(lichsuchungtuCN);
        //            }
        //        }

        //        #endregion

        //        ///Thêm ChungTu_LichSu
        //        if (flagEdited)
        //        {
        //            lichsuchungtu.MaCT = chungtuCN.MaCT;
        //            lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
        //            lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
        //            lichsuchungtu.DanhBo = ctchungtuCN.DanhBo;
        //            lichsuchungtu.SoNKDangKy = ctchungtuCN.SoNKDangKy;
        //            lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
        //            lichsuchungtu.ThoiHan = ctchungtuCN.ThoiHan;
        //            lichsuchungtu.NgayHetHan = ctchungtuCN.NgayHetHan;

        //            ThemLichSuChungTu(lichsuchungtu);
        //            flagEdited = false;
        //        }
        //        db.SubmitChanges();
        //        //MessageBox.Show("Thành công Sửa ChungTu Method", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        db = new dbKinhDoanhDataContext();
        //        return false;
        //    }
        //}

        public bool SuaSoChungTu(string DanhBo, string MaCT_Cu, string MaCT_Moi)
        {
            try
            {
                if (db.ChungTu_ChiTiets.Count(itemCTCT => itemCTCT.MaCT == MaCT_Cu) > 1)
                {
                    MessageBox.Show("Sổ đăng ký trên 1 danh bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                List<ChungTu_ChiTiet> lstCTCT = db.ChungTu_ChiTiets.Where(itemCTCT => itemCTCT.DanhBo == DanhBo && itemCTCT.MaCT == MaCT_Cu).ToList();
                //foreach (ChungTu_ChiTiet itemCTCT in lstCTCT)
                //{
                //    itemCTCT.MaCT = "bb";
                //}
                db.ChungTus.FirstOrDefault(itemCT => itemCT.MaCT == MaCT_Cu).MaCT = MaCT_Moi;
                foreach (ChungTu_ChiTiet itemCTCT in lstCTCT)
                {
                    itemCTCT.MaCT = MaCT_Moi;
                }
                List<ChungTu_LichSu> lstLSCT = db.ChungTu_LichSus.Where(itemLSCT => itemLSCT.DanhBo == DanhBo && itemLSCT.MaCT == MaCT_Cu).ToList();
                foreach (ChungTu_LichSu itemLSCT in lstLSCT)
                {
                    itemLSCT.MaCT = MaCT_Moi;
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Hàm được dùng cho frmNhanDM, khi khách hàng yêu cầu nhập định mức từ địa phương khác,
        /// sau khi ta nhập thì phải xuất phiếu yêu cầu cắt cho chi nhánh quản lý địa phương đó
        /// </summary>
        /// <param name="chungtu"></param>
        /// <param name="ctchungtu"></param>
        /// <param name="lichsuchungtu"></param>
        /// <returns></returns>
        //public bool NhanChungTu(ChungTu chungtu, ChungTu_ChiTiet ctchungtu, ChungTu_LichSu lichsuchungtu)
        //{
        //    try
        //    {
        //        ///Kiểm tra có thêm mới ChungTu hay không
        //        bool flagAddCT = false;
        //        ///Kiểm tra nếu ChungTu(sổ đăng ký) chưa có thì thêm vào
        //        if (!CheckChungTu(chungtu.MaCT))
        //        {
        //            ThemChungTu(chungtu);
        //            flagAddCT = true;
        //        }
        //        ChungTu chungtuCN = getChungTubyID(ctchungtu.MaCT);
        //        ChungTu_ChiTiet ctchungtuCN = new ChungTu_ChiTiet();
        //        ctchungtuCN = null;
        //        ///Nếu đã có đăng ký thì ta xét số Nhân Khẩu nhận thêm có vượt quá Tổng số Nhân Khẩu hay không
        //        if (CheckCTChungTu(ctchungtu.DanhBo, ctchungtu.MaCT))
        //        {
        //            chungtuCN.SoNKTong = chungtu.SoNKTong;
        //            if (chungtuCN.SoNKTong >= chungtuCN.SoNKNhan + ctchungtu.SoNKDangKy)
        //            {
        //                chungtuCN.SoNKNhan += ctchungtu.SoNKDangKy;
        //                chungtuCN.SoNKDaCap += ctchungtu.SoNKDangKy;
        //                chungtuCN.SoNKConLai = chungtuCN.SoNKTong - chungtuCN.SoNKDaCap;
        //                chungtuCN.ModifyDate = DateTime.Now;
        //                chungtuCN.ModifyBy = CTaiKhoan.MaUser;

        //                ///Cập nhật ChungTu_ChiTiet
        //                ctchungtuCN = getCTChungTubyID(ctchungtu.DanhBo, ctchungtu.MaCT);
        //                ctchungtuCN.SoNKDangKy += ctchungtu.SoNKDangKy;
        //                ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
        //                if (ctchungtu.ThoiHan != null)
        //                    ctchungtuCN.NgayHetHan = DateTime.Now.AddMonths(ctchungtu.ThoiHan.Value);
        //                else
        //                    ctchungtuCN.NgayHetHan = null;
        //                ctchungtuCN.ModifyDate = DateTime.Now;
        //                ctchungtuCN.ModifyBy = CTaiKhoan.MaUser;

        //            }
        //            else
        //            {
        //                MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return false;
        //            }
        //        }
        //        ///Nếu không có thì nhập vô
        //        else
        //        {
        //            ///Nếu lần đầu thêm ChungTu, cái này dễ nhất ChungTu này chưa có nhận cho DanhBo nào hết nên ta thêm trực tiếp vào
        //            if (flagAddCT)
        //            {
        //                chungtuCN.SoNKNhan = ctchungtu.SoNKDangKy;
        //                chungtuCN.SoNKDaCap = ctchungtu.SoNKDangKy;
        //                chungtuCN.SoNKConLai = chungtuCN.SoNKTong - chungtuCN.SoNKDaCap;
        //            }
        //            ///ChungTu đã có trước đó, ta xét số Nhân Khẩu nhận thêm có vượt quá Tổng số Nhân Khẩu hay không
        //            else
        //            {
        //                chungtuCN.SoNKTong = chungtu.SoNKTong;
        //                if (chungtuCN.SoNKTong >= chungtuCN.SoNKNhan + ctchungtu.SoNKDangKy)
        //                {
        //                    chungtuCN.SoNKNhan += ctchungtu.SoNKDangKy;
        //                    chungtuCN.SoNKDaCap += ctchungtu.SoNKDangKy;
        //                    chungtuCN.SoNKConLai = chungtuCN.SoNKTong - chungtuCN.SoNKDaCap;
        //                    chungtuCN.ModifyDate = DateTime.Now;
        //                    chungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return false;
        //                }
        //            }
        //            ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
        //            if (ctchungtu.ThoiHan != null)
        //                ctchungtu.NgayHetHan = DateTime.Now.AddMonths(ctchungtu.ThoiHan.Value);
        //            else
        //                ctchungtu.NgayHetHan = null;
        //            ThemCTChungTu(ctchungtu);
        //        }

        //        ///Cập nhật ChungTu_LichSu
        //        lichsuchungtu.MaCT = ctchungtu.MaCT;
        //        lichsuchungtu.DanhBo = ctchungtu.DanhBo;
        //        lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
        //        lichsuchungtu.SoNK = ctchungtu.SoNKDangKy;
        //        if (ctchungtuCN != null)
        //            lichsuchungtu.SoNKDangKy = ctchungtuCN.SoNKDangKy;
        //        else
        //            lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
        //        lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
        //        lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
        //        lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;

        //        if (ThemLichSuChungTu(lichsuchungtu))
        //        {
        //            //CatChuyenDM catchuyendm = new CatChuyenDM();
        //            //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
        //            //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
        //        }
        //        //MessageBox.Show("Thành công Thêm NhanChungTu Method", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        db = new dbKinhDoanhDataContext();
        //        return false;
        //    }
        //}

        /// <summary>
        /// Hàm được dùng cho frmShowNhanDM, khi khách hàng yêu cầu nhập định mức từ địa phương khác
        /// </summary>
        /// <param name="chungtu"></param>
        /// <param name="ctchungtu"></param>
        /// <param name="lichsuchungtu"></param>
        /// <returns></returns>
        //public bool SuaNhanChungTu(ChungTu chungtu, ChungTu_ChiTiet ctchungtu, ChungTu_LichSu lichsuchungtu)
        //{
        //    try
        //    {
        //        bool flagGiam = false;
        //        ChungTu chungtuCN = getChungTubyID(ctchungtu.MaCT);
        //        ChungTu_ChiTiet ctchungtuCN = getCTChungTubyID(ctchungtu.DanhBo, ctchungtu.MaCT);

        //        ///Kiểm tra Tổng Nhân Khẩu có thay đổi hay không
        //        if (chungtuCN.SoNKTong != chungtu.SoNKTong)
        //            if (chungtu.SoNKTong - chungtuCN.SoNKTong + chungtuCN.SoNKConLai >= 0)
        //            {
        //                chungtuCN.SoNKConLai = chungtu.SoNKTong - chungtuCN.SoNKTong + chungtuCN.SoNKConLai;
        //                chungtuCN.SoNKTong = chungtu.SoNKTong;
        //                chungtuCN.ModifyDate = DateTime.Now;
        //                chungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //            }
        //            else
        //            {
        //                chungtuCN.SoNKConLai = chungtu.SoNKTong;
        //                chungtuCN.SoNKTong = chungtu.SoNKTong;
        //                chungtuCN.ModifyDate = DateTime.Now;
        //                chungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //                flagGiam = true;
        //                //MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                //return false;
        //            }
        //        ///Kiểm tra Địa Chỉ có thay đổi hay không
        //        if (chungtuCN.DiaChi != chungtu.DiaChi)
        //        {
        //            chungtuCN.DiaChi = chungtu.DiaChi;
        //            chungtuCN.ModifyDate = DateTime.Now;
        //            chungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //        }

        //        ///Kiểm tra Số Nhân Khẩu đăng ký có thay đổi hay không
        //        if (ctchungtuCN.SoNKDangKy != ctchungtu.SoNKDangKy)
        //            if (flagGiam)
        //            {
        //                ///Cập nhật Số Nhân Khẩu Cấp cho bảng ChungTu
        //                chungtuCN.SoNKConLai = chungtuCN.SoNKConLai - ctchungtu.SoNKDangKy.Value;
        //                chungtuCN.SoNKDaCap = ctchungtu.SoNKDangKy.Value;
        //                chungtuCN.ModifyDate = DateTime.Now;
        //                chungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //                ///Cập nhật bảng ChungTu_ChiTiet
        //                ctchungtuCN.SoNKDangKy = ctchungtu.SoNKDangKy;
        //                ctchungtuCN.ModifyDate = DateTime.Now;
        //                ctchungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //            }
        //            else
        //                if (chungtuCN.SoNKConLai >= ctchungtu.SoNKDangKy - ctchungtuCN.SoNKDangKy)
        //                {
        //                    ///Cập nhật Số Nhân Khẩu Cấp cho bảng ChungTu
        //                    chungtuCN.SoNKConLai = chungtuCN.SoNKConLai - (ctchungtu.SoNKDangKy.Value - ctchungtuCN.SoNKDangKy.Value);
        //                    chungtuCN.SoNKDaCap = ctchungtu.SoNKDangKy.Value;
        //                    chungtuCN.ModifyDate = DateTime.Now;
        //                    chungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //                    ///Cập nhật bảng ChungTu_ChiTiet
        //                    ctchungtuCN.SoNKDangKy = ctchungtu.SoNKDangKy;

        //                    //ctchungtuCN.ThoiHan = ctchungtu.ThoiHan;
        //                    //if (ctchungtu.ThoiHan != null)
        //                    //    ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
        //                    //    ctchungtuCN.NgayHetHan = ctchungtuCN.CreateDate.Value.AddMonths(ctchungtu.ThoiHan.Value);
        //                    //else
        //                    //    ctchungtuCN.NgayHetHan = null;

        //                    ctchungtuCN.ModifyDate = DateTime.Now;
        //                    ctchungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return false;
        //                }
        //        if (ctchungtuCN.ThoiHan != ctchungtu.ThoiHan)
        //        {
        //            ctchungtuCN.ThoiHan = ctchungtu.ThoiHan;
        //            if (ctchungtu.ThoiHan != null)
        //                ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
        //                ctchungtuCN.NgayHetHan = ctchungtuCN.CreateDate.Value.AddMonths(ctchungtu.ThoiHan.Value);
        //            else
        //                ctchungtuCN.NgayHetHan = null;
        //            ctchungtuCN.ModifyDate = DateTime.Now;
        //            ctchungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //        }

        //        if (SuaLichSuChungTu(lichsuchungtu))
        //        {
        //            //CatChuyenDM catchuyendm = _cCatChuyenDM.getCatChuyenDMbySoPhieu(lichsuchungtu.SoPhieu.Value);
        //            //catchuyendm.CatNK_MaCN = lichsuchungtu.CatNK_MaCN;
        //            //catchuyendm.CatNK_DanhBo = lichsuchungtu.CatNK_DanhBo;
        //            //catchuyendm.CatNK_HoTen = lichsuchungtu.CatNK_HoTen;
        //            //catchuyendm.CatNK_DiaChi = lichsuchungtu.CatNK_DiaChi;
        //            //catchuyendm.SoNKNhan = lichsuchungtu.SoNKNhan;
        //            //catchuyendm.GhiChu = lichsuchungtu.GhiChu;
        //        }

        //        db.SubmitChanges();
        //        //MessageBox.Show("Sửa công Thêm SuaNhanChungTu Method", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        db = new dbKinhDoanhDataContext();
        //        return false;
        //    }
        //}

        /// <summary>
        /// Hàm được dùng cho frmShowNhanDM, khi khách hàng yêu cầu nhập định mức từ địa phương khác
        /// </summary>
        /// <param name="chungtu"></param>
        /// <param name="ctchungtu"></param>
        /// <param name="lichsuchungtu"></param>
        /// <returns></returns>
        //public bool SuaNhanChungTu(ChungTu chungtu, ChungTu_ChiTiet ctchungtu, ChungTu_LichSu lichsuchungtu)
        //{
        //    try
        //    {
        //        ChungTu chungtuCN = getChungTubyID(ctchungtu.MaCT);
        //        ChungTu_ChiTiet ctchungtuCN = getCTChungTubyID(ctchungtu.DanhBo, ctchungtu.MaCT);

        //        ///Kiểm tra Tổng Nhân Khẩu có thay đổi hay không
        //        if (chungtuCN.SoNKTong != chungtu.SoNKTong)
        //            if (chungtu.SoNKTong > chungtuCN.SoNKTong)
        //            {
        //                chungtuCN.SoNKConLai += chungtu.SoNKTong - chungtuCN.SoNKTong;
        //                chungtuCN.SoNKTong = chungtu.SoNKTong;
        //                chungtuCN.ModifyDate = DateTime.Now;
        //                chungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //            }
        //            else
        //                if (chungtuCN.SoNKTong - chungtu.SoNKTong <= chungtuCN.SoNKConLai)
        //                {
        //                    chungtuCN.SoNKConLai -= chungtuCN.SoNKTong - chungtu.SoNKTong;
        //                    chungtuCN.SoNKTong = chungtu.SoNKTong;
        //                    chungtuCN.ModifyDate = DateTime.Now;
        //                    chungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Sổ đã cấp vượt định mức không thể giảm Tổng Nhân Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return false;
        //                }

        //        ///Kiểm tra Địa Chỉ có thay đổi hay không
        //        if (chungtuCN.DiaChi != chungtu.DiaChi)
        //        {
        //            chungtuCN.DiaChi = chungtu.DiaChi;
        //            chungtuCN.ModifyDate = DateTime.Now;
        //            chungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //        }

        //        ///Kiểm tra Số Nhân Khẩu đăng ký có thay đổi hay không
        //        if (ctchungtuCN.SoNKDangKy != ctchungtu.SoNKDangKy)
        //            if (chungtuCN.SoNKTong - ctchungtu.SoNKDangKy <= chungtuCN.SoNKConLai)
        //            {
        //                ///Cập nhật Số Nhân Khẩu Cấp cho bảng ChungTu
        //                chungtuCN.SoNKConLai = chungtuCN.SoNKTong - ctchungtu.SoNKDangKy;
        //                chungtuCN.SoNKDaCap = ctchungtu.SoNKDangKy + (ctchungtuCN.SoNKDangKy - chungtuCN.SoNKDaCap);
        //                chungtuCN.SoNKNhan = ctchungtu.SoNKDangKy + (ctchungtuCN.SoNKDangKy - chungtuCN.SoNKNhan);
        //                chungtuCN.ModifyDate = DateTime.Now;
        //                chungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //                ///Cập nhật bảng ChungTu_ChiTiet
        //                ctchungtuCN.SoNKDangKy = ctchungtu.SoNKDangKy;
        //                ctchungtuCN.ModifyDate = DateTime.Now;
        //                ctchungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return false;
        //            }

        //        ///Kiểm tra Thời Hạn có thay đổi hay không
        //        if (ctchungtuCN.ThoiHan != ctchungtu.ThoiHan)
        //        {
        //            ctchungtuCN.ThoiHan = ctchungtu.ThoiHan;
        //            if (ctchungtu.ThoiHan != null)
        //                ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
        //                ctchungtuCN.NgayHetHan = ctchungtuCN.CreateDate.Value.AddMonths(ctchungtu.ThoiHan.Value);
        //            else
        //                ctchungtuCN.NgayHetHan = null;
        //            ctchungtuCN.ModifyDate = DateTime.Now;
        //            ctchungtuCN.ModifyBy = CTaiKhoan.MaUser;
        //        }

        //        ChungTu_LichSu lichsuchungtuCN = getLSCTbyID(lichsuchungtu.MaLSCT);
        //        lichsuchungtuCN.NhanNK_HoTen = lichsuchungtu.NhanNK_HoTen;
        //        lichsuchungtuCN.NhanNK_DiaChi = lichsuchungtu.NhanNK_DiaChi;
        //        lichsuchungtuCN.CatNK_MaCN = lichsuchungtu.CatNK_MaCN;
        //        lichsuchungtuCN.CatNK_DanhBo = lichsuchungtu.CatNK_DanhBo;
        //        lichsuchungtuCN.CatNK_HoTen = lichsuchungtu.CatNK_HoTen;
        //        lichsuchungtuCN.CatNK_DiaChi = lichsuchungtu.CatNK_DiaChi;
        //        lichsuchungtuCN.SoNK = lichsuchungtu.SoNK;
        //        lichsuchungtuCN.GhiChu = lichsuchungtu.GhiChu;


        //        if (SuaLichSuChungTu(lichsuchungtuCN))
        //        {
        //            //CatChuyenDM catchuyendm = _cCatChuyenDM.getCatChuyenDMbySoPhieu(lichsuchungtu.SoPhieu.Value);
        //            //catchuyendm.CatNK_MaCN = lichsuchungtu.CatNK_MaCN;
        //            //catchuyendm.CatNK_DanhBo = lichsuchungtu.CatNK_DanhBo;
        //            //catchuyendm.CatNK_HoTen = lichsuchungtu.CatNK_HoTen;
        //            //catchuyendm.CatNK_DiaChi = lichsuchungtu.CatNK_DiaChi;
        //            //catchuyendm.SoNKNhan = lichsuchungtu.SoNKNhan;
        //            //catchuyendm.GhiChu = lichsuchungtu.GhiChu;
        //        }

        //        db.SubmitChanges();
        //        //MessageBox.Show("Sửa công Thêm SuaNhanChungTu Method", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        db = new dbKinhDoanhDataContext();
        //        return false;
        //    }
        //}

        /// <summary>
        /// Hàm được dùng cho frmCatChuyenDM, khi khách hàng yêu cầu cắt chuyển định mức đến địa phương khác,
        /// sau khi nhập thì phải xuất phiếu yêu cầu nhập cho chi nhánh quản lý địa phương đó,
        /// trường hợp cắt chuyển cùng chi nhánh thì khỏi xuất phiếu yêu cầu nhận
        /// </summary>
        /// <param name="chungtuCat"></param>
        /// <param name="ctchungtuNhan"></param>
        /// <param name="SoNKCat"></param>
        /// <param name="lichsuchungtu"></param>
        /// <returns></returns>
        //public bool CatChuyenChungTu(ChungTu_ChiTiet ctchungtuCat, ChungTu_ChiTiet ctchungtuNhan, int SoNKCat, ChungTu_LichSu lichsuchungtu)
        //{
        //    try
        //    {
        //        CChiNhanh _cChiNhanh = new CChiNhanh();
        //        ///Cùng Chi Nhánh
        //        if (_cChiNhanh.getChiNhanhbyID(lichsuchungtu.NhanNK_MaCN.Value).TenCN.ToUpper().Contains("TÂN HÒA"))
        //        {
        //            ChungTu_ChiTiet ctchungtuCatCN = getCTChungTubyID(ctchungtuCat.DanhBo, ctchungtuCat.MaCT);
        //            ///Nếu Chứng Từ đã đăng ký với Danh Bộ
        //            if (CheckCTChungTu(ctchungtuNhan.DanhBo, ctchungtuNhan.MaCT))
        //            {
        //                if (ctchungtuCatCN.SoNKDangKy >= SoNKCat)
        //                {
        //                    ///Cập nhật ChungTu_ChiTiet, Danh Bộ Cắt
        //                    ctchungtuCatCN.SoNKDangKy -= SoNKCat;
        //                    ctchungtuCatCN.ModifyDate = DateTime.Now;
        //                    ctchungtuCatCN.ModifyBy = CTaiKhoan.MaUser;

        //                    ///Cập nhật ChungTu_ChiTiet, Danh Bộ Nhận
        //                    ChungTu_ChiTiet ctchungtuNhanCN = getCTChungTubyID(ctchungtuNhan.DanhBo, ctchungtuNhan.MaCT);
        //                    ctchungtuNhanCN.SoNKDangKy += SoNKCat;
        //                    ctchungtuNhanCN.ModifyDate = DateTime.Now;
        //                    ctchungtuNhanCN.ModifyBy = CTaiKhoan.MaUser;

        //                    db.SubmitChanges();

        //                    ChungTu chungtuCN = getChungTubyID(ctchungtuCat.MaCT);
        //                    ///Cập nhật ChungTu_LichSu, Chứng Từ & Danh Bộ Cắt
        //                    ///Xóa Số Phiếu
        //                    lichsuchungtu.SoPhieu = null;
        //                    lichsuchungtu.MaCT = ctchungtuCat.MaCT;
        //                    lichsuchungtu.DanhBo = ctchungtuCat.DanhBo;
        //                    lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
        //                    lichsuchungtu.SoNK = SoNKCat;
        //                    lichsuchungtu.SoNKDangKy = ctchungtuCatCN.SoNKDangKy;
        //                    lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
        //                    lichsuchungtu.ThoiHan = ctchungtuCatCN.ThoiHan;
        //                    lichsuchungtu.NgayHetHan = ctchungtuCatCN.NgayHetHan;
        //                    lichsuchungtu.CatNK_MaCN = lichsuchungtu.NhanNK_MaCN;
        //                    ThemLichSuChungTu(lichsuchungtu);

        //                    ///Cập nhật ChungTu_LichSu, Chứng Từ & Danh Bộ Nhận
        //                    ChungTu_LichSu lichsuchungtuNhan = new ChungTu_LichSu();
        //                    if (lichsuchungtu.MaDon != null)
        //                        lichsuchungtuNhan.MaDon = lichsuchungtu.MaDon;
        //                    else
        //                        if (lichsuchungtu.MaDonTXL != null)
        //                            lichsuchungtuNhan.MaDonTXL = lichsuchungtu.MaDonTXL;
        //                        else
        //                            if (lichsuchungtu.MaDonTBC != null)
        //                                lichsuchungtuNhan.MaDonTBC = lichsuchungtu.MaDonTBC;
        //                    lichsuchungtuNhan.MaCT = ctchungtuNhan.MaCT;
        //                    lichsuchungtuNhan.DanhBo = ctchungtuNhan.DanhBo;
        //                    lichsuchungtuNhan.SoNKTong = chungtuCN.SoNKTong;
        //                    lichsuchungtuNhan.SoNK = SoNKCat;
        //                    lichsuchungtuNhan.SoNKDangKy = ctchungtuNhanCN.SoNKDangKy;
        //                    lichsuchungtuNhan.SoNKConLai = chungtuCN.SoNKConLai;
        //                    lichsuchungtuNhan.ThoiHan = ctchungtuCatCN.ThoiHan;
        //                    lichsuchungtuNhan.NgayHetHan = ctchungtuCatCN.NgayHetHan;
        //                    ///Chuyển đổi vị trí Cắt & Nhận
        //                    lichsuchungtuNhan.CatNK_DanhBo = lichsuchungtu.NhanNK_DanhBo;
        //                    lichsuchungtuNhan.CatNK_HoTen = lichsuchungtu.NhanNK_HoTen;
        //                    lichsuchungtuNhan.CatNK_DiaChi = lichsuchungtu.NhanNK_DiaChi;
        //                    lichsuchungtuNhan.CatNK_MaCN = lichsuchungtu.NhanNK_MaCN;
        //                    lichsuchungtuNhan.NhanDM = true;
        //                    lichsuchungtuNhan.NhanNK_MaCN = lichsuchungtu.CatNK_MaCN;
        //                    lichsuchungtuNhan.NhanNK_DanhBo = lichsuchungtu.CatNK_DanhBo;
        //                    lichsuchungtuNhan.NhanNK_HoTen = lichsuchungtu.CatNK_HoTen;
        //                    lichsuchungtuNhan.NhanNK_DiaChi = lichsuchungtu.CatNK_DiaChi;

        //                    ThemLichSuChungTu(lichsuchungtuNhan);
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Cắt vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return false;
        //                }
        //            }
        //            ///Nếu Chứng Từ chưa đăng ký với Danh Bộ
        //            else
        //            {
        //                if (ctchungtuCatCN.SoNKDangKy >= SoNKCat)
        //                {
        //                    ///Cập nhật ChungTu_ChiTiet, Danh Bộ Cắt
        //                    ctchungtuCatCN.SoNKDangKy -= SoNKCat;
        //                    ctchungtuCatCN.ModifyDate = DateTime.Now;
        //                    ctchungtuCatCN.ModifyBy = CTaiKhoan.MaUser;

        //                    db.SubmitChanges();

        //                    ///Thêm ChungTu_ChiTiet, Danh Bộ nhận
        //                    ctchungtuNhan.SoNKDangKy = SoNKCat;
        //                    ThemCTChungTu(ctchungtuNhan);

        //                    ChungTu chungtuCN = getChungTubyID(ctchungtuCat.MaCT);
        //                    ///Cập nhật ChungTu_LichSu, Chứng Từ & Danh Bộ Cắt
        //                    ///Xóa Số Phiếu
        //                    lichsuchungtu.SoPhieu = null;
        //                    lichsuchungtu.MaCT = ctchungtuCat.MaCT;
        //                    lichsuchungtu.DanhBo = ctchungtuCat.DanhBo;
        //                    lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
        //                    lichsuchungtu.SoNK = SoNKCat;
        //                    lichsuchungtu.SoNKDangKy = ctchungtuCatCN.SoNKDangKy;
        //                    lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
        //                    lichsuchungtu.ThoiHan = ctchungtuCatCN.ThoiHan;
        //                    lichsuchungtu.NgayHetHan = ctchungtuCatCN.NgayHetHan;
        //                    ThemLichSuChungTu(lichsuchungtu);

        //                    ///Cập nhật ChungTu_LichSu, Chứng Từ & Danh Bộ Nhận
        //                    ChungTu_LichSu lichsuchungtuNhan = new ChungTu_LichSu();
        //                    if (lichsuchungtu.MaDon != null)
        //                        lichsuchungtuNhan.MaDon = lichsuchungtu.MaDon;
        //                    else
        //                        if (lichsuchungtu.MaDonTXL != null)
        //                            lichsuchungtuNhan.MaDonTXL = lichsuchungtu.MaDonTXL;
        //                        else
        //                            if (lichsuchungtu.MaDonTBC != null)
        //                                lichsuchungtuNhan.MaDonTBC = lichsuchungtu.MaDonTBC;
        //                    lichsuchungtuNhan.MaCT = ctchungtuNhan.MaCT;
        //                    lichsuchungtuNhan.DanhBo = ctchungtuNhan.DanhBo;
        //                    lichsuchungtuNhan.SoNKTong = chungtuCN.SoNKTong;
        //                    lichsuchungtuNhan.SoNK = SoNKCat;
        //                    lichsuchungtuNhan.SoNKDangKy = SoNKCat;
        //                    lichsuchungtuNhan.SoNKConLai = chungtuCN.SoNKConLai;
        //                    lichsuchungtuNhan.ThoiHan = ctchungtuCatCN.ThoiHan;
        //                    lichsuchungtuNhan.NgayHetHan = ctchungtuCatCN.NgayHetHan;
        //                    ///Chuyển đổi vị trí Cắt & Nhận
        //                    lichsuchungtuNhan.CatNK_DanhBo = lichsuchungtu.NhanNK_DanhBo;
        //                    lichsuchungtuNhan.CatNK_HoTen = lichsuchungtu.NhanNK_HoTen;
        //                    lichsuchungtuNhan.CatNK_DiaChi = lichsuchungtu.NhanNK_DiaChi;
        //                    lichsuchungtuNhan.NhanDM = true;
        //                    lichsuchungtuNhan.NhanNK_MaCN = lichsuchungtu.NhanNK_MaCN;
        //                    lichsuchungtuNhan.NhanNK_DanhBo = lichsuchungtu.CatNK_DanhBo;
        //                    lichsuchungtuNhan.NhanNK_HoTen = lichsuchungtu.CatNK_HoTen;
        //                    lichsuchungtuNhan.NhanNK_DiaChi = lichsuchungtu.CatNK_DiaChi;

        //                    ThemLichSuChungTu(lichsuchungtuNhan);
        //                    //MessageBox.Show("Thành công Thêm CatChuyenChungTu cùng ChiNhanh Method", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    return true;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Cắt vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    return false;
        //                }
        //            }
        //        }
        //        ///Khác Chi Nhánh
        //        else
        //        {
        //            ChungTu_ChiTiet ctchungtuCN = getCTChungTubyID(ctchungtuCat.DanhBo, ctchungtuCat.MaCT);
        //            if (ctchungtuCN.SoNKDangKy >= SoNKCat)
        //            {
        //                ctchungtuCN.SoNKDangKy -= SoNKCat;
        //                ctchungtuCN.ModifyDate = DateTime.Now;
        //                ctchungtuCN.ModifyBy = CTaiKhoan.MaUser;

        //                ChungTu chungtuCN = getChungTubyID(ctchungtuCat.MaCT);
        //                chungtuCN.SoNKCat += SoNKCat;
        //                chungtuCN.SoNKDaCap -= SoNKCat;
        //                chungtuCN.ModifyDate = DateTime.Now;
        //                chungtuCN.ModifyBy = CTaiKhoan.MaUser;

        //                db.SubmitChanges();

        //                ///Cập nhật ChungTu_LichSu
        //                lichsuchungtu.MaCT = ctchungtuCat.MaCT;
        //                lichsuchungtu.DanhBo = ctchungtuCat.DanhBo;
        //                lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
        //                lichsuchungtu.SoNK = SoNKCat;
        //                lichsuchungtu.SoNKDangKy = ctchungtuCN.SoNKDangKy;
        //                lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
        //                lichsuchungtu.ThoiHan = ctchungtuCN.ThoiHan;
        //                lichsuchungtu.NgayHetHan = ctchungtuCN.NgayHetHan;

        //                if (ThemLichSuChungTu(lichsuchungtu))
        //                {
        //                    //CatChuyenDM catchuyendm = new CatChuyenDM();
        //                    //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
        //                    //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
        //                }
        //                //MessageBox.Show("Thành công Thêm CatChuyenChungTu khác ChiNhanh Method", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                return true;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Cắt vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return false;
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        db = new dbKinhDoanhDataContext();
        //        return false;
        //    }
        //}

        #endregion

        #region Báo Cáo

        public DataTable LoadDSCapDinhMuc(string DanhBo, DateTime TuNgay)
        {
            try
            {
                var query = from itemCTChungTu in db.ChungTu_ChiTiets
                            //join itemTTKH in dbThuTien.HOADONs.GroupBy(item => item.DANHBA).Select(item => item.OrderByDescending(itemB => itemB.CreateDate)).First() on itemCTChungTu.DanhBo equals itemTTKH.DANHBA
                            where (itemCTChungTu.ChungTu.MaLCT == 2 || itemCTChungTu.ChungTu.MaLCT == 5 || itemCTChungTu.ChungTu.MaLCT == 6 || itemCTChungTu.ChungTu.MaLCT == 7 || itemCTChungTu.ChungTu.MaLCT == 8) && itemCTChungTu.CreateDate.Value.Date == TuNgay.Date
                            && itemCTChungTu.Cat == false && itemCTChungTu.DanhBo == DanhBo
                            orderby itemCTChungTu.NgayHetHan ascending
                            select new
                            {
                                itemCTChungTu.DanhBo,
                                itemCTChungTu.SoNKDangKy,
                                itemCTChungTu.ChungTu.LoaiChungTu.MaLCT,
                                itemCTChungTu.ChungTu.LoaiChungTu.TenLCT,
                                itemCTChungTu.MaCT,
                                itemCTChungTu.DienThoai,
                                itemCTChungTu.NgayHetHan,
                                itemCTChungTu.CreateDate,
                                itemCTChungTu.GhiChu,
                                //HoTen = itemTTKH.TENKH,
                                //DiaChi = itemTTKH.SO + itemTTKH.DUONG,
                                //Phuong = itemTTKH.Phuong,
                                //Quan = itemTTKH.Quan,
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
        /// Lấy Danh Sách Cấp Định Mức theo Khoảng Thời Gian
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCapDinhMuc(DateTime TuNgay)
        {
            try
            {
                var query = from itemCTChungTu in db.ChungTu_ChiTiets
                            join itemTTKH in dbThuTien.HOADONs.GroupBy(item => item.DANHBA).Select(item => item.OrderByDescending(itemB => itemB.CreateDate)).First() on itemCTChungTu.DanhBo equals itemTTKH.DANHBA
                            where (itemCTChungTu.ChungTu.MaLCT == 2 || itemCTChungTu.ChungTu.MaLCT == 5 || itemCTChungTu.ChungTu.MaLCT == 6 || itemCTChungTu.ChungTu.MaLCT == 7 || itemCTChungTu.ChungTu.MaLCT == 8) && itemCTChungTu.CreateDate.Value.Date == TuNgay.Date
                            && itemCTChungTu.Cat == false
                            orderby itemCTChungTu.NgayHetHan ascending
                            select new
                            {
                                itemCTChungTu.DanhBo,
                                itemTTKH.TENKH,
                                DiaChi = itemTTKH.SO + itemTTKH.DUONG,
                                itemCTChungTu.SoNKDangKy,
                                itemCTChungTu.ChungTu.LoaiChungTu.MaLCT,
                                itemCTChungTu.ChungTu.LoaiChungTu.TenLCT,
                                itemCTChungTu.MaCT,
                                itemCTChungTu.DienThoai,
                                itemCTChungTu.NgayHetHan,
                                itemCTChungTu.CreateDate,
                                itemCTChungTu.GhiChu,
                                itemTTKH.Phuong,
                                itemTTKH.Quan,
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
        /// Lấy Danh Sách Cấp Định Mức theo Khoảng Thời Gian
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCapDinhMuc(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemCTChungTu in db.ChungTu_ChiTiets
                            where (itemCTChungTu.ChungTu.MaLCT == 2 || itemCTChungTu.ChungTu.MaLCT == 5 || itemCTChungTu.ChungTu.MaLCT == 6 || itemCTChungTu.ChungTu.MaLCT == 7 || itemCTChungTu.ChungTu.MaLCT == 8)
                            && itemCTChungTu.NgayHetHan != null
                            && itemCTChungTu.CreateDate.Value.Date >= TuNgay.Date && itemCTChungTu.CreateDate.Value.Date <= DenNgay.Date
                            && itemCTChungTu.Cat == false
                            orderby itemCTChungTu.NgayHetHan ascending
                            select new
                            {
                                itemCTChungTu.DanhBo,
                                itemCTChungTu.SoNKDangKy,
                                itemCTChungTu.ChungTu.LoaiChungTu.MaLCT,
                                itemCTChungTu.ChungTu.LoaiChungTu.TenLCT,
                                itemCTChungTu.MaCT,
                                itemCTChungTu.DienThoai,
                                itemCTChungTu.NgayHetHan,
                                itemCTChungTu.CreateDate,
                                itemCTChungTu.GhiChu,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadThongKeDMCapCoThoiHan(DateTime TuNgay)
        {
            try
            {
                var query = from itemCTChungTu in db.ChungTu_ChiTiets
                            join itemTTKH in dbThuTien.HOADONs.GroupBy(item => item.DANHBA).Select(item => item.OrderByDescending(itemB => itemB.CreateDate)).First() on itemCTChungTu.DanhBo equals itemTTKH.DANHBA
                            where (itemCTChungTu.ChungTu.MaLCT == 2 || itemCTChungTu.ChungTu.MaLCT == 5 || itemCTChungTu.ChungTu.MaLCT == 6 || itemCTChungTu.ChungTu.MaLCT == 7 || itemCTChungTu.ChungTu.MaLCT == 8) && itemCTChungTu.CreateDate.Value.Date == TuNgay.Date
                            && itemCTChungTu.Cat == false && itemCTChungTu.ThoiHan != null
                            orderby itemCTChungTu.NgayHetHan ascending
                            select new
                            {
                                itemCTChungTu.DanhBo,
                                Phuong = itemTTKH.Phuong,
                                Quan = itemTTKH.Quan,
                                itemCTChungTu.ChungTu.LoaiChungTu.MaLCT,
                                itemCTChungTu.ChungTu.LoaiChungTu.TenLCT,
                            };
                return LINQToDataTable(query.Distinct());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadThongKeDMCapCoThoiHan(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemCTChungTu in db.ChungTu_ChiTiets
                            where (itemCTChungTu.ChungTu.MaLCT == 2 || itemCTChungTu.ChungTu.MaLCT == 5 || itemCTChungTu.ChungTu.MaLCT == 6 || itemCTChungTu.ChungTu.MaLCT == 7 || itemCTChungTu.ChungTu.MaLCT == 8) && itemCTChungTu.CreateDate.Value.Date >= TuNgay.Date && itemCTChungTu.CreateDate.Value.Date <= DenNgay.Date
                            && itemCTChungTu.Cat == false && itemCTChungTu.ThoiHan != null
                            orderby itemCTChungTu.NgayHetHan ascending
                            select new
                            {
                                itemCTChungTu.DanhBo,
                                itemCTChungTu.ChungTu.LoaiChungTu.MaLCT,
                                itemCTChungTu.ChungTu.LoaiChungTu.TenLCT,
                            };
                return LINQToDataTable(query.Distinct());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCapDinhMucNgayHetHan(DateTime TuNgay)
        {
            try
            {
                var query = from itemCTChungTu in db.ChungTu_ChiTiets
                            join itemTTKH in dbThuTien.HOADONs.GroupBy(item => item.DANHBA).Select(item => item.OrderByDescending(itemB => itemB.CreateDate)).First() on itemCTChungTu.DanhBo equals itemTTKH.DANHBA
                            where (itemCTChungTu.ChungTu.MaLCT == 2 || itemCTChungTu.ChungTu.MaLCT == 5 || itemCTChungTu.ChungTu.MaLCT == 6 || itemCTChungTu.ChungTu.MaLCT == 7 || itemCTChungTu.ChungTu.MaLCT == 8) && itemCTChungTu.NgayHetHan.Value.Date == TuNgay.Date
                            && itemCTChungTu.Cat == false
                            orderby itemCTChungTu.NgayHetHan ascending
                            select new
                            {
                                itemCTChungTu.DanhBo,
                                itemTTKH.TENKH,
                                DiaChi = itemTTKH.SO + itemTTKH.DUONG,
                                itemCTChungTu.SoNKDangKy,
                                itemCTChungTu.ChungTu.LoaiChungTu.MaLCT,
                                itemCTChungTu.ChungTu.LoaiChungTu.TenLCT,
                                itemCTChungTu.MaCT,
                                itemCTChungTu.DienThoai,
                                itemCTChungTu.NgayHetHan,
                                itemCTChungTu.CreateDate,
                                itemCTChungTu.GhiChu,
                                itemTTKH.Phuong,
                                itemTTKH.Quan,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCapDinhMucNgayHetHan(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemCTChungTu in db.ChungTu_ChiTiets
                            where (itemCTChungTu.ChungTu.MaLCT == 2 || itemCTChungTu.ChungTu.MaLCT == 5 || itemCTChungTu.ChungTu.MaLCT == 6 || itemCTChungTu.ChungTu.MaLCT == 7 || itemCTChungTu.ChungTu.MaLCT == 8) && itemCTChungTu.NgayHetHan.Value.Date >= TuNgay.Date && itemCTChungTu.NgayHetHan.Value.Date <= DenNgay.Date
                            && itemCTChungTu.Cat == false
                            orderby itemCTChungTu.NgayHetHan ascending
                            select new
                            {
                                itemCTChungTu.DanhBo,
                                itemCTChungTu.SoNKDangKy,
                                itemCTChungTu.ChungTu.LoaiChungTu.MaLCT,
                                itemCTChungTu.ChungTu.LoaiChungTu.TenLCT,
                                itemCTChungTu.MaCT,
                                itemCTChungTu.DienThoai,
                                itemCTChungTu.NgayHetHan,
                                itemCTChungTu.CreateDate,
                                itemCTChungTu.GhiChu,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCapDinhMucKhongThoiHan(DateTime TuNgay)
        {
            try
            {
                var query = from itemCTChungTu in db.ChungTu_ChiTiets
                            join itemTTKH in dbThuTien.HOADONs.GroupBy(item => item.DANHBA).Select(item => item.OrderByDescending(itemB => itemB.CreateDate)).First() on itemCTChungTu.DanhBo equals itemTTKH.DANHBA
                            where (itemCTChungTu.ChungTu.MaLCT != 2 && itemCTChungTu.ChungTu.MaLCT != 5 && itemCTChungTu.ChungTu.MaLCT != 6 && itemCTChungTu.ChungTu.MaLCT != 7 && itemCTChungTu.ChungTu.MaLCT != 8) && itemCTChungTu.CreateDate.Value.Date == TuNgay.Date
                            && itemCTChungTu.Cat == false
                            orderby itemCTChungTu.NgayHetHan ascending
                            select new
                            {
                                itemCTChungTu.DanhBo,
                                itemTTKH.TENKH,
                                DiaChi = itemTTKH.SO + itemTTKH.DUONG,
                                itemCTChungTu.SoNKDangKy,
                                itemCTChungTu.ChungTu.LoaiChungTu.MaLCT,
                                itemCTChungTu.ChungTu.LoaiChungTu.TenLCT,
                                itemCTChungTu.MaCT,
                                itemCTChungTu.DienThoai,
                                itemCTChungTu.NgayHetHan,
                                itemCTChungTu.CreateDate,
                                itemCTChungTu.GhiChu,
                                itemTTKH.Phuong,
                                itemTTKH.Quan,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCapDinhMucKhongThoiHan(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                var query = from itemCTChungTu in db.ChungTu_ChiTiets
                            where (itemCTChungTu.ChungTu.MaLCT != 2 && itemCTChungTu.ChungTu.MaLCT != 5 && itemCTChungTu.ChungTu.MaLCT != 6 && itemCTChungTu.ChungTu.MaLCT != 7 && itemCTChungTu.ChungTu.MaLCT != 8)
                            && itemCTChungTu.NgayHetHan == null
                            && itemCTChungTu.CreateDate.Value.Date >= TuNgay.Date && itemCTChungTu.CreateDate.Value.Date <= DenNgay.Date
                            && itemCTChungTu.Cat == false
                            orderby itemCTChungTu.NgayHetHan ascending
                            select new
                            {
                                itemCTChungTu.DanhBo,
                                itemCTChungTu.SoNKDangKy,
                                itemCTChungTu.ChungTu.LoaiChungTu.MaLCT,
                                itemCTChungTu.ChungTu.LoaiChungTu.TenLCT,
                                itemCTChungTu.MaCT,
                                itemCTChungTu.DienThoai,
                                itemCTChungTu.NgayHetHan,
                                itemCTChungTu.CreateDate,
                                itemCTChungTu.GhiChu,
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
        /// Lấy Danh Sách Cấp Định Mức sắp Hết Hạn (trước 15ngày)
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCapDinhMucHetHan()
        {
            try
            {
                var query = from itemCTChungTu in db.ChungTu_ChiTiets
                            where itemCTChungTu.Cat == false && itemCTChungTu.ThoiHan != null && itemCTChungTu.NgayHetHan <= DateTime.Now.AddDays(15)
                            orderby itemCTChungTu.NgayHetHan ascending
                            select new
                            {
                                itemCTChungTu.DanhBo,
                                itemCTChungTu.SoNKDangKy,
                                itemCTChungTu.ChungTu.LoaiChungTu.MaLCT,
                                itemCTChungTu.ChungTu.LoaiChungTu.TenLCT,
                                itemCTChungTu.MaCT,
                                itemCTChungTu.DienThoai,
                                itemCTChungTu.NgayHetHan,
                                itemCTChungTu.CreateDate,
                                itemCTChungTu.GhiChu,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCapDinhMucHetHanTheoDanhBo()
        {
            try
            {
                var query = from itemCTChungTu in db.ChungTu_ChiTiets
                            //join itemTTKH in dbThuTien.HOADONs.GroupBy(item => item.DANHBA).Select(item => item.OrderByDescending(itemB => itemB.CreateDate)).First() on itemCTChungTu.DanhBo equals itemTTKH.DANHBA
                            where itemCTChungTu.Cat == false && itemCTChungTu.ThoiHan != null && itemCTChungTu.NgayHetHan <= DateTime.Now.AddDays(15)
                            group itemCTChungTu by itemCTChungTu.DanhBo into itemGroup
                            select new
                            {
                                DanhBo = itemGroup.Key,
                                HoTen = dbThuTien.HOADONs.Where(item => item.DANHBA == itemGroup.Key).OrderByDescending(item => item.CreateDate).First().TENKH,
                                DiaChi = dbThuTien.HOADONs.Where(item => item.DANHBA == itemGroup.Key).OrderByDescending(item => item.CreateDate).First().SO + dbThuTien.HOADONs.Where(item => item.DANHBA == itemGroup.Key).OrderByDescending(item => item.CreateDate).First().DUONG,
                                Phuong = dbThuTien.HOADONs.Where(item => item.DANHBA == itemGroup.Key).OrderByDescending(item => item.CreateDate).First().Phuong,
                                Quan = dbThuTien.HOADONs.Where(item => item.DANHBA == itemGroup.Key).OrderByDescending(item => item.CreateDate).First().Quan,
                            };
                return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDanhBoCapDinhMuc(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                string sql = "select t1.*,t2.TIEUTHU from"
                            + " (select ct.DanhBo,ttkh.HoTen,ttkh.DiaChi,Phuong,Quan,case when DinhMuc_BD is null then DinhMuc else DinhMuc_BD end as DinhMuc from"
                            + " (select DanhBo from ChungTu ct,ChungTu_ChiTiet ctct,LoaiChungTu lct where ct.MaCT=ctct.MaCT and lct.MaLCT=ct.MaLCT and NgayHetHan is not null and Cat=0"
                            + " and (lct.MaLCT=2 or lct.MaLCT=5 or lct.MaLCT=6 or lct.MaLCT=7 or lct.MaLCT=8)"
                            + " group by DanhBo) ct"
                            + " left join"
                            + " (select DanhBo,HoTen,DC1+' '+DC2 as DiaChi,Phuong,Quan from TTKhachHang) ttkh on ct.DanhBo=ttkh.DanhBo"
                            + " left join"
                            + " (select DanhBo,DinhMuc,DinhMuc_BD,ROW_NUMBER() OVER (PARTITION BY DanhBo ORDER BY CreateDate DESC) AS rn from DCBD_ChiTietBienDong) dcbd on ct.DanhBo=dcbd.DanhBo"
                            + " where rn=1) t1"
                            + " left join"
                            + " (select DANHBA,TIEUTHU,ROW_NUMBER() OVER (PARTITION BY DanhBa ORDER BY ID_HOADON DESC) AS rn from HOADON_TA.dbo.HOADON) t2 on t1.DanhBo=t2.DANHBA"
                            + " where rn=1";
                return ExecuteQuery_DataTable(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSDanhBoCapDinhMucCoThoiHan()
        {
            string sql = "select t1.DanhBo,HOTEN,SONHA+' '+TENDUONG as DiaChi,Phuong,Quan,t2.DINHMUC from"
                        + " (select DanhBo,row_number() over (partition by DanhBo order by DanhBo) as RowNumber from ChungTu_ChiTiet where NgayHetHan is not null and Cat=0) t1"
                        + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo"
                        + " where RowNumber=1";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable LoadDSDanhBoCapDinhMucCoThoiHanDoanThanhNien(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select t1.DanhBo,t1.HOTEN,DiaChi,Phuong,Quan from"
                        + " (select DanhBo,HoTen,DiaChi from DCBD_ChiTietBienDong where DoanThanhNien=1 and CAST(CreateDate as date)>='" + FromCreateDate.Date.ToString("yyyy-MM-dd") + "' and CAST(CreateDate as date)<='" + ToCreateDate.Date.ToString("yyyy-MM-dd") + "') t1"
                        + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable LoadDSDanhBoDCHDCodeF2(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select t1.DanhBo,t1.HOTEN,DiaChi,Phuong,Quan from"
                        + " (select DanhBo,HoTen,DiaChi from DCBD_ChiTietHoaDon where Codef2=1 and CAST(CreateDate as date)>='" + FromCreateDate.Date.ToString("yyyy-MM-dd") + "' and CAST(CreateDate as date)<='" + ToCreateDate.Date.ToString("yyyy-MM-dd") + "') t1"
                        + " left join SERVER8.CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG t2 on t1.DanhBo=t2.DanhBo";

            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getBaoCaoNhaTroGuiTong(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select dcbd.DanhBo,CreateDate=CAST(dcbd.CreateDate as date),Quan=(select Name2 from Quan where ID=dcbd.Quan),DinhMuc=SUM(DinhMuc),DinhMuc_BD=SUM(DinhMuc_BD)"
                        + " from DCBD_ChiTietBienDong dcbd,ChungTu_ChiTiet ctct"
                        + " where CAST(dcbd.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and DinhMuc_BD is not null and ctct.Cat=0 and (MaLCT=7 or MaLCT=8) and dcbd.DanhBo=ctct.DanhBo"
                        + " group by dcbd.DanhBo,CAST(dcbd.CreateDate as date),dcbd.Quan"
                        + " order by CreateDate,Quan";
            //string sql = "select dcbd.DanhBo,CreateDate=CAST(dcbd.CreateDate as date),Quan=(select Name2 from Quan where ID=dcbd.Quan),DinhMuc=SUM(DinhMuc),DinhMuc_BD=SUM(DinhMuc_BD)"
            //            + " from DCBD_ChiTietBienDong dcbd,ChungTu_ChiTiet ctct"
            //            + " where CAST(dcbd.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(dcbd.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and DinhMuc_BD is not null and (MaLCT=7 or MaLCT=8) and dcbd.DanhBo=ctct.DanhBo"
            //            + " group by dcbd.DanhBo,CAST(dcbd.CreateDate as date),dcbd.Quan"
            //            + " order by CreateDate,Quan";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable getTimKiemSoDangKyDinhMuc(string MaCT)
        {
            string sql = "select Loai=N'CT Đơn',TenLCT,ctct.MaCT,ct.SoNKTong,ctct.DanhBo,ctct.SoNKDangKy,ctct.CreateDate"
                        + " from ChungTu ct,LoaiChungTu lct,ChungTu_ChiTiet ctct"
                        + " where ct.MaLCT=lct.MaLCT and ct.MaCT=ctct.MaCT and ctct.MaCT like N'%" + MaCT + "%'"
                        + " union"
                        + " select Loai=N'CT Chung Cư',TenLCT=(select TenLCT from LoaiChungTu where MaLCT=ctct.MaLCT),MaCT,SoNKTong,DanhBo,SoNKDangKy,CreateDate"
                        + " from ChungCu.dbo.DanhSachChungTu ctct"
                        + " where ctct.MaCT like N'%" + MaCT + "%'"
                        + " order by CreateDate";
            return ExecuteQuery_DataTable(sql);
        }

        #endregion

        #region Hình

        public bool Them_Hinh(ChungTu_LichSu_Hinh en)
        {
            try
            {
                if (db.ChungTu_LichSu_Hinhs.Count() == 0)
                    en.ID = 1;
                else
                    en.ID = db.ChungTu_LichSu_Hinhs.Max(item => item.ID) + 1;
                en.CreateBy = CTaiKhoan.MaUser;
                en.CreateDate = DateTime.Now;
                db.ChungTu_LichSu_Hinhs.InsertOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Xoa_Hinh(ChungTu_LichSu_Hinh en)
        {
            try
            {
                db.ChungTu_LichSu_Hinhs.DeleteOnSubmit(en);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public ChungTu_LichSu_Hinh get_Hinh(int ID)
        {
            return db.ChungTu_LichSu_Hinhs.SingleOrDefault(item => item.ID == ID);
        }

        #endregion
    }
}

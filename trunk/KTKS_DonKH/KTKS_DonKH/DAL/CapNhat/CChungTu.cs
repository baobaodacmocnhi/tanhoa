using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.DAL.CapNhat
{
    class CChungTu : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng ChungTu & CTChungTu & LichSuChungTu

        #region ChungTu

        public DataTable LoadDSChungTu(string DanhBo)
        {
            try
            {
                var query = from itemCTCT in db.CTChungTus
                            join itemCT in db.ChungTus on itemCTCT.MaCT equals itemCT.MaCT
                            join itemLCT in db.LoaiChungTus on itemCT.MaLCT equals itemLCT.MaLCT
                            where itemCTCT.DanhBo == DanhBo
                            select new
                            {
                                itemCTCT.DanhBo,
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
                                itemCTCT.SoChinh,
                                itemCTCT.Cat,
                            };
                return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool CheckChungTu(string MaCT)
        {
            try
            {
                return db.ChungTus.Any(itemCT => itemCT.MaCT == MaCT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckChungTu(string MaCT, int MaLCT)
        {
            try
            {
                return db.ChungTus.Any(itemCT => itemCT.MaCT == MaCT && itemCT.MaLCT == MaLCT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public ChungTu getChungTubyID(string MaCT)
        {
            try
            {
                return db.ChungTus.Single(itemCT => itemCT.MaCT == MaCT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public ChungTu getChungTubyID(string MaCT, int MaLCT)
        {
            try
            {
                return db.ChungTus.Single(itemCT => itemCT.MaCT == MaCT && itemCT.MaLCT == MaLCT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemChungTu(ChungTu chungtu)
        {
            try
            {
                chungtu.CreateDate = DateTime.Now;
                chungtu.CreateBy = CTaiKhoan.MaUser;
                db.ChungTus.InsertOnSubmit(chungtu);
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

        public bool SuaChungTu(ChungTu chungtu)
        {
            try
            {
                chungtu.ModifyDate = DateTime.Now;
                chungtu.ModifyBy = CTaiKhoan.MaUser;
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

        #endregion

        #region CTChungTu

        public bool CheckCTChungTu(string DanhBo, string MaCT)
        {
            try
            {
                return db.CTChungTus.Any(itemCT => itemCT.DanhBo == DanhBo && itemCT.MaCT == MaCT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public CTChungTu getCTChungTubyID(string DanhBo, string MaCT)
        {
            try
            {
                return db.CTChungTus.SingleOrDefault(itemCT => itemCT.DanhBo == DanhBo && itemCT.MaCT == MaCT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemCTChungTu(CTChungTu ctchungtu)
        {
            try
            {
                ctchungtu.CreateDate = DateTime.Now;
                ctchungtu.CreateBy = CTaiKhoan.MaUser;
                db.CTChungTus.InsertOnSubmit(ctchungtu);
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

        public bool SuaCTChungTu(CTChungTu ctchungtu)
        {
            try
            {
                ctchungtu.ModifyDate = DateTime.Now;
                ctchungtu.ModifyBy = CTaiKhoan.MaUser;
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

        /// <summary>
        /// Lấy Danh Sách các Danh Bộ được đăng ký định mức với Sổ Đăng Ký truyền vào
        /// </summary>
        /// <param name="MaCT"></param>
        /// <returns></returns>
        public List<CTChungTu> LoadDSCTChungTubyID(string MaCT)
        {
            try
            {
                return db.CTChungTus.Where(itemCTChungTu => itemCTChungTu.MaCT == MaCT).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region LichSuChungTu

        public bool ThemLichSuChungTu(LichSuChungTu lichsuchungtu)
        {
            try
            {
                if (db.LichSuChungTus.Count() > 0)
                {
                    decimal MaLSCT = db.LichSuChungTus.Max(itemLSCT => itemLSCT.MaLSCT);
                    lichsuchungtu.MaLSCT = getMaxNextIDTable(MaLSCT);
                }
                else
                    lichsuchungtu.MaLSCT = decimal.Parse(DateTime.Now.Year + "1");
                lichsuchungtu.CreateDate = DateTime.Now;
                lichsuchungtu.CreateBy = CTaiKhoan.MaUser;
                db.LichSuChungTus.InsertOnSubmit(lichsuchungtu);
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

        public bool SuaLichSuChungTu(LichSuChungTu lichsuchungtu)
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
                db = new DB_KTKS_DonKHDataContext();
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
                if (db.LichSuChungTus.Count() > 0)
                {
                    if (db.LichSuChungTus.Max(itemLSCT => itemLSCT.SoPhieu) == null)
                        return decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    else
                        return getMaxNextIDTable(db.LichSuChungTus.Max(itemLSCT => itemLSCT.SoPhieu).Value);
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
        public DataTable LoadDSCatChuyenDM()
        {
            try
            {
                if (CTaiKhoan.RoleDCBD_Xem || CTaiKhoan.RoleDCBD_CapNhat)
                {
                    var query = from itemLSCT in db.LichSuChungTus
                                where itemLSCT.SoPhieu != null
                                select new
                                {
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    itemLSCT.MaCT,
                                    itemLSCT.CatDM,
                                    itemLSCT.SoNKCat,
                                    itemLSCT.NhanNK_MaCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    itemLSCT.NhanDM,
                                    itemLSCT.SoNKNhan,
                                    itemLSCT.CatNK_MaCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    itemLSCT.PhieuDuocKy,
                                };
                    if (query.Count() > 0)
                    {
                        DataTable table = new DataTable();
                        table.Columns.Add("In", typeof(bool));
                        table.Columns.Add("MaLSCT", typeof(string));
                        table.Columns.Add("SoPhieu", typeof(string));
                        table.Columns.Add("MaCT", typeof(string));
                        table.Columns.Add("CatNhan", typeof(string));
                        table.Columns.Add("SoNK", typeof(string));
                        table.Columns.Add("NhanNK_MaCN", typeof(string));
                        table.Columns.Add("NhanNK_DanhBo", typeof(string));
                        table.Columns.Add("NhanNK_HoTen", typeof(string));
                        table.Columns.Add("NhanNK_DiaChi", typeof(string));
                        table.Columns.Add("CatNK_MaCN", typeof(string));
                        table.Columns.Add("CatNK_DanhBo", typeof(string));
                        table.Columns.Add("CatNK_HoTen", typeof(string));
                        table.Columns.Add("CatNK_DiaChi", typeof(string));
                        table.Columns.Add("PhieuDuocKy", typeof(bool));

                        DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                        CChiNhanh _cChiNhanh = new CChiNhanh();
                        foreach (DataRow itemRow in table2.Rows)
                        {
                            DataRow Row = table.NewRow();
                            Row["In"] = false;
                            Row["MaLSCT"] = itemRow["MaLSCT"];
                            Row["SoPhieu"] = itemRow["SoPhieu"];
                            Row["MaCT"] = itemRow["MaCT"];
                            if (itemRow["CatDM"].ToString() != "")
                                if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                                {
                                    Row["CatNhan"] = "Cắt";
                                    Row["SoNK"] = itemRow["SoNKCat"];
                                }
                            if (itemRow["NhanDM"].ToString() != "")
                                if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                                {
                                    Row["CatNhan"] = "Nhận";
                                    Row["SoNK"] = itemRow["SoNKNhan"];
                                }
                            if (itemRow["NhanNK_MaCN"].ToString() != "")
                                Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
                            else
                                Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                            Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
                            Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
                            Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
                            if (itemRow["CatNK_MaCN"].ToString() != "")
                                Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
                            else
                                Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                            Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
                            Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
                            Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
                            Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

                            table.Rows.Add(Row);
                        }
                        return table;
                    }
                    else
                        return null;
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
        /// Lấy Lịch Sử Chứng Từ
        /// </summary>
        /// <param name="MaLSCT"></param>
        /// <returns></returns>
        public LichSuChungTu getLSCTbyID(decimal MaLSCT)
        {
            try
            {
                return db.LichSuChungTus.Single(itemLSCT => itemLSCT.MaLSCT == MaLSCT);
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
        public List<LichSuChungTu> LoadDSLichSuChungTubyID(string MaCT)
        {
            try
            {
                return db.LichSuChungTus.Where(itemLSCT => itemLSCT.MaCT == MaCT).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy LichSuChungTu dự theo Số Phiếu
        /// </summary>
        /// <param name="SoPhieu"></param>
        /// <returns></returns>
        public LichSuChungTu getLichSuChungTubySoPhieu(decimal SoPhieu)
        {
            try
            {
                return db.LichSuChungTus.SingleOrDefault(itemLSCT => itemLSCT.SoPhieu == SoPhieu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region Method

        /// <summary>
        /// Dùng cho Form Cập Nhật Sổ Đăng Ký
        /// </summary>
        /// <param name="chungtu"></param>
        /// <param name="ctchungtu"></param>
        /// <param name="lichsuchungtu"></param>
        /// <returns>true/false</returns>
        public bool ThemChungTu(ChungTu chungtu, CTChungTu ctchungtu, LichSuChungTu lichsuchungtu)
        {
            try
            {
                ///Kiểm tra nếu ChungTu(sổ đăng ký) chưa có thì thêm vào
                if (!CheckChungTu(chungtu.MaCT))
                {
                    chungtu.SoNKConLai = chungtu.SoNKTong;
                    ////chungtu.CreateDate = DateTime.Now;
                    ////chungtu.CreateBy = CTaiKhoan.TaiKhoan;
                    ////db.ChungTus.InsertOnSubmit(chungtu);
                    ////db.SubmitChanges();
                    ThemChungTu(chungtu);
                }
                ///Kiểm tra nếu CTChungTu(danh bộ, sổ đăng ký) chưa có thì thêm vào
                if (!CheckCTChungTu(ctchungtu.DanhBo, ctchungtu.MaCT))
                {
                    ChungTu chungtuCN = getChungTubyID(ctchungtu.MaCT);
                    ///Kiểm tra Số Nhân Khẩu còn có thể cấp
                    if (chungtuCN.SoNKConLai >= ctchungtu.SoNKDangKy)
                    {
                        ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
                        if (ctchungtu.ThoiHan != null)
                            ctchungtu.NgayHetHan = DateTime.Now.AddMonths(ctchungtu.ThoiHan.Value);
                        else
                            ctchungtu.NgayHetHan = null;
                        //ctchungtu.CreateDate = DateTime.Now;
                        //ctchungtu.CreateBy = CTaiKhoan.TaiKhoan;
                        //db.CTChungTus.InsertOnSubmit(ctchungtu);
                        ThemCTChungTu(ctchungtu);

                        ///Cập nhật Số Nhân Khẩu Cấp cho bảng ChungTu
                        chungtuCN.SoNKConLai = chungtuCN.SoNKConLai - ctchungtu.SoNKDangKy.Value;
                        chungtuCN.SoNKDaCap = ctchungtu.SoNKDangKy.Value;
                        db.SubmitChanges();

                        ///Cập nhật bảng LichSuChungTu
                        lichsuchungtu.MaCT = ctchungtu.MaCT;
                        lichsuchungtu.DanhBo = ctchungtu.DanhBo;
                        lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
                        lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
                        lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
                        lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
                        lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;
                        if (chungtuCN.YeuCauCat)
                        {
                            lichsuchungtu.SoPhieu = getMaxNextSoPhieuLSCT();
                            chungtuCN.SoPhieu = lichsuchungtu.SoPhieu;
                            lichsuchungtu.NhanDM = true;

                            lichsuchungtu.CatNK_MaCN = ctchungtu.CatNK_MaCN;
                            lichsuchungtu.CatNK_DanhBo = ctchungtu.CatNK_DanhBo;
                            lichsuchungtu.CatNK_HoTen = ctchungtu.CatNK_HoTen;
                            lichsuchungtu.CatNK_DiaChi = ctchungtu.CatNK_DiaChi;
                            lichsuchungtu.SoNKNhan = ctchungtu.CatNK_SoNKCat;
                            CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                lichsuchungtu.ChucVu = "GIÁM ĐỐC";
                            else
                                lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        }
                        ThemLichSuChungTu(lichsuchungtu);

                        
                        //MessageBox.Show("Thành công Thêm ChungTu Method", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Sổ này đã được đăng ký với Danh Bộ này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Dùng cho Form Cập Nhật Sổ Đăng Ký
        /// </summary>
        /// <param name="chungtu"></param>
        /// <param name="ctchungtu"></param>
        /// <param name="lichsuchungtu"></param>
        /// <returns></returns>
        public bool SuaChungTu(ChungTu chungtu, CTChungTu ctchungtu, LichSuChungTu lichsuchungtu)
        {
            try
            {
                bool flagEdited = false;
                ///Cập Nhật bảng ChungTu khi thay đổi Tổng Nhân Khẩu (frmSoDK)
                ChungTu chungtuCN = getChungTubyID(chungtu.MaCT);
                ///Kiểm tra Tổng Nhân Khẩu có thay đổi hay không
                if (chungtuCN.SoNKTong != chungtu.SoNKTong)
                    if (chungtu.SoNKTong - chungtuCN.SoNKTong + chungtuCN.SoNKConLai >= 0)
                    {
                        chungtuCN.SoNKConLai = chungtu.SoNKTong - chungtuCN.SoNKTong + chungtuCN.SoNKConLai;
                        chungtuCN.SoNKTong = chungtu.SoNKTong;
                        chungtuCN.ModifyDate = DateTime.Now;
                        chungtuCN.ModifyBy = CTaiKhoan.MaUser;
                        flagEdited = true;
                    }
                    else
                    {
                        MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                /////Kiểm tra Địa Chỉ có thay đổi hay không
                //if (chungtuCN.DiaChi != chungtu.DiaChi)
                //{
                //    chungtuCN.DiaChi = chungtu.DiaChi;
                //    chungtuCN.ModifyDate = DateTime.Now;
                //    chungtuCN.ModifyBy = CTaiKhoan.TaiKhoan;
                //}

                ///Cập Nhật bảng CTChungTu khi thay đổi Số Nhân Khẩu đăng ký (frmSoDK)
                CTChungTu ctchungtuCN = getCTChungTubyID(ctchungtu.DanhBo, ctchungtu.MaCT);
                ///Kiểm tra Số Nhân Khẩu đăng ký có thay đổi hay không
                if (ctchungtuCN.SoNKDangKy != ctchungtu.SoNKDangKy)
                    if (chungtuCN.SoNKConLai >= ctchungtu.SoNKDangKy - ctchungtuCN.SoNKDangKy)
                    {
                        ///Cập nhật Số Nhân Khẩu Cấp cho bảng ChungTu
                        chungtuCN.SoNKConLai = chungtuCN.SoNKConLai - (ctchungtu.SoNKDangKy.Value - ctchungtuCN.SoNKDangKy.Value);
                        chungtuCN.SoNKDaCap = ctchungtu.SoNKDangKy.Value;
                        chungtuCN.ModifyDate = DateTime.Now;
                        chungtuCN.ModifyBy = CTaiKhoan.MaUser;
                        ///Cập nhật bảng CTChungTu
                        ctchungtuCN.SoNKDangKy = ctchungtu.SoNKDangKy;
                        ctchungtuCN.ThoiHan = ctchungtu.ThoiHan;
                        if (ctchungtu.ThoiHan != null)
                            ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
                            ctchungtuCN.NgayHetHan = ctchungtuCN.CreateDate.Value.AddMonths(ctchungtu.ThoiHan.Value);
                        else
                            ctchungtuCN.NgayHetHan = null;
                        ctchungtuCN.ModifyDate = DateTime.Now;
                        ctchungtuCN.ModifyBy = CTaiKhoan.MaUser;
                        flagEdited = true;
                    }
                    else
                    {
                        MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                if (ctchungtuCN.ThoiHan != ctchungtu.ThoiHan)
                {
                    ctchungtuCN.ThoiHan = ctchungtu.ThoiHan;
                    if (ctchungtu.ThoiHan != null)
                        ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
                        ctchungtuCN.NgayHetHan = ctchungtuCN.CreateDate.Value.AddMonths(ctchungtu.ThoiHan.Value);
                    else
                        ctchungtuCN.NgayHetHan = null;
                    ctchungtuCN.ModifyDate = DateTime.Now;
                    ctchungtuCN.ModifyBy = CTaiKhoan.MaUser;
                    flagEdited = true;
                }
                if (chungtu.YeuCauCat != chungtuCN.YeuCauCat || ctchungtu.YeuCauCat != ctchungtuCN.YeuCauCat)
                    if (chungtu.YeuCauCat || ctchungtu.YeuCauCat)
                    {

                        chungtuCN.YeuCauCat = true;
                        chungtuCN.CatNK_MaCN = chungtu.CatNK_MaCN;
                        chungtuCN.CatNK_DanhBo = chungtu.CatNK_DanhBo;
                        chungtuCN.CatNK_HoTen = chungtu.CatNK_HoTen;
                        chungtuCN.CatNK_DiaChi = chungtu.CatNK_DiaChi;
                        chungtuCN.CatNK_SoNKCat = chungtu.CatNK_SoNKCat;
                        ///
                        ctchungtuCN.YeuCauCat = true;
                        ctchungtuCN.CatNK_MaCN = ctchungtu.CatNK_MaCN;
                        ctchungtuCN.CatNK_DanhBo = ctchungtu.CatNK_DanhBo;
                        ctchungtuCN.CatNK_HoTen = ctchungtu.CatNK_HoTen;
                        ctchungtuCN.CatNK_DiaChi = ctchungtu.CatNK_DiaChi;
                        ctchungtuCN.CatNK_SoNKCat = ctchungtu.CatNK_SoNKCat;
                        ///
                        LichSuChungTu lichsuchungtuCN = getLichSuChungTubySoPhieu(chungtuCN.SoPhieu.Value);
                        lichsuchungtuCN.CatNK_MaCN = ctchungtu.CatNK_MaCN;
                        lichsuchungtuCN.CatNK_DanhBo = ctchungtu.CatNK_DanhBo;
                        lichsuchungtuCN.CatNK_HoTen = ctchungtu.CatNK_HoTen;
                        lichsuchungtuCN.CatNK_DiaChi = ctchungtu.CatNK_DiaChi;
                        lichsuchungtuCN.SoNKNhan = ctchungtu.CatNK_SoNKCat;
                        SuaLichSuChungTu(lichsuchungtuCN);
                    }
                    else
                    {
                        chungtuCN.YeuCauCat = false;
                        ctchungtuCN.YeuCauCat = false;
                    }
                ///Thêm LichSuChungTu
                if (flagEdited)
                {
                    lichsuchungtu.MaCT = chungtuCN.MaCT;
                    lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
                    lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
                    lichsuchungtu.DanhBo = ctchungtuCN.DanhBo;
                    lichsuchungtu.SoNKDangKy = ctchungtuCN.SoNKDangKy;
                    lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
                    lichsuchungtu.ThoiHan = ctchungtuCN.ThoiHan;
                    lichsuchungtu.NgayHetHan = ctchungtuCN.NgayHetHan;

                    ThemLichSuChungTu(lichsuchungtu);
                    flagEdited = false;
                }
                db.SubmitChanges();
                //MessageBox.Show("Thành công Sửa ChungTu Method", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
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
        public bool NhanChungTu(ChungTu chungtu, CTChungTu ctchungtu, LichSuChungTu lichsuchungtu)
        {
            try
            {
                ///Kiểm tra có thêm mới ChungTu hay không
                bool flagAddCT = false;
                ///Kiểm tra nếu ChungTu(sổ đăng ký) chưa có thì thêm vào
                if (!CheckChungTu(chungtu.MaCT))
                {
                    ThemChungTu(chungtu);
                    flagAddCT = true;
                }
                ChungTu chungtuCN = getChungTubyID(ctchungtu.MaCT);
                CTChungTu ctchungtuCN = new CTChungTu();
                ctchungtuCN = null;
                ///Nếu đã có đăng ký thì ta xét số Nhân Khẩu nhận thêm có vượt quá Tổng số Nhân Khẩu hay không
                if (CheckCTChungTu(ctchungtu.DanhBo, ctchungtu.MaCT))
                {
                    chungtuCN.SoNKTong = chungtu.SoNKTong;
                    if (chungtuCN.SoNKTong >= chungtuCN.SoNKNhan + ctchungtu.SoNKDangKy)
                    {
                        chungtuCN.SoNKNhan += ctchungtu.SoNKDangKy.Value;
                        chungtuCN.SoNKDaCap += ctchungtu.SoNKDangKy.Value;
                        chungtuCN.SoNKConLai = chungtuCN.SoNKNhan - chungtuCN.SoNKDaCap;
                        chungtuCN.ModifyDate = DateTime.Now;
                        chungtuCN.ModifyBy = CTaiKhoan.MaUser;

                        ///Cập nhật CTChungTu
                        ctchungtuCN = getCTChungTubyID(ctchungtu.DanhBo, ctchungtu.MaCT);
                        ctchungtuCN.SoNKDangKy += ctchungtu.SoNKDangKy;
                        ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
                        if (ctchungtu.ThoiHan != null)
                            ctchungtuCN.NgayHetHan = DateTime.Now.AddMonths(ctchungtu.ThoiHan.Value);
                        else
                            ctchungtuCN.NgayHetHan = null;
                        ctchungtuCN.ModifyDate = DateTime.Now;
                        ctchungtuCN.ModifyBy = CTaiKhoan.MaUser;
                    }
                    else
                    {
                        MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                ///Nếu không có thì nhập vô
                else
                {
                    ///Nếu lần đầu thêm ChungTu, cái này dễ nhất ChungTu này chưa có nhận cho DanhBo nào hết nên ta thêm trực tiếp vào
                    if (flagAddCT)
                    {
                        chungtuCN.SoNKNhan = ctchungtu.SoNKDangKy.Value;
                        chungtuCN.SoNKDaCap = ctchungtu.SoNKDangKy.Value;
                        chungtuCN.SoNKConLai = chungtuCN.SoNKNhan - chungtuCN.SoNKDaCap;
                    }
                    ///ChungTu đã có trước đó, ta xét số Nhân Khẩu nhận thêm có vượt quá Tổng số Nhân Khẩu hay không
                    else
                    {
                        chungtuCN.SoNKTong = chungtu.SoNKTong;
                        if (chungtuCN.SoNKTong >= chungtuCN.SoNKNhan + ctchungtu.SoNKDangKy)
                        {
                            chungtuCN.SoNKNhan += ctchungtu.SoNKDangKy.Value;
                            chungtuCN.SoNKDaCap += ctchungtu.SoNKDangKy.Value;
                            chungtuCN.SoNKConLai = chungtuCN.SoNKNhan - chungtuCN.SoNKDaCap;
                            chungtuCN.ModifyDate = DateTime.Now;
                            chungtuCN.ModifyBy = CTaiKhoan.MaUser;
                        }
                        else
                        {
                            MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
                    if (ctchungtu.ThoiHan != null)
                        ctchungtu.NgayHetHan = DateTime.Now.AddMonths(ctchungtu.ThoiHan.Value);
                    else
                        ctchungtu.NgayHetHan = null;
                    ThemCTChungTu(ctchungtu);
                }

                ///Cập nhật LichSuChungTu
                lichsuchungtu.MaCT = ctchungtu.MaCT;
                lichsuchungtu.DanhBo = ctchungtu.DanhBo;
                lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
                lichsuchungtu.SoNKNhan = ctchungtu.SoNKDangKy;
                if (ctchungtuCN != null)
                    lichsuchungtu.SoNKDangKy = ctchungtuCN.SoNKDangKy;
                else
                    lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
                lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
                lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
                lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;

                ThemLichSuChungTu(lichsuchungtu);
                //MessageBox.Show("Thành công Thêm NhanChungTu Method", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

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
        public bool CatChuyenChungTu(CTChungTu ctchungtuCat, CTChungTu ctchungtuNhan,int SoNKCat, LichSuChungTu lichsuchungtu)
        {
            try
            {
                CChiNhanh _cChiNhanh=new CChiNhanh();
                ///Cùng Chi Nhánh
                if (_cChiNhanh.getChiNhanhbyID(lichsuchungtu.NhanNK_MaCN.Value).TenCN.ToUpper().Contains("TÂN HÒA"))
                {
                    CTChungTu ctchungtuCatCN = getCTChungTubyID(ctchungtuCat.DanhBo, ctchungtuCat.MaCT);
                    ///Nếu Chứng Từ đã đăng ký với Danh Bộ
                    if (CheckCTChungTu(ctchungtuNhan.DanhBo, ctchungtuNhan.MaCT))
                    {
                        if (ctchungtuCatCN.SoNKDangKy >= SoNKCat)
                        {
                            ///Cập nhật CTChungTu, Danh Bộ Cắt
                            ctchungtuCatCN.SoNKDangKy -= SoNKCat;
                            ctchungtuCatCN.ModifyDate = DateTime.Now;
                            ctchungtuCatCN.ModifyBy = CTaiKhoan.MaUser;

                            ///Cập nhật CTChungTu, Danh Bộ Nhận
                            CTChungTu ctchungtuNhanCN = getCTChungTubyID(ctchungtuNhan.DanhBo,ctchungtuNhan.MaCT);
                            ctchungtuNhanCN.SoNKDangKy += SoNKCat;
                            ctchungtuNhanCN.ModifyDate = DateTime.Now;
                            ctchungtuNhanCN.ModifyBy = CTaiKhoan.MaUser;

                            db.SubmitChanges();

                            ChungTu chungtuCN = getChungTubyID(ctchungtuCat.MaCT);
                            ///Cập nhật LichSuChungTu, Chứng Từ & Danh Bộ Cắt
                            ///Xóa Số Phiếu
                            lichsuchungtu.SoPhieu = null;
                            lichsuchungtu.MaCT = ctchungtuCat.MaCT;
                            lichsuchungtu.DanhBo = ctchungtuCat.DanhBo;
                            lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
                            lichsuchungtu.SoNKCat = SoNKCat;
                            lichsuchungtu.SoNKDangKy = ctchungtuCatCN.SoNKDangKy;
                            lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
                            lichsuchungtu.ThoiHan = ctchungtuCatCN.ThoiHan;
                            lichsuchungtu.NgayHetHan = ctchungtuCatCN.NgayHetHan;
                            lichsuchungtu.CatNK_MaCN = lichsuchungtu.NhanNK_MaCN;
                            ThemLichSuChungTu(lichsuchungtu);

                            ///Cập nhật LichSuChungTu, Chứng Từ & Danh Bộ Nhận
                            LichSuChungTu lichsuchungtuNhan = new LichSuChungTu();
                            lichsuchungtuNhan.MaDon = lichsuchungtu.MaDon;
                            lichsuchungtuNhan.MaCT = ctchungtuNhan.MaCT;
                            lichsuchungtuNhan.DanhBo = ctchungtuNhan.DanhBo;
                            lichsuchungtuNhan.SoNKTong = chungtuCN.SoNKTong;
                            lichsuchungtuNhan.SoNKNhan = SoNKCat;
                            lichsuchungtuNhan.SoNKDangKy = ctchungtuNhanCN.SoNKDangKy;
                            lichsuchungtuNhan.SoNKConLai = chungtuCN.SoNKConLai;
                            lichsuchungtuNhan.ThoiHan = ctchungtuCatCN.ThoiHan;
                            lichsuchungtuNhan.NgayHetHan = ctchungtuCatCN.NgayHetHan;
                            ///Chuyển đổi vị trí Cắt & Nhận
                            lichsuchungtuNhan.CatNK_DanhBo = lichsuchungtu.NhanNK_DanhBo;
                            lichsuchungtuNhan.CatNK_HoTen = lichsuchungtu.NhanNK_HoTen;
                            lichsuchungtuNhan.CatNK_DiaChi = lichsuchungtu.NhanNK_DiaChi;
                            lichsuchungtuNhan.CatNK_MaCN = lichsuchungtu.NhanNK_MaCN;
                            lichsuchungtuNhan.NhanDM = true;
                            lichsuchungtuNhan.NhanNK_MaCN = lichsuchungtu.CatNK_MaCN;
                            lichsuchungtuNhan.NhanNK_DanhBo = lichsuchungtu.CatNK_DanhBo;
                            lichsuchungtuNhan.NhanNK_HoTen = lichsuchungtu.CatNK_HoTen;
                            lichsuchungtuNhan.NhanNK_DiaChi = lichsuchungtu.CatNK_DiaChi;

                            ThemLichSuChungTu(lichsuchungtuNhan);
                        }
                        else
                        {
                            MessageBox.Show("Cắt vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    ///Nếu Chứng Từ chưa đăng ký với Danh Bộ
                    else
                    {
                        if (ctchungtuCatCN.SoNKDangKy >= SoNKCat)
                        {
                            ///Cập nhật CTChungTu, Danh Bộ Cắt
                            ctchungtuCatCN.SoNKDangKy -= SoNKCat;
                            ctchungtuCatCN.ModifyDate = DateTime.Now;
                            ctchungtuCatCN.ModifyBy = CTaiKhoan.MaUser;

                            db.SubmitChanges();
                            
                            ///Thêm CTChungTu, Danh Bộ nhận
                            ctchungtuNhan.SoNKDangKy = SoNKCat;
                            ThemCTChungTu(ctchungtuNhan);

                            ChungTu chungtuCN = getChungTubyID(ctchungtuCat.MaCT);
                            ///Cập nhật LichSuChungTu, Chứng Từ & Danh Bộ Cắt
                            ///Xóa Số Phiếu
                            lichsuchungtu.SoPhieu = null;
                            lichsuchungtu.MaCT = ctchungtuCat.MaCT;
                            lichsuchungtu.DanhBo = ctchungtuCat.DanhBo;
                            lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
                            lichsuchungtu.SoNKCat = SoNKCat;
                            lichsuchungtu.SoNKDangKy = ctchungtuCatCN.SoNKDangKy;
                            lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
                            lichsuchungtu.ThoiHan = ctchungtuCatCN.ThoiHan;
                            lichsuchungtu.NgayHetHan = ctchungtuCatCN.NgayHetHan;
                            ThemLichSuChungTu(lichsuchungtu);

                            ///Cập nhật LichSuChungTu, Chứng Từ & Danh Bộ Nhận
                            LichSuChungTu lichsuchungtuNhan = new LichSuChungTu();
                            lichsuchungtuNhan.MaDon = lichsuchungtu.MaDon;
                            lichsuchungtuNhan.MaCT = ctchungtuNhan.MaCT;
                            lichsuchungtuNhan.DanhBo = ctchungtuNhan.DanhBo;
                            lichsuchungtuNhan.SoNKTong = chungtuCN.SoNKTong;
                            lichsuchungtuNhan.SoNKNhan = SoNKCat;
                            lichsuchungtuNhan.SoNKDangKy = SoNKCat;
                            lichsuchungtuNhan.SoNKConLai = chungtuCN.SoNKConLai;
                            lichsuchungtuNhan.ThoiHan = ctchungtuCatCN.ThoiHan;
                            lichsuchungtuNhan.NgayHetHan = ctchungtuCatCN.NgayHetHan;
                            ///Chuyển đổi vị trí Cắt & Nhận
                            lichsuchungtuNhan.CatNK_DanhBo = lichsuchungtu.NhanNK_DanhBo;
                            lichsuchungtuNhan.CatNK_HoTen = lichsuchungtu.NhanNK_HoTen;
                            lichsuchungtuNhan.CatNK_DiaChi = lichsuchungtu.NhanNK_DiaChi;
                            lichsuchungtuNhan.NhanDM = true;
                            lichsuchungtuNhan.NhanNK_MaCN = lichsuchungtu.NhanNK_MaCN;
                            lichsuchungtuNhan.NhanNK_DanhBo = lichsuchungtu.CatNK_DanhBo;
                            lichsuchungtuNhan.NhanNK_HoTen = lichsuchungtu.CatNK_HoTen;
                            lichsuchungtuNhan.NhanNK_DiaChi = lichsuchungtu.CatNK_DiaChi;

                            ThemLichSuChungTu(lichsuchungtuNhan);
                            //MessageBox.Show("Thành công Thêm CatChuyenChungTu cùng ChiNhanh Method", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Cắt vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                ///Khác Chi Nhánh
                else
                {
                    CTChungTu ctchungtuCN = getCTChungTubyID(ctchungtuCat.DanhBo,ctchungtuCat.MaCT);
                    if (ctchungtuCN.SoNKDangKy >= SoNKCat)
                    {
                        ctchungtuCN.SoNKDangKy -= SoNKCat;
                        ctchungtuCN.ModifyDate = DateTime.Now;
                        ctchungtuCN.ModifyBy = CTaiKhoan.MaUser;

                        ChungTu chungtuCN = getChungTubyID(ctchungtuCat.MaCT);
                        chungtuCN.SoNKCat += SoNKCat;
                        chungtuCN.SoNKDaCap -= SoNKCat;
                        chungtuCN.ModifyDate = DateTime.Now;
                        chungtuCN.ModifyBy = CTaiKhoan.MaUser;

                        db.SubmitChanges();

                        ///Cập nhật LichSuChungTu
                        lichsuchungtu.MaCT = ctchungtuCat.MaCT;
                        lichsuchungtu.DanhBo = ctchungtuCat.DanhBo;
                        lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
                        lichsuchungtu.SoNKCat = SoNKCat;
                        lichsuchungtu.SoNKDangKy = ctchungtuCN.SoNKDangKy;
                        lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
                        lichsuchungtu.ThoiHan = ctchungtuCN.ThoiHan;
                        lichsuchungtu.NgayHetHan = ctchungtuCN.NgayHetHan;

                        ThemLichSuChungTu(lichsuchungtu);
                        //MessageBox.Show("Thành công Thêm CatChuyenChungTu khác ChiNhanh Method", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Cắt vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                return true;
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

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
        /// Chứa hàm lấy dữ liệu từ ChungTu & CTChungTu & LichSuChungTu

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
                                itemCT.MaLCT,
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
                chungtu.CreateBy = CTaiKhoan.TaiKhoan;
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
                chungtu.ModifyBy = CTaiKhoan.TaiKhoan;
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
                return db.CTChungTus.Single(itemCT => itemCT.DanhBo == DanhBo && itemCT.MaCT == MaCT);
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
                ctchungtu.CreateBy = CTaiKhoan.TaiKhoan;
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
                ctchungtu.ModifyBy = CTaiKhoan.TaiKhoan;
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
                lichsuchungtu.CreateBy = CTaiKhoan.TaiKhoan;
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

        public decimal getMaxNextSoPhieuLSCT()
        {
            try
            {
                if (db.LichSuChungTus.Count() > 0)
                {
                    if (db.LichSuChungTus.Max(itemLSCT => itemLSCT.SoPhieu) == null)
                        return decimal.Parse(DateTime.Now.Year + "1");
                    else
                        return getMaxNextIDTable(db.LichSuChungTus.Max(itemLSCT => itemLSCT.SoPhieu).Value);
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
                            lichsuchungtu.NhanDM = true;
                            lichsuchungtu.CatNK_MaCN = chungtuCN.NhanNK_MaCN;
                            lichsuchungtu.CatNK_DanhBo = chungtuCN.NhanNK_DanhBo;
                            lichsuchungtu.CatNK_HoTen = chungtuCN.NhanNK_HoTen;
                            lichsuchungtu.CatNK_DiaChi = chungtuCN.NhanNK_DiaChi;
                            lichsuchungtu.SoNKNhan = chungtuCN.NhanNK_SoNKCat;
                        }
                        ThemLichSuChungTu(lichsuchungtu);

                        db.SubmitChanges();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        chungtuCN.ModifyBy = CTaiKhoan.TaiKhoan;
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
                        chungtuCN.ModifyBy = CTaiKhoan.TaiKhoan;
                        ///Cập nhật bảng CTChungTu
                        ctchungtuCN.SoNKDangKy = ctchungtu.SoNKDangKy;
                        ctchungtuCN.ThoiHan = ctchungtu.ThoiHan;
                        if (ctchungtu.ThoiHan != null)
                            ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
                            ctchungtuCN.NgayHetHan = ctchungtuCN.CreateDate.Value.AddMonths(ctchungtu.ThoiHan.Value);
                        else
                            ctchungtuCN.NgayHetHan = null;
                        ctchungtuCN.ModifyDate = DateTime.Now;
                        ctchungtuCN.ModifyBy = CTaiKhoan.TaiKhoan;
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
                    ctchungtuCN.ModifyBy = CTaiKhoan.TaiKhoan;
                    flagEdited = true;
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
                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        chungtuCN.ModifyBy = CTaiKhoan.TaiKhoan;

                        ///Cập nhật CTChungTu
                        ctchungtuCN = getCTChungTubyID(ctchungtu.DanhBo, ctchungtu.MaCT);
                        ctchungtuCN.SoNKDangKy += ctchungtu.SoNKDangKy;
                        ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
                        if (ctchungtu.ThoiHan != null)
                            ctchungtuCN.NgayHetHan = DateTime.Now.AddMonths(ctchungtu.ThoiHan.Value);
                        else
                            ctchungtuCN.NgayHetHan = null;
                        ctchungtuCN.ModifyDate = DateTime.Now;
                        ctchungtuCN.ModifyBy = CTaiKhoan.TaiKhoan;
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
                            chungtuCN.ModifyBy = CTaiKhoan.TaiKhoan;
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
                lichsuchungtu.SoNKNhan = chungtuCN.SoNKNhan;
                if (ctchungtuCN != null)
                    lichsuchungtu.SoNKDangKy = ctchungtuCN.SoNKDangKy;
                else
                    lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
                lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
                lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
                lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;
                ThemLichSuChungTu(lichsuchungtu);

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
        public bool CatChuyenChungTu(CTChungTu chungtuCat, CTChungTu ctchungtuNhan,int SoNKCat, LichSuChungTu lichsuchungtu)
        {
            try
            {
                CChiNhanh _cChiNhanh=new CChiNhanh();
                if (_cChiNhanh.getChiNhanhbyID(lichsuchungtu.NhanNK_MaCN.Value).TenCN.ToUpper().Contains("TÂN HÒA"))
                {
                    MessageBox.Show("cùng chi nhánh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("khác chi nhánh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return true;
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

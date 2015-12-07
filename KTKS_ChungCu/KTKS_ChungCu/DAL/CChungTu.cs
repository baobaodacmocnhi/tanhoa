using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_ChungCu.LinQ;
using System.Windows.Forms;

namespace KTKS_ChungCu.DAL
{
    class CChungTu
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng ChungTu & CTChungTu & LichSuChungTu
        protected static dbChungCuDataContext db = new dbChungCuDataContext();
        protected static dbDonKHDataContext dbDonKH = new dbDonKHDataContext();

        public decimal getMaxNextIDTable(decimal id)
        {
            string nam = id.ToString().Substring(id.ToString().Length - 2, 2);
            string stt = id.ToString().Substring(0, id.ToString().Length - 2);
            if (decimal.Parse(nam) == decimal.Parse(DateTime.Now.ToString("yy")))
            {
                stt = (decimal.Parse(stt) + 1).ToString();
            }
            else
            {
                stt = "1";
                nam = DateTime.Now.ToString("yy");
            }
            return decimal.Parse(stt + nam);
        }

        public DataTable LoadDSChungTu(string DanhBo)
        {
            try
            {
                var query = from itemCTCT in db.CTChungTus
                            join itemCT in db.ChungTus on itemCTCT.MaCT equals itemCT.MaCT
                            //join itemLCT in dbDonKH.LoaiChungTus on itemCT.MaLCT equals itemLCT.MaLCT
                            where itemCTCT.DanhBo == DanhBo
                            select new
                            {
                                itemCTCT.DanhBo,
                                itemCTCT.Lo,
                                itemCTCT.Phong,
                                itemCT.MaLCT,
                                //itemLCT.TenLCT,
                                itemCTCT.MaCT,
                                itemCT.HoTen,
                                itemCT.SoNKTong,
                                itemCTCT.SoNKDangKy,
                                itemCTCT.NgayHetHan,
                                itemCTCT.ThoiHan,
                                itemCTCT.GhiChu,
                            };
                return Function.CLinQToDataTable.LINQToDataTable(query);
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

        public bool ThemChungTu(ChungTu chungtu)
        {
            try
            {
                chungtu.CreateDate = DateTime.Now;
                chungtu.CreateBy = -1;
                db.ChungTus.InsertOnSubmit(chungtu);
                db.SubmitChanges();
                //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbChungCuDataContext();
                return false;
            }
        }

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

        public bool CheckCTChungTu(string DanhBo, string MaCT,string Lo,string Phong)
        {
            try
            {
                return db.CTChungTus.Any(itemCT => itemCT.DanhBo == DanhBo && itemCT.MaCT == MaCT && itemCT.Lo == Lo && itemCT.Phong == Phong);
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

        public bool ThemCTChungTu(CTChungTu ctchungtu)
        {
            try
            {
                ctchungtu.CreateDate = DateTime.Now;
                ctchungtu.CreateBy = -1;
                db.CTChungTus.InsertOnSubmit(ctchungtu);
                db.SubmitChanges();
                //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbChungCuDataContext();
                return false;
            }
        }

        //public bool ThemLichSuChungTu(LichSuChungTu lichsuchungtu)
        //{
        //    try
        //    {
        //        if (db.LichSuChungTus.Count() > 0)
        //        {
        //            decimal MaLSCT = db.LichSuChungTus.Max(itemLSCT => itemLSCT.MaLSCT);
        //            lichsuchungtu.MaLSCT = getMaxNextIDTable(MaLSCT);
        //        }
        //        else
        //            lichsuchungtu.MaLSCT = decimal.Parse(DateTime.Now.Year + "1");
        //        lichsuchungtu.CreateDate = DateTime.Now;
        //        lichsuchungtu.CreateBy = -1;
        //        db.LichSuChungTus.InsertOnSubmit(lichsuchungtu);
        //        db.SubmitChanges();
        //        //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        db = new dbChungCuDataContext();
        //        return false;
        //    }
        //}

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

        /// <summary>
        /// Dùng cho Form Cập Nhật Sổ Đăng Ký, khi có >2 yêu cầu cắt nhân khẩu
        /// </summary>
        /// <param name="chungtu"></param>
        /// <param name="ctchungtu"></param>
        /// <param name="lichsuchungtu"></param>
        /// <returns></returns>
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
                        chungtuCN.SoNKConLai = chungtuCN.SoNKConLai - ctchungtu.SoNKDangKy;
                        chungtuCN.SoNKDaCap = ctchungtu.SoNKDangKy;
                        db.SubmitChanges();

                        ///Cập nhật bảng LichSuChungTu
                        lichsuchungtu.MaCT = ctchungtu.MaCT;
                        lichsuchungtu.DanhBo = ctchungtu.DanhBo;
                        lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
                        lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
                        lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
                        lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
                        lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;
                        
                        ThemLichSuChungTu(lichsuchungtu);

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
                db = new dbChungCuDataContext();
                return false;
            }
        }

        /// <summary>
        /// Dùng cho Form Cập Nhật Sổ Đăng Ký, khi có >2 yêu cầu cắt nhân khẩu
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
                        chungtuCN.ModifyBy = -1;
                        flagEdited = true;
                    }
                    else
                    {
                        MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                ///Kiểm tra Địa Chỉ có thay đổi hay không
                if (chungtuCN.HoTen != chungtu.HoTen || chungtuCN.DiaChi != chungtu.DiaChi || chungtuCN.MaLCT != chungtu.MaLCT)
                {
                    if (chungtuCN.HoTen != chungtu.HoTen)
                        chungtuCN.HoTen = chungtu.HoTen;
                    if (chungtuCN.DiaChi != chungtu.DiaChi)
                        chungtuCN.DiaChi = chungtu.DiaChi;
                    if (chungtuCN.MaLCT != chungtu.MaLCT)
                        chungtuCN.MaLCT = chungtu.MaLCT;
                    chungtuCN.ModifyDate = DateTime.Now;
                    chungtuCN.ModifyBy = -1;
                }

                ///Cập Nhật bảng CTChungTu khi thay đổi Số Nhân Khẩu đăng ký (frmSoDK)
                CTChungTu ctchungtuCN = getCTChungTubyID(ctchungtu.DanhBo, ctchungtu.MaCT);
                ///Kiểm tra Số Nhân Khẩu đăng ký có thay đổi hay không
                if (ctchungtuCN.SoNKDangKy != ctchungtu.SoNKDangKy)
                    if (chungtuCN.SoNKConLai >= ctchungtu.SoNKDangKy - ctchungtuCN.SoNKDangKy)
                    {
                        ///Cập nhật Số Nhân Khẩu Cấp cho bảng ChungTu
                        chungtuCN.SoNKConLai = chungtuCN.SoNKConLai - (ctchungtu.SoNKDangKy - ctchungtuCN.SoNKDangKy);
                        chungtuCN.SoNKDaCap = ctchungtu.SoNKDangKy;
                        chungtuCN.ModifyDate = DateTime.Now;
                        ///Cập nhật bảng CTChungTu
                        ctchungtuCN.SoNKDangKy = ctchungtu.SoNKDangKy;

                        //ctchungtuCN.ThoiHan = ctchungtu.ThoiHan;
                        //if (ctchungtu.ThoiHan != null)
                        //    ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
                        //    ctchungtuCN.NgayHetHan = ctchungtuCN.CreateDate.Value.AddMonths(ctchungtu.ThoiHan.Value);
                        //else
                        //    ctchungtuCN.NgayHetHan = null;

                        ctchungtuCN.ModifyDate = DateTime.Now;
                        ctchungtuCN.ModifyBy = -1;
                        flagEdited = true;
                    }
                    else
                    {
                        MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                if (ctchungtuCN.ThoiHan != ctchungtu.ThoiHan || ctchungtuCN.Lo != ctchungtu.Lo || ctchungtuCN.Phong != ctchungtu.Phong || ctchungtuCN.GhiChu != ctchungtu.GhiChu)
                {
                    if (ctchungtuCN.ThoiHan != ctchungtu.ThoiHan)
                    {
                        ctchungtuCN.ThoiHan = ctchungtu.ThoiHan;
                        if (ctchungtu.ThoiHan != null)
                            ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
                            ctchungtuCN.NgayHetHan = ctchungtuCN.CreateDate.Value.AddMonths(ctchungtu.ThoiHan.Value);
                        else
                            ctchungtuCN.NgayHetHan = null;
                        flagEdited = true;
                    }
                    if (ctchungtuCN.Lo != ctchungtu.Lo)
                        ctchungtuCN.Lo = ctchungtu.Lo;
                    if (ctchungtuCN.Phong != ctchungtu.Phong)
                        ctchungtuCN.Phong = ctchungtu.Phong;
                    if (ctchungtuCN.GhiChu != ctchungtu.GhiChu)
                        ctchungtuCN.GhiChu = ctchungtu.GhiChu;
                    ctchungtuCN.ModifyDate = DateTime.Now;
                    ctchungtuCN.ModifyBy = -1;
                }

                //if (ctchungtu.YeuCauCat != ctchungtuCN.YeuCauCat)
                if (ctchungtu.YeuCauCat)
                {
                    //chungtuCN.YeuCauCat = true;
                    //chungtuCN.CatNK_MaCN = chungtu.CatNK_MaCN;
                    //chungtuCN.CatNK_DanhBo = chungtu.CatNK_DanhBo;
                    //chungtuCN.CatNK_HoTen = chungtu.CatNK_HoTen;
                    //chungtuCN.CatNK_DiaChi = chungtu.CatNK_DiaChi;
                    //chungtuCN.CatNK_SoNKCat = chungtu.CatNK_SoNKCat;
                    ///
                    ctchungtuCN.YeuCauCat = true;
                    ctchungtuCN.CatNK_MaCN = ctchungtu.CatNK_MaCN;
                    ctchungtuCN.CatNK_DanhBo = ctchungtu.CatNK_DanhBo;
                    ctchungtuCN.CatNK_HoTen = ctchungtu.CatNK_HoTen;
                    ctchungtuCN.CatNK_DiaChi = ctchungtu.CatNK_DiaChi;
                    ctchungtuCN.CatNK_SoNKCat = ctchungtu.CatNK_SoNKCat;
                    ///Nếu phiếu đã có
                    if (ctchungtuCN.SoPhieu.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu.Value);
                        lichsuchungtuCN.CatNK_MaCN = ctchungtu.CatNK_MaCN;
                        lichsuchungtuCN.CatNK_DanhBo = ctchungtu.CatNK_DanhBo;
                        lichsuchungtuCN.CatNK_HoTen = ctchungtu.CatNK_HoTen;
                        lichsuchungtuCN.CatNK_DiaChi = ctchungtu.CatNK_DiaChi;
                        lichsuchungtuCN.SoNKNhan = ctchungtu.CatNK_SoNKCat;
                        if (SuaLichSuChungTu(lichsuchungtuCN))
                        {
                            //CatChuyenDM catchuyendm = _cCatChuyenDM.getCatChuyenDMbySoPhieu(ctchungtuCN.SoPhieu.Value);
                            //catchuyendm.CatNK_MaCN = lichsuchungtuCN.CatNK_MaCN;
                            //catchuyendm.CatNK_DanhBo = lichsuchungtuCN.CatNK_DanhBo;
                            //catchuyendm.CatNK_HoTen = lichsuchungtuCN.CatNK_HoTen;
                            //catchuyendm.CatNK_DiaChi = lichsuchungtuCN.CatNK_DiaChi;
                            //catchuyendm.SoNKNhan = lichsuchungtuCN.SoNKNhan;

                            //_cCatChuyenDM.SuaCatChuyemDM(catchuyendm);
                        }
                    }
                    ///Nếu chưa có phiếu
                    else
                    {
                        lichsuchungtu.MaCT = ctchungtu.MaCT;
                        lichsuchungtu.DanhBo = ctchungtu.DanhBo;
                        lichsuchungtu.SoNKTong = chungtuCN.SoNKTong;
                        lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
                        lichsuchungtu.SoNKConLai = chungtuCN.SoNKConLai;
                        lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
                        lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;
                        ///
                        lichsuchungtu.SoPhieu = getMaxNextSoPhieuLSCT();
                        ctchungtuCN.SoPhieu = lichsuchungtu.SoPhieu;
                        lichsuchungtu.YeuCauCat = true;

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
                        if (ThemLichSuChungTu(lichsuchungtu))
                        {
                            ctchungtuCN.SoPhieu = lichsuchungtu.SoPhieu;
                            //CatChuyenDM catchuyendm = new CatChuyenDM();
                            //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
                            //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
                        }
                    }
                }
                else
                {
                    ctchungtuCN.YeuCauCat = false;
                    if (ctchungtuCN.SoPhieu.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu.Value);
                        XoaLichSuChungTu(lichsuchungtuCN);
                    }
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
                db = new dbChungCuDataContext();
                return false;
            }
        }

        #region LichSuChungTu

        public bool ThemLichSuChungTu(LichSuChungTu lichsuchungtu)
        {
            try
            {
                if (db.LichSuChungTus.Count() > 0)
                {
                    string ID = "MaLSCT";
                    string Table = "LichSuChungTu";
                    decimal MaLSCT = db.ExecuteQuery<decimal>("declare @Ma int " +
                        "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                        "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                    //decimal MaLSCT = db.LichSuChungTus.Max(itemLSCT => itemLSCT.MaLSCT);
                    lichsuchungtu.MaLSCT = getMaxNextIDTable(MaLSCT);
                }
                else
                    lichsuchungtu.MaLSCT = decimal.Parse(DateTime.Now.Year + "1");
                lichsuchungtu.CreateDate = DateTime.Now;
                db.LichSuChungTus.InsertOnSubmit(lichsuchungtu);
                db.SubmitChanges();
                //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbChungCuDataContext();
                return false;
            }
        }

        public bool SuaLichSuChungTu(LichSuChungTu lichsuchungtu)
        {
            try
            {
                lichsuchungtu.ModifyDate = DateTime.Now;
                db.SubmitChanges();
                //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbChungCuDataContext();
                return false;
            }
        }

        public bool XoaLichSuChungTu(LichSuChungTu lichsuchungtu)
        {
            try
            {
                db.LichSuChungTus.DeleteOnSubmit(lichsuchungtu);
                db.SubmitChanges();
                //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbChungCuDataContext();
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
                    {
                        string ID = "SoPhieu";
                        string Table = "LichSuChungTu";
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
        public DataTable LoadDSCatChuyenDM()
        {
            //string a = "";
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                                where itemLSCT.SoPhieu != null
                                //where itemLSCT.MaLSCT == 126114
                                orderby itemLSCT.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    //SoPhieuDCBD = itemDCBD.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    itemLSCT.CatDM,
                                    itemLSCT.SoNKCat,
                                    itemLSCT.NhanNK_MaCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    itemLSCT.NhanDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.SoNKNhan,
                                    itemLSCT.CatNK_MaCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaDon,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CreateBy,
                                };
                    if (query.Count() > 0)
                    {
                        //DataTable table = new DataTable();
                        //table.Columns.Add("In", typeof(bool));
                        //table.Columns.Add("MaLSCT", typeof(string));
                        //table.Columns.Add("SoPhieu", typeof(string));
                        //table.Columns.Add("SoPhieuDCBD", typeof(string));
                        //table.Columns.Add("CreateDate", typeof(string));
                        //table.Columns.Add("MaCT", typeof(string));
                        //table.Columns.Add("CatNhan", typeof(string));
                        //table.Columns.Add("SoNK", typeof(string));
                        //table.Columns.Add("NhanNK_MaCN", typeof(string));
                        //table.Columns.Add("NhanNK_DanhBo", typeof(string));
                        //table.Columns.Add("NhanNK_HoTen", typeof(string));
                        //table.Columns.Add("NhanNK_DiaChi", typeof(string));
                        //table.Columns.Add("CatNK_MaCN", typeof(string));
                        //table.Columns.Add("CatNK_DanhBo", typeof(string));
                        //table.Columns.Add("CatNK_HoTen", typeof(string));
                        //table.Columns.Add("CatNK_DiaChi", typeof(string));
                        //table.Columns.Add("PhieuDuocKy", typeof(bool));

                        //DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                        //CChiNhanh _cChiNhanh = new CChiNhanh();
                        //foreach (DataRow itemRow in table2.Rows)
                        //{
                        //    //a = itemRow["MaLSCT"].ToString();
                        //    DataRow Row = table.NewRow();
                        //    Row["In"] = false;
                        //    Row["MaLSCT"] = itemRow["MaLSCT"];
                        //    Row["SoPhieu"] = itemRow["SoPhieu"];
                        //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                        //        if (db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
                        //            Row["SoPhieuDCBD"] = db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
                        //        else
                        //            Row["SoPhieuDCBD"] = "";
                        //    else
                        //        Row["SoPhieuDCBD"] = "";
                        //    Row["CreateDate"] = itemRow["CreateDate"];
                        //    Row["MaCT"] = itemRow["MaCT"];
                        //    if (itemRow["CatDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Cắt";
                        //            Row["SoNK"] = itemRow["SoNKCat"];
                        //        }
                        //    if (itemRow["NhanDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Nhận";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["YeuCauCat"].ToString() != "")
                        //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "YC Cắt";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["NhanNK_MaCN"].ToString() != "")
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
                        //    else
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
                        //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
                        //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
                        //    if (itemRow["CatNK_MaCN"].ToString() != "")
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
                        //    else
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
                        //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
                        //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
                        //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

                        //    table.Rows.Add(Row);
                        //}
                        //return table;
                        return Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                        return null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCatChuyenDMByMaDon(decimal MaDon)
        {
            //string a = "";
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                                where itemLSCT.SoPhieu != null && (itemLSCT.MaDon == MaDon || itemLSCT.MaDonTXL == MaDon)
                                //where itemLSCT.MaLSCT == 126114
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    In = false,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    //SoPhieuDCBD = itemDCBD.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    itemLSCT.CatDM,
                                    itemLSCT.SoNKCat,
                                    itemLSCT.NhanNK_MaCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    itemLSCT.NhanDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.SoNKNhan,
                                    itemLSCT.CatNK_MaCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaDon,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CreateBy,
                                };
                    if (query.Count() > 0)
                    {
                        //DataTable table = new DataTable();
                        //table.Columns.Add("In", typeof(bool));
                        //table.Columns.Add("MaLSCT", typeof(string));
                        //table.Columns.Add("SoPhieu", typeof(string));
                        //table.Columns.Add("SoPhieuDCBD", typeof(string));
                        //table.Columns.Add("CreateDate", typeof(string));
                        //table.Columns.Add("MaCT", typeof(string));
                        //table.Columns.Add("CatNhan", typeof(string));
                        //table.Columns.Add("SoNK", typeof(string));
                        //table.Columns.Add("NhanNK_MaCN", typeof(string));
                        //table.Columns.Add("NhanNK_DanhBo", typeof(string));
                        //table.Columns.Add("NhanNK_HoTen", typeof(string));
                        //table.Columns.Add("NhanNK_DiaChi", typeof(string));
                        //table.Columns.Add("CatNK_MaCN", typeof(string));
                        //table.Columns.Add("CatNK_DanhBo", typeof(string));
                        //table.Columns.Add("CatNK_HoTen", typeof(string));
                        //table.Columns.Add("CatNK_DiaChi", typeof(string));
                        //table.Columns.Add("PhieuDuocKy", typeof(bool));

                        //DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                        //CChiNhanh _cChiNhanh = new CChiNhanh();
                        //foreach (DataRow itemRow in table2.Rows)
                        //{
                        //    //a = itemRow["MaLSCT"].ToString();
                        //    DataRow Row = table.NewRow();
                        //    Row["In"] = false;
                        //    Row["MaLSCT"] = itemRow["MaLSCT"];
                        //    Row["SoPhieu"] = itemRow["SoPhieu"];
                        //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                        //        if (db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
                        //            Row["SoPhieuDCBD"] = db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
                        //        else
                        //            Row["SoPhieuDCBD"] = "";
                        //    else
                        //        Row["SoPhieuDCBD"] = "";
                        //    Row["CreateDate"] = itemRow["CreateDate"];
                        //    Row["MaCT"] = itemRow["MaCT"];
                        //    if (itemRow["CatDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Cắt";
                        //            Row["SoNK"] = itemRow["SoNKCat"];
                        //        }
                        //    if (itemRow["NhanDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Nhận";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["YeuCauCat"].ToString() != "")
                        //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "YC Cắt";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["NhanNK_MaCN"].ToString() != "")
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
                        //    else
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
                        //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
                        //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
                        //    if (itemRow["CatNK_MaCN"].ToString() != "")
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
                        //    else
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
                        //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
                        //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
                        //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

                        //    table.Rows.Add(Row);
                        //}
                        //return table;
                        return Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                        return null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCatChuyenDMByMaDons(decimal TuMaDon, decimal DenMaDon)
        {
            //string a = "";
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                                where itemLSCT.SoPhieu != null &&
                                ((itemLSCT.MaDon.Value.ToString().Substring(itemLSCT.MaDon.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemLSCT.MaDon.Value.ToString().Substring(itemLSCT.MaDon.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                                && (itemLSCT.MaDon >= TuMaDon && itemLSCT.MaDon <= DenMaDon))
                                || ((itemLSCT.MaDonTXL.Value.ToString().Substring(itemLSCT.MaDonTXL.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemLSCT.MaDonTXL.Value.ToString().Substring(itemLSCT.MaDonTXL.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                                && (itemLSCT.MaDonTXL >= TuMaDon && itemLSCT.MaDonTXL <= DenMaDon))
                                //where itemLSCT.MaLSCT == 126114
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    In = false,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    //SoPhieuDCBD = itemDCBD.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    itemLSCT.CatDM,
                                    itemLSCT.SoNKCat,
                                    itemLSCT.NhanNK_MaCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    itemLSCT.NhanDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.SoNKNhan,
                                    itemLSCT.CatNK_MaCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaDon,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CreateBy,
                                };
                    if (query.Count() > 0)
                    {
                        //DataTable table = new DataTable();
                        //table.Columns.Add("In", typeof(bool));
                        //table.Columns.Add("MaLSCT", typeof(string));
                        //table.Columns.Add("SoPhieu", typeof(string));
                        //table.Columns.Add("SoPhieuDCBD", typeof(string));
                        //table.Columns.Add("CreateDate", typeof(string));
                        //table.Columns.Add("MaCT", typeof(string));
                        //table.Columns.Add("CatNhan", typeof(string));
                        //table.Columns.Add("SoNK", typeof(string));
                        //table.Columns.Add("NhanNK_MaCN", typeof(string));
                        //table.Columns.Add("NhanNK_DanhBo", typeof(string));
                        //table.Columns.Add("NhanNK_HoTen", typeof(string));
                        //table.Columns.Add("NhanNK_DiaChi", typeof(string));
                        //table.Columns.Add("CatNK_MaCN", typeof(string));
                        //table.Columns.Add("CatNK_DanhBo", typeof(string));
                        //table.Columns.Add("CatNK_HoTen", typeof(string));
                        //table.Columns.Add("CatNK_DiaChi", typeof(string));
                        //table.Columns.Add("PhieuDuocKy", typeof(bool));

                        //DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                        //CChiNhanh _cChiNhanh = new CChiNhanh();
                        //foreach (DataRow itemRow in table2.Rows)
                        //{
                        //    //a = itemRow["MaLSCT"].ToString();
                        //    DataRow Row = table.NewRow();
                        //    Row["In"] = false;
                        //    Row["MaLSCT"] = itemRow["MaLSCT"];
                        //    Row["SoPhieu"] = itemRow["SoPhieu"];
                        //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                        //        if (db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
                        //            Row["SoPhieuDCBD"] = db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
                        //        else
                        //            Row["SoPhieuDCBD"] = "";
                        //    else
                        //        Row["SoPhieuDCBD"] = "";
                        //    Row["CreateDate"] = itemRow["CreateDate"];
                        //    Row["MaCT"] = itemRow["MaCT"];
                        //    if (itemRow["CatDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Cắt";
                        //            Row["SoNK"] = itemRow["SoNKCat"];
                        //        }
                        //    if (itemRow["NhanDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Nhận";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["YeuCauCat"].ToString() != "")
                        //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "YC Cắt";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["NhanNK_MaCN"].ToString() != "")
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
                        //    else
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
                        //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
                        //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
                        //    if (itemRow["CatNK_MaCN"].ToString() != "")
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
                        //    else
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
                        //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
                        //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
                        //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

                        //    table.Rows.Add(Row);
                        //}
                        //return table;
                        return Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                        return null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCatChuyenDMBySoPhieu(decimal SoPhieu)
        {
            //string a = "";
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                                where itemLSCT.SoPhieu != null && itemLSCT.SoPhieu == SoPhieu
                                //where itemLSCT.MaLSCT == 126114
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    In = false,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    //SoPhieuDCBD = itemDCBD.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    itemLSCT.CatDM,
                                    itemLSCT.SoNKCat,
                                    itemLSCT.NhanNK_MaCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    itemLSCT.NhanDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.SoNKNhan,
                                    itemLSCT.CatNK_MaCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaDon,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CreateBy,
                                };
                    if (query.Count() > 0)
                    {
                        //DataTable table = new DataTable();
                        //table.Columns.Add("In", typeof(bool));
                        //table.Columns.Add("MaLSCT", typeof(string));
                        //table.Columns.Add("SoPhieu", typeof(string));
                        //table.Columns.Add("SoPhieuDCBD", typeof(string));
                        //table.Columns.Add("CreateDate", typeof(string));
                        //table.Columns.Add("MaCT", typeof(string));
                        //table.Columns.Add("CatNhan", typeof(string));
                        //table.Columns.Add("SoNK", typeof(string));
                        //table.Columns.Add("NhanNK_MaCN", typeof(string));
                        //table.Columns.Add("NhanNK_DanhBo", typeof(string));
                        //table.Columns.Add("NhanNK_HoTen", typeof(string));
                        //table.Columns.Add("NhanNK_DiaChi", typeof(string));
                        //table.Columns.Add("CatNK_MaCN", typeof(string));
                        //table.Columns.Add("CatNK_DanhBo", typeof(string));
                        //table.Columns.Add("CatNK_HoTen", typeof(string));
                        //table.Columns.Add("CatNK_DiaChi", typeof(string));
                        //table.Columns.Add("PhieuDuocKy", typeof(bool));

                        //DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                        //CChiNhanh _cChiNhanh = new CChiNhanh();
                        //foreach (DataRow itemRow in table2.Rows)
                        //{
                        //    //a = itemRow["MaLSCT"].ToString();
                        //    DataRow Row = table.NewRow();
                        //    Row["In"] = false;
                        //    Row["MaLSCT"] = itemRow["MaLSCT"];
                        //    Row["SoPhieu"] = itemRow["SoPhieu"];
                        //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                        //        if (db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
                        //            Row["SoPhieuDCBD"] = db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
                        //        else
                        //            Row["SoPhieuDCBD"] = "";
                        //    else
                        //        Row["SoPhieuDCBD"] = "";
                        //    Row["CreateDate"] = itemRow["CreateDate"];
                        //    Row["MaCT"] = itemRow["MaCT"];
                        //    if (itemRow["CatDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Cắt";
                        //            Row["SoNK"] = itemRow["SoNKCat"];
                        //        }
                        //    if (itemRow["NhanDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Nhận";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["YeuCauCat"].ToString() != "")
                        //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "YC Cắt";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["NhanNK_MaCN"].ToString() != "")
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
                        //    else
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
                        //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
                        //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
                        //    if (itemRow["CatNK_MaCN"].ToString() != "")
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
                        //    else
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
                        //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
                        //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
                        //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

                        //    table.Rows.Add(Row);
                        //}
                        //return table;
                        return Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                        return null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCatChuyenDMBySoPhieus(decimal TuSoPhieu, decimal DenSoPhieu)
        {
            //string a = "";
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                                where itemLSCT.SoPhieu != null &&
                                itemLSCT.SoPhieu.ToString().Substring(itemLSCT.SoPhieu.ToString().Length - 2, 2) == TuSoPhieu.ToString().Substring(TuSoPhieu.ToString().Length - 2, 2)
                                && itemLSCT.SoPhieu.ToString().Substring(itemLSCT.SoPhieu.ToString().Length - 2, 2) == DenSoPhieu.ToString().Substring(DenSoPhieu.ToString().Length - 2, 2)
                                && itemLSCT.SoPhieu >= TuSoPhieu && itemLSCT.SoPhieu <= DenSoPhieu
                                //where itemLSCT.MaLSCT == 126114
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    In = false,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    //SoPhieuDCBD = itemDCBD.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    itemLSCT.CatDM,
                                    itemLSCT.SoNKCat,
                                    itemLSCT.NhanNK_MaCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    itemLSCT.NhanDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.SoNKNhan,
                                    itemLSCT.CatNK_MaCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaDon,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CreateBy,
                                };
                    if (query.Count() > 0)
                    {
                        //DataTable table = new DataTable();
                        //table.Columns.Add("In", typeof(bool));
                        //table.Columns.Add("MaLSCT", typeof(string));
                        //table.Columns.Add("SoPhieu", typeof(string));
                        //table.Columns.Add("SoPhieuDCBD", typeof(string));
                        //table.Columns.Add("CreateDate", typeof(string));
                        //table.Columns.Add("MaCT", typeof(string));
                        //table.Columns.Add("CatNhan", typeof(string));
                        //table.Columns.Add("SoNK", typeof(string));
                        //table.Columns.Add("NhanNK_MaCN", typeof(string));
                        //table.Columns.Add("NhanNK_DanhBo", typeof(string));
                        //table.Columns.Add("NhanNK_HoTen", typeof(string));
                        //table.Columns.Add("NhanNK_DiaChi", typeof(string));
                        //table.Columns.Add("CatNK_MaCN", typeof(string));
                        //table.Columns.Add("CatNK_DanhBo", typeof(string));
                        //table.Columns.Add("CatNK_HoTen", typeof(string));
                        //table.Columns.Add("CatNK_DiaChi", typeof(string));
                        //table.Columns.Add("PhieuDuocKy", typeof(bool));

                        //DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                        //CChiNhanh _cChiNhanh = new CChiNhanh();
                        //foreach (DataRow itemRow in table2.Rows)
                        //{
                        //    //a = itemRow["MaLSCT"].ToString();
                        //    DataRow Row = table.NewRow();
                        //    Row["In"] = false;
                        //    Row["MaLSCT"] = itemRow["MaLSCT"];
                        //    Row["SoPhieu"] = itemRow["SoPhieu"];
                        //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                        //        if (db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
                        //            Row["SoPhieuDCBD"] = db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
                        //        else
                        //            Row["SoPhieuDCBD"] = "";
                        //    else
                        //        Row["SoPhieuDCBD"] = "";
                        //    Row["CreateDate"] = itemRow["CreateDate"];
                        //    Row["MaCT"] = itemRow["MaCT"];
                        //    if (itemRow["CatDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Cắt";
                        //            Row["SoNK"] = itemRow["SoNKCat"];
                        //        }
                        //    if (itemRow["NhanDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Nhận";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["YeuCauCat"].ToString() != "")
                        //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "YC Cắt";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["NhanNK_MaCN"].ToString() != "")
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
                        //    else
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
                        //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
                        //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
                        //    if (itemRow["CatNK_MaCN"].ToString() != "")
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
                        //    else
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
                        //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
                        //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
                        //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

                        //    table.Rows.Add(Row);
                        //}
                        //return table;
                        return Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                        return null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCatChuyenDMByDanhBo(string DanhBo)
        {
            //string a = "";
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                                where itemLSCT.SoPhieu != null && itemLSCT.DanhBo == DanhBo
                                //where itemLSCT.MaLSCT == 126114
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    In = false,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    //SoPhieuDCBD = itemDCBD.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    itemLSCT.CatDM,
                                    itemLSCT.SoNKCat,
                                    itemLSCT.NhanNK_MaCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    itemLSCT.NhanDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.SoNKNhan,
                                    itemLSCT.CatNK_MaCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaDon,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CreateBy,
                                };
                    if (query.Count() > 0)
                    {
                        //DataTable table = new DataTable();
                        //table.Columns.Add("In", typeof(bool));
                        //table.Columns.Add("MaLSCT", typeof(string));
                        //table.Columns.Add("SoPhieu", typeof(string));
                        //table.Columns.Add("SoPhieuDCBD", typeof(string));
                        //table.Columns.Add("CreateDate", typeof(string));
                        //table.Columns.Add("MaCT", typeof(string));
                        //table.Columns.Add("CatNhan", typeof(string));
                        //table.Columns.Add("SoNK", typeof(string));
                        //table.Columns.Add("NhanNK_MaCN", typeof(string));
                        //table.Columns.Add("NhanNK_DanhBo", typeof(string));
                        //table.Columns.Add("NhanNK_HoTen", typeof(string));
                        //table.Columns.Add("NhanNK_DiaChi", typeof(string));
                        //table.Columns.Add("CatNK_MaCN", typeof(string));
                        //table.Columns.Add("CatNK_DanhBo", typeof(string));
                        //table.Columns.Add("CatNK_HoTen", typeof(string));
                        //table.Columns.Add("CatNK_DiaChi", typeof(string));
                        //table.Columns.Add("PhieuDuocKy", typeof(bool));

                        //DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                        //CChiNhanh _cChiNhanh = new CChiNhanh();
                        //foreach (DataRow itemRow in table2.Rows)
                        //{
                        //    //a = itemRow["MaLSCT"].ToString();
                        //    DataRow Row = table.NewRow();
                        //    Row["In"] = false;
                        //    Row["MaLSCT"] = itemRow["MaLSCT"];
                        //    Row["SoPhieu"] = itemRow["SoPhieu"];
                        //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                        //        if (db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
                        //            Row["SoPhieuDCBD"] = db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
                        //        else
                        //            Row["SoPhieuDCBD"] = "";
                        //    else
                        //        Row["SoPhieuDCBD"] = "";
                        //    Row["CreateDate"] = itemRow["CreateDate"];
                        //    Row["MaCT"] = itemRow["MaCT"];
                        //    if (itemRow["CatDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Cắt";
                        //            Row["SoNK"] = itemRow["SoNKCat"];
                        //        }
                        //    if (itemRow["NhanDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Nhận";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["YeuCauCat"].ToString() != "")
                        //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "YC Cắt";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["NhanNK_MaCN"].ToString() != "")
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
                        //    else
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
                        //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
                        //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
                        //    if (itemRow["CatNK_MaCN"].ToString() != "")
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
                        //    else
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
                        //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
                        //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
                        //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

                        //    table.Rows.Add(Row);
                        //}
                        //return table;
                        return Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                        return null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCatChuyenDMByDate(DateTime TuNgay)
        {
            //string a = "";
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                                where itemLSCT.SoPhieu != null && itemLSCT.CreateDate.Value.Date == TuNgay.Date
                                //where itemLSCT.MaLSCT == 126114
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    In = false,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    //SoPhieuDCBD = itemDCBD.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    itemLSCT.CatDM,
                                    itemLSCT.SoNKCat,
                                    itemLSCT.NhanNK_MaCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    itemLSCT.NhanDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.SoNKNhan,
                                    itemLSCT.CatNK_MaCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaDon,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CreateBy,
                                };
                    if (query.Count() > 0)
                    {
                        //DataTable table = new DataTable();
                        //table.Columns.Add("In", typeof(bool));
                        //table.Columns.Add("MaLSCT", typeof(string));
                        //table.Columns.Add("SoPhieu", typeof(string));
                        //table.Columns.Add("SoPhieuDCBD", typeof(string));
                        //table.Columns.Add("CreateDate", typeof(string));
                        //table.Columns.Add("MaCT", typeof(string));
                        //table.Columns.Add("CatNhan", typeof(string));
                        //table.Columns.Add("SoNK", typeof(string));
                        //table.Columns.Add("NhanNK_MaCN", typeof(string));
                        //table.Columns.Add("NhanNK_DanhBo", typeof(string));
                        //table.Columns.Add("NhanNK_HoTen", typeof(string));
                        //table.Columns.Add("NhanNK_DiaChi", typeof(string));
                        //table.Columns.Add("CatNK_MaCN", typeof(string));
                        //table.Columns.Add("CatNK_DanhBo", typeof(string));
                        //table.Columns.Add("CatNK_HoTen", typeof(string));
                        //table.Columns.Add("CatNK_DiaChi", typeof(string));
                        //table.Columns.Add("PhieuDuocKy", typeof(bool));

                        //DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                        //CChiNhanh _cChiNhanh = new CChiNhanh();
                        //foreach (DataRow itemRow in table2.Rows)
                        //{
                        //    //a = itemRow["MaLSCT"].ToString();
                        //    DataRow Row = table.NewRow();
                        //    Row["In"] = false;
                        //    Row["MaLSCT"] = itemRow["MaLSCT"];
                        //    Row["SoPhieu"] = itemRow["SoPhieu"];
                        //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                        //        if (db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
                        //            Row["SoPhieuDCBD"] = db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
                        //        else
                        //            Row["SoPhieuDCBD"] = "";
                        //    else
                        //        Row["SoPhieuDCBD"] = "";
                        //    Row["CreateDate"] = itemRow["CreateDate"];
                        //    Row["MaCT"] = itemRow["MaCT"];
                        //    if (itemRow["CatDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Cắt";
                        //            Row["SoNK"] = itemRow["SoNKCat"];
                        //        }
                        //    if (itemRow["NhanDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Nhận";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["YeuCauCat"].ToString() != "")
                        //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "YC Cắt";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["NhanNK_MaCN"].ToString() != "")
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
                        //    else
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
                        //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
                        //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
                        //    if (itemRow["CatNK_MaCN"].ToString() != "")
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
                        //    else
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
                        //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
                        //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
                        //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

                        //    table.Rows.Add(Row);
                        //}
                        //return table;
                        return Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                        return null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCatChuyenDMByDates(DateTime TuNgay, DateTime DenNgay)
        {
            //string a = "";
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                                where itemLSCT.SoPhieu != null && itemLSCT.CreateDate.Value.Date >= TuNgay.Date && itemLSCT.CreateDate.Value.Date <= DenNgay.Date
                                //where itemLSCT.MaLSCT == 126114
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    In = false,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    //SoPhieuDCBD = itemDCBD.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    itemLSCT.CatDM,
                                    itemLSCT.SoNKCat,
                                    itemLSCT.NhanNK_MaCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    itemLSCT.NhanDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.SoNKNhan,
                                    itemLSCT.CatNK_MaCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaDon,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CreateBy,
                                };
                    if (query.Count() > 0)
                    {
                        //DataTable table = new DataTable();
                        //table.Columns.Add("In", typeof(bool));
                        //table.Columns.Add("MaLSCT", typeof(string));
                        //table.Columns.Add("SoPhieu", typeof(string));
                        //table.Columns.Add("SoPhieuDCBD", typeof(string));
                        //table.Columns.Add("CreateDate", typeof(string));
                        //table.Columns.Add("MaCT", typeof(string));
                        //table.Columns.Add("CatNhan", typeof(string));
                        //table.Columns.Add("SoNK", typeof(string));
                        //table.Columns.Add("NhanNK_MaCN", typeof(string));
                        //table.Columns.Add("NhanNK_DanhBo", typeof(string));
                        //table.Columns.Add("NhanNK_HoTen", typeof(string));
                        //table.Columns.Add("NhanNK_DiaChi", typeof(string));
                        //table.Columns.Add("CatNK_MaCN", typeof(string));
                        //table.Columns.Add("CatNK_DanhBo", typeof(string));
                        //table.Columns.Add("CatNK_HoTen", typeof(string));
                        //table.Columns.Add("CatNK_DiaChi", typeof(string));
                        //table.Columns.Add("PhieuDuocKy", typeof(bool));

                        //DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                        //CChiNhanh _cChiNhanh = new CChiNhanh();
                        //foreach (DataRow itemRow in table2.Rows)
                        //{
                        //    //a = itemRow["MaLSCT"].ToString();
                        //    DataRow Row = table.NewRow();
                        //    Row["In"] = false;
                        //    Row["MaLSCT"] = itemRow["MaLSCT"];
                        //    Row["SoPhieu"] = itemRow["SoPhieu"];
                        //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                        //        if (db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
                        //            Row["SoPhieuDCBD"] = db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
                        //        else
                        //            Row["SoPhieuDCBD"] = "";
                        //    else
                        //        Row["SoPhieuDCBD"] = "";
                        //    Row["CreateDate"] = itemRow["CreateDate"];
                        //    Row["MaCT"] = itemRow["MaCT"];
                        //    if (itemRow["CatDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Cắt";
                        //            Row["SoNK"] = itemRow["SoNKCat"];
                        //        }
                        //    if (itemRow["NhanDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Nhận";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["YeuCauCat"].ToString() != "")
                        //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "YC Cắt";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["NhanNK_MaCN"].ToString() != "")
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
                        //    else
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
                        //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
                        //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
                        //    if (itemRow["CatNK_MaCN"].ToString() != "")
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
                        //    else
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
                        //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
                        //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
                        //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

                        //    table.Rows.Add(Row);
                        //}
                        //return table;
                        return Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                        return null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCatChuyenDMByMaDon(int CreateBy, decimal MaDon)
        {
            //string a = "";
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                                where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null && (itemLSCT.MaDon == MaDon || itemLSCT.MaDonTXL == MaDon)
                                //where itemLSCT.MaLSCT == 126114
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    In = false,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    //SoPhieuDCBD = itemDCBD.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    itemLSCT.CatDM,
                                    itemLSCT.SoNKCat,
                                    itemLSCT.NhanNK_MaCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    itemLSCT.NhanDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.SoNKNhan,
                                    itemLSCT.CatNK_MaCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaDon,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CreateBy,
                                };
                    if (query.Count() > 0)
                    {
                        //DataTable table = new DataTable();
                        //table.Columns.Add("In", typeof(bool));
                        //table.Columns.Add("MaLSCT", typeof(string));
                        //table.Columns.Add("SoPhieu", typeof(string));
                        //table.Columns.Add("SoPhieuDCBD", typeof(string));
                        //table.Columns.Add("CreateDate", typeof(string));
                        //table.Columns.Add("MaCT", typeof(string));
                        //table.Columns.Add("CatNhan", typeof(string));
                        //table.Columns.Add("SoNK", typeof(string));
                        //table.Columns.Add("NhanNK_MaCN", typeof(string));
                        //table.Columns.Add("NhanNK_DanhBo", typeof(string));
                        //table.Columns.Add("NhanNK_HoTen", typeof(string));
                        //table.Columns.Add("NhanNK_DiaChi", typeof(string));
                        //table.Columns.Add("CatNK_MaCN", typeof(string));
                        //table.Columns.Add("CatNK_DanhBo", typeof(string));
                        //table.Columns.Add("CatNK_HoTen", typeof(string));
                        //table.Columns.Add("CatNK_DiaChi", typeof(string));
                        //table.Columns.Add("PhieuDuocKy", typeof(bool));

                        //DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                        //CChiNhanh _cChiNhanh = new CChiNhanh();
                        //foreach (DataRow itemRow in table2.Rows)
                        //{
                        //    //a = itemRow["MaLSCT"].ToString();
                        //    DataRow Row = table.NewRow();
                        //    Row["In"] = false;
                        //    Row["MaLSCT"] = itemRow["MaLSCT"];
                        //    Row["SoPhieu"] = itemRow["SoPhieu"];
                        //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                        //        if (db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
                        //            Row["SoPhieuDCBD"] = db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
                        //        else
                        //            Row["SoPhieuDCBD"] = "";
                        //    else
                        //        Row["SoPhieuDCBD"] = "";
                        //    Row["CreateDate"] = itemRow["CreateDate"];
                        //    Row["MaCT"] = itemRow["MaCT"];
                        //    if (itemRow["CatDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Cắt";
                        //            Row["SoNK"] = itemRow["SoNKCat"];
                        //        }
                        //    if (itemRow["NhanDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Nhận";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["YeuCauCat"].ToString() != "")
                        //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "YC Cắt";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["NhanNK_MaCN"].ToString() != "")
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
                        //    else
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
                        //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
                        //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
                        //    if (itemRow["CatNK_MaCN"].ToString() != "")
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
                        //    else
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
                        //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
                        //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
                        //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

                        //    table.Rows.Add(Row);
                        //}
                        //return table;
                        return Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                        return null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCatChuyenDMByMaDons(int CreateBy, decimal TuMaDon, decimal DenMaDon)
        {
            //string a = "";
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                                where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null &&
                                ((itemLSCT.MaDon.Value.ToString().Substring(itemLSCT.MaDon.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemLSCT.MaDon.Value.ToString().Substring(itemLSCT.MaDon.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                                && (itemLSCT.MaDon >= TuMaDon && itemLSCT.MaDon <= DenMaDon))
                                || ((itemLSCT.MaDonTXL.Value.ToString().Substring(itemLSCT.MaDonTXL.Value.ToString().Length - 2, 2) == TuMaDon.ToString().Substring(TuMaDon.ToString().Length - 2, 2) && itemLSCT.MaDonTXL.Value.ToString().Substring(itemLSCT.MaDonTXL.Value.ToString().Length - 2, 2) == DenMaDon.ToString().Substring(DenMaDon.ToString().Length - 2, 2))
                                && (itemLSCT.MaDonTXL >= TuMaDon && itemLSCT.MaDonTXL <= DenMaDon))
                                //where itemLSCT.MaLSCT == 126114
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    In = false,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    //SoPhieuDCBD = itemDCBD.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    itemLSCT.CatDM,
                                    itemLSCT.SoNKCat,
                                    itemLSCT.NhanNK_MaCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    itemLSCT.NhanDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.SoNKNhan,
                                    itemLSCT.CatNK_MaCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaDon,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CreateBy,
                                };
                    if (query.Count() > 0)
                    {
                        //DataTable table = new DataTable();
                        //table.Columns.Add("In", typeof(bool));
                        //table.Columns.Add("MaLSCT", typeof(string));
                        //table.Columns.Add("SoPhieu", typeof(string));
                        //table.Columns.Add("SoPhieuDCBD", typeof(string));
                        //table.Columns.Add("CreateDate", typeof(string));
                        //table.Columns.Add("MaCT", typeof(string));
                        //table.Columns.Add("CatNhan", typeof(string));
                        //table.Columns.Add("SoNK", typeof(string));
                        //table.Columns.Add("NhanNK_MaCN", typeof(string));
                        //table.Columns.Add("NhanNK_DanhBo", typeof(string));
                        //table.Columns.Add("NhanNK_HoTen", typeof(string));
                        //table.Columns.Add("NhanNK_DiaChi", typeof(string));
                        //table.Columns.Add("CatNK_MaCN", typeof(string));
                        //table.Columns.Add("CatNK_DanhBo", typeof(string));
                        //table.Columns.Add("CatNK_HoTen", typeof(string));
                        //table.Columns.Add("CatNK_DiaChi", typeof(string));
                        //table.Columns.Add("PhieuDuocKy", typeof(bool));

                        //DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                        //CChiNhanh _cChiNhanh = new CChiNhanh();
                        //foreach (DataRow itemRow in table2.Rows)
                        //{
                        //    //a = itemRow["MaLSCT"].ToString();
                        //    DataRow Row = table.NewRow();
                        //    Row["In"] = false;
                        //    Row["MaLSCT"] = itemRow["MaLSCT"];
                        //    Row["SoPhieu"] = itemRow["SoPhieu"];
                        //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                        //        if (db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
                        //            Row["SoPhieuDCBD"] = db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
                        //        else
                        //            Row["SoPhieuDCBD"] = "";
                        //    else
                        //        Row["SoPhieuDCBD"] = "";
                        //    Row["CreateDate"] = itemRow["CreateDate"];
                        //    Row["MaCT"] = itemRow["MaCT"];
                        //    if (itemRow["CatDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Cắt";
                        //            Row["SoNK"] = itemRow["SoNKCat"];
                        //        }
                        //    if (itemRow["NhanDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Nhận";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["YeuCauCat"].ToString() != "")
                        //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "YC Cắt";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["NhanNK_MaCN"].ToString() != "")
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
                        //    else
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
                        //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
                        //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
                        //    if (itemRow["CatNK_MaCN"].ToString() != "")
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
                        //    else
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
                        //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
                        //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
                        //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

                        //    table.Rows.Add(Row);
                        //}
                        //return table;
                        return Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                        return null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCatChuyenDMBySoPhieu(int CreateBy, decimal SoPhieu)
        {
            //string a = "";
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                                where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null && itemLSCT.SoPhieu == SoPhieu
                                //where itemLSCT.MaLSCT == 126114
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    In = false,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    //SoPhieuDCBD = itemDCBD.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    itemLSCT.CatDM,
                                    itemLSCT.SoNKCat,
                                    itemLSCT.NhanNK_MaCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    itemLSCT.NhanDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.SoNKNhan,
                                    itemLSCT.CatNK_MaCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaDon,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CreateBy,
                                };
                    if (query.Count() > 0)
                    {
                        //DataTable table = new DataTable();
                        //table.Columns.Add("In", typeof(bool));
                        //table.Columns.Add("MaLSCT", typeof(string));
                        //table.Columns.Add("SoPhieu", typeof(string));
                        //table.Columns.Add("SoPhieuDCBD", typeof(string));
                        //table.Columns.Add("CreateDate", typeof(string));
                        //table.Columns.Add("MaCT", typeof(string));
                        //table.Columns.Add("CatNhan", typeof(string));
                        //table.Columns.Add("SoNK", typeof(string));
                        //table.Columns.Add("NhanNK_MaCN", typeof(string));
                        //table.Columns.Add("NhanNK_DanhBo", typeof(string));
                        //table.Columns.Add("NhanNK_HoTen", typeof(string));
                        //table.Columns.Add("NhanNK_DiaChi", typeof(string));
                        //table.Columns.Add("CatNK_MaCN", typeof(string));
                        //table.Columns.Add("CatNK_DanhBo", typeof(string));
                        //table.Columns.Add("CatNK_HoTen", typeof(string));
                        //table.Columns.Add("CatNK_DiaChi", typeof(string));
                        //table.Columns.Add("PhieuDuocKy", typeof(bool));

                        //DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                        //CChiNhanh _cChiNhanh = new CChiNhanh();
                        //foreach (DataRow itemRow in table2.Rows)
                        //{
                        //    //a = itemRow["MaLSCT"].ToString();
                        //    DataRow Row = table.NewRow();
                        //    Row["In"] = false;
                        //    Row["MaLSCT"] = itemRow["MaLSCT"];
                        //    Row["SoPhieu"] = itemRow["SoPhieu"];
                        //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                        //        if (db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
                        //            Row["SoPhieuDCBD"] = db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
                        //        else
                        //            Row["SoPhieuDCBD"] = "";
                        //    else
                        //        Row["SoPhieuDCBD"] = "";
                        //    Row["CreateDate"] = itemRow["CreateDate"];
                        //    Row["MaCT"] = itemRow["MaCT"];
                        //    if (itemRow["CatDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Cắt";
                        //            Row["SoNK"] = itemRow["SoNKCat"];
                        //        }
                        //    if (itemRow["NhanDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Nhận";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["YeuCauCat"].ToString() != "")
                        //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "YC Cắt";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["NhanNK_MaCN"].ToString() != "")
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
                        //    else
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
                        //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
                        //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
                        //    if (itemRow["CatNK_MaCN"].ToString() != "")
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
                        //    else
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
                        //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
                        //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
                        //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

                        //    table.Rows.Add(Row);
                        //}
                        //return table;
                        return Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                        return null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCatChuyenDMBySoPhieus(int CreateBy, decimal TuSoPhieu, decimal DenSoPhieu)
        {
            //string a = "";
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                                where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null &&
                                itemLSCT.SoPhieu.ToString().Substring(itemLSCT.SoPhieu.ToString().Length - 2, 2) == TuSoPhieu.ToString().Substring(TuSoPhieu.ToString().Length - 2, 2)
                                && itemLSCT.SoPhieu.ToString().Substring(itemLSCT.SoPhieu.ToString().Length - 2, 2) == DenSoPhieu.ToString().Substring(DenSoPhieu.ToString().Length - 2, 2)
                                && itemLSCT.SoPhieu >= TuSoPhieu && itemLSCT.SoPhieu <= DenSoPhieu
                                //where itemLSCT.MaLSCT == 126114
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    In = false,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    //SoPhieuDCBD = itemDCBD.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    itemLSCT.CatDM,
                                    itemLSCT.SoNKCat,
                                    itemLSCT.NhanNK_MaCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    itemLSCT.NhanDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.SoNKNhan,
                                    itemLSCT.CatNK_MaCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaDon,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CreateBy,
                                };
                    if (query.Count() > 0)
                    {
                        //DataTable table = new DataTable();
                        //table.Columns.Add("In", typeof(bool));
                        //table.Columns.Add("MaLSCT", typeof(string));
                        //table.Columns.Add("SoPhieu", typeof(string));
                        //table.Columns.Add("SoPhieuDCBD", typeof(string));
                        //table.Columns.Add("CreateDate", typeof(string));
                        //table.Columns.Add("MaCT", typeof(string));
                        //table.Columns.Add("CatNhan", typeof(string));
                        //table.Columns.Add("SoNK", typeof(string));
                        //table.Columns.Add("NhanNK_MaCN", typeof(string));
                        //table.Columns.Add("NhanNK_DanhBo", typeof(string));
                        //table.Columns.Add("NhanNK_HoTen", typeof(string));
                        //table.Columns.Add("NhanNK_DiaChi", typeof(string));
                        //table.Columns.Add("CatNK_MaCN", typeof(string));
                        //table.Columns.Add("CatNK_DanhBo", typeof(string));
                        //table.Columns.Add("CatNK_HoTen", typeof(string));
                        //table.Columns.Add("CatNK_DiaChi", typeof(string));
                        //table.Columns.Add("PhieuDuocKy", typeof(bool));

                        //DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                        //CChiNhanh _cChiNhanh = new CChiNhanh();
                        //foreach (DataRow itemRow in table2.Rows)
                        //{
                        //    //a = itemRow["MaLSCT"].ToString();
                        //    DataRow Row = table.NewRow();
                        //    Row["In"] = false;
                        //    Row["MaLSCT"] = itemRow["MaLSCT"];
                        //    Row["SoPhieu"] = itemRow["SoPhieu"];
                        //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                        //        if (db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
                        //            Row["SoPhieuDCBD"] = db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
                        //        else
                        //            Row["SoPhieuDCBD"] = "";
                        //    else
                        //        Row["SoPhieuDCBD"] = "";
                        //    Row["CreateDate"] = itemRow["CreateDate"];
                        //    Row["MaCT"] = itemRow["MaCT"];
                        //    if (itemRow["CatDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Cắt";
                        //            Row["SoNK"] = itemRow["SoNKCat"];
                        //        }
                        //    if (itemRow["NhanDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Nhận";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["YeuCauCat"].ToString() != "")
                        //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "YC Cắt";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["NhanNK_MaCN"].ToString() != "")
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
                        //    else
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
                        //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
                        //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
                        //    if (itemRow["CatNK_MaCN"].ToString() != "")
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
                        //    else
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
                        //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
                        //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
                        //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

                        //    table.Rows.Add(Row);
                        //}
                        //return table;
                        return Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                        return null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCatChuyenDMByDanhBo(int CreateBy, string DanhBo)
        {
            //string a = "";
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                                where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null && itemLSCT.DanhBo == DanhBo
                                //where itemLSCT.MaLSCT == 126114
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    In = false,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    //SoPhieuDCBD = itemDCBD.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    itemLSCT.CatDM,
                                    itemLSCT.SoNKCat,
                                    itemLSCT.NhanNK_MaCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    itemLSCT.NhanDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.SoNKNhan,
                                    itemLSCT.CatNK_MaCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaDon,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CreateBy,
                                };
                    if (query.Count() > 0)
                    {
                        //DataTable table = new DataTable();
                        //table.Columns.Add("In", typeof(bool));
                        //table.Columns.Add("MaLSCT", typeof(string));
                        //table.Columns.Add("SoPhieu", typeof(string));
                        //table.Columns.Add("SoPhieuDCBD", typeof(string));
                        //table.Columns.Add("CreateDate", typeof(string));
                        //table.Columns.Add("MaCT", typeof(string));
                        //table.Columns.Add("CatNhan", typeof(string));
                        //table.Columns.Add("SoNK", typeof(string));
                        //table.Columns.Add("NhanNK_MaCN", typeof(string));
                        //table.Columns.Add("NhanNK_DanhBo", typeof(string));
                        //table.Columns.Add("NhanNK_HoTen", typeof(string));
                        //table.Columns.Add("NhanNK_DiaChi", typeof(string));
                        //table.Columns.Add("CatNK_MaCN", typeof(string));
                        //table.Columns.Add("CatNK_DanhBo", typeof(string));
                        //table.Columns.Add("CatNK_HoTen", typeof(string));
                        //table.Columns.Add("CatNK_DiaChi", typeof(string));
                        //table.Columns.Add("PhieuDuocKy", typeof(bool));

                        //DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                        //CChiNhanh _cChiNhanh = new CChiNhanh();
                        //foreach (DataRow itemRow in table2.Rows)
                        //{
                        //    //a = itemRow["MaLSCT"].ToString();
                        //    DataRow Row = table.NewRow();
                        //    Row["In"] = false;
                        //    Row["MaLSCT"] = itemRow["MaLSCT"];
                        //    Row["SoPhieu"] = itemRow["SoPhieu"];
                        //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                        //        if (db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
                        //            Row["SoPhieuDCBD"] = db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
                        //        else
                        //            Row["SoPhieuDCBD"] = "";
                        //    else
                        //        Row["SoPhieuDCBD"] = "";
                        //    Row["CreateDate"] = itemRow["CreateDate"];
                        //    Row["MaCT"] = itemRow["MaCT"];
                        //    if (itemRow["CatDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Cắt";
                        //            Row["SoNK"] = itemRow["SoNKCat"];
                        //        }
                        //    if (itemRow["NhanDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Nhận";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["YeuCauCat"].ToString() != "")
                        //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "YC Cắt";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["NhanNK_MaCN"].ToString() != "")
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
                        //    else
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
                        //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
                        //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
                        //    if (itemRow["CatNK_MaCN"].ToString() != "")
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
                        //    else
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
                        //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
                        //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
                        //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

                        //    table.Rows.Add(Row);
                        //}
                        //return table;
                        return Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                        return null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCatChuyenDMByDate(int CreateBy, DateTime TuNgay)
        {
            //string a = "";
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                                where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null && itemLSCT.CreateDate.Value.Date == TuNgay.Date
                                //where itemLSCT.MaLSCT == 126114
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    In = false,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    //SoPhieuDCBD = itemDCBD.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    itemLSCT.CatDM,
                                    itemLSCT.SoNKCat,
                                    itemLSCT.NhanNK_MaCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    itemLSCT.NhanDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.SoNKNhan,
                                    itemLSCT.CatNK_MaCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaDon,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CreateBy,
                                };
                    if (query.Count() > 0)
                    {
                        //DataTable table = new DataTable();
                        //table.Columns.Add("In", typeof(bool));
                        //table.Columns.Add("MaLSCT", typeof(string));
                        //table.Columns.Add("SoPhieu", typeof(string));
                        //table.Columns.Add("SoPhieuDCBD", typeof(string));
                        //table.Columns.Add("CreateDate", typeof(string));
                        //table.Columns.Add("MaCT", typeof(string));
                        //table.Columns.Add("CatNhan", typeof(string));
                        //table.Columns.Add("SoNK", typeof(string));
                        //table.Columns.Add("NhanNK_MaCN", typeof(string));
                        //table.Columns.Add("NhanNK_DanhBo", typeof(string));
                        //table.Columns.Add("NhanNK_HoTen", typeof(string));
                        //table.Columns.Add("NhanNK_DiaChi", typeof(string));
                        //table.Columns.Add("CatNK_MaCN", typeof(string));
                        //table.Columns.Add("CatNK_DanhBo", typeof(string));
                        //table.Columns.Add("CatNK_HoTen", typeof(string));
                        //table.Columns.Add("CatNK_DiaChi", typeof(string));
                        //table.Columns.Add("PhieuDuocKy", typeof(bool));

                        //DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                        //CChiNhanh _cChiNhanh = new CChiNhanh();
                        //foreach (DataRow itemRow in table2.Rows)
                        //{
                        //    //a = itemRow["MaLSCT"].ToString();
                        //    DataRow Row = table.NewRow();
                        //    Row["In"] = false;
                        //    Row["MaLSCT"] = itemRow["MaLSCT"];
                        //    Row["SoPhieu"] = itemRow["SoPhieu"];
                        //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                        //        if (db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
                        //            Row["SoPhieuDCBD"] = db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
                        //        else
                        //            Row["SoPhieuDCBD"] = "";
                        //    else
                        //        Row["SoPhieuDCBD"] = "";
                        //    Row["CreateDate"] = itemRow["CreateDate"];
                        //    Row["MaCT"] = itemRow["MaCT"];
                        //    if (itemRow["CatDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Cắt";
                        //            Row["SoNK"] = itemRow["SoNKCat"];
                        //        }
                        //    if (itemRow["NhanDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Nhận";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["YeuCauCat"].ToString() != "")
                        //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "YC Cắt";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["NhanNK_MaCN"].ToString() != "")
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
                        //    else
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
                        //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
                        //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
                        //    if (itemRow["CatNK_MaCN"].ToString() != "")
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
                        //    else
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
                        //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
                        //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
                        //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

                        //    table.Rows.Add(Row);
                        //}
                        //return table;
                        return Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                        return null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCatChuyenDMByDates(int CreateBy, DateTime TuNgay, DateTime DenNgay)
        {
            //string a = "";
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                                where itemLSCT.CreateBy == CreateBy && itemLSCT.SoPhieu != null && itemLSCT.CreateDate.Value.Date >= TuNgay.Date && itemLSCT.CreateDate.Value.Date <= DenNgay.Date
                                //where itemLSCT.MaLSCT == 126114
                                orderby itemLSCT.CreateDate ascending
                                select new
                                {
                                    In = false,
                                    itemLSCT.MaLSCT,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    //SoPhieuDCBD = itemDCBD.CTDCBDs.SingleOrDefault(itemCTDCBD => itemCTDCBD.DanhBo == itemCCDM.DanhBo).MaCTDCBD,
                                    itemLSCT.CreateDate,
                                    itemLSCT.MaCT,
                                    itemLSCT.CatDM,
                                    itemLSCT.SoNKCat,
                                    itemLSCT.NhanNK_MaCN,
                                    itemLSCT.NhanNK_DanhBo,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    itemLSCT.NhanNK_HoTen,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NhanNK_DiaChi,
                                    itemLSCT.NhanDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.SoNKNhan,
                                    itemLSCT.CatNK_MaCN,
                                    itemLSCT.CatNK_DanhBo,
                                    itemLSCT.CatNK_HoTen,
                                    itemLSCT.CatNK_DiaChi,
                                    itemLSCT.PhieuDuocKy,
                                    itemLSCT.MaDon,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CreateBy,
                                };
                    if (query.Count() > 0)
                    {
                        //DataTable table = new DataTable();
                        //table.Columns.Add("In", typeof(bool));
                        //table.Columns.Add("MaLSCT", typeof(string));
                        //table.Columns.Add("SoPhieu", typeof(string));
                        //table.Columns.Add("SoPhieuDCBD", typeof(string));
                        //table.Columns.Add("CreateDate", typeof(string));
                        //table.Columns.Add("MaCT", typeof(string));
                        //table.Columns.Add("CatNhan", typeof(string));
                        //table.Columns.Add("SoNK", typeof(string));
                        //table.Columns.Add("NhanNK_MaCN", typeof(string));
                        //table.Columns.Add("NhanNK_DanhBo", typeof(string));
                        //table.Columns.Add("NhanNK_HoTen", typeof(string));
                        //table.Columns.Add("NhanNK_DiaChi", typeof(string));
                        //table.Columns.Add("CatNK_MaCN", typeof(string));
                        //table.Columns.Add("CatNK_DanhBo", typeof(string));
                        //table.Columns.Add("CatNK_HoTen", typeof(string));
                        //table.Columns.Add("CatNK_DiaChi", typeof(string));
                        //table.Columns.Add("PhieuDuocKy", typeof(bool));

                        //DataTable table2 = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                        //CChiNhanh _cChiNhanh = new CChiNhanh();
                        //foreach (DataRow itemRow in table2.Rows)
                        //{
                        //    //a = itemRow["MaLSCT"].ToString();
                        //    DataRow Row = table.NewRow();
                        //    Row["In"] = false;
                        //    Row["MaLSCT"] = itemRow["MaLSCT"];
                        //    Row["SoPhieu"] = itemRow["SoPhieu"];
                        //    if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                        //        if (db.CTDCBDs.Any(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())))
                        //            Row["SoPhieuDCBD"] = db.CTDCBDs.FirstOrDefault(itemCTDCBD => itemCTDCBD.DCBD.MaDon == decimal.Parse(itemRow["MaDon"].ToString())).MaCTDCBD;
                        //        else
                        //            Row["SoPhieuDCBD"] = "";
                        //    else
                        //        Row["SoPhieuDCBD"] = "";
                        //    Row["CreateDate"] = itemRow["CreateDate"];
                        //    Row["MaCT"] = itemRow["MaCT"];
                        //    if (itemRow["CatDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Cắt";
                        //            Row["SoNK"] = itemRow["SoNKCat"];
                        //        }
                        //    if (itemRow["NhanDM"].ToString() != "")
                        //        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "Nhận";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["YeuCauCat"].ToString() != "")
                        //        if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
                        //        {
                        //            Row["CatNhan"] = "YC Cắt";
                        //            Row["SoNK"] = itemRow["SoNKNhan"];
                        //        }
                        //    if (itemRow["NhanNK_MaCN"].ToString() != "")
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["NhanNK_MaCN"].ToString()));
                        //    else
                        //        Row["NhanNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["NhanNK_DanhBo"] = itemRow["NhanNK_DanhBo"];
                        //    Row["NhanNK_HoTen"] = itemRow["NhanNK_HoTen"];
                        //    Row["NhanNK_DiaChi"] = itemRow["NhanNK_DiaChi"];
                        //    if (itemRow["CatNK_MaCN"].ToString() != "")
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(int.Parse(itemRow["CatNK_MaCN"].ToString()));
                        //    else
                        //        Row["CatNK_MaCN"] = _cChiNhanh.getTenChiNhanhbyID(1);
                        //    Row["CatNK_DanhBo"] = itemRow["CatNK_DanhBo"];
                        //    Row["CatNK_HoTen"] = itemRow["CatNK_HoTen"];
                        //    Row["CatNK_DiaChi"] = itemRow["CatNK_DiaChi"];
                        //    Row["PhieuDuocKy"] = itemRow["PhieuDuocKy"];

                        //    table.Rows.Add(Row);
                        //}
                        //return table;
                        return Function.CLinQToDataTable.LINQToDataTable(query);
                    }
                    else
                        return null;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Phiếu Cắt Chuyển Định Mức trong Ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCatChuyenDM(DateTime TuNgay)
        {
            //string a = "";
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                where itemLSCT.CreateDate.Value.Date == TuNgay.Date && itemLSCT.SoPhieu != null
                                //orderby itemLSCT.SoPhieu ascending
                                select new
                                {
                                    In = false,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CatDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.NhanDM,
                                };
                    return Function.CLinQToDataTable.LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Phiếu Cắt Chuyển Định Mức trong Khoảng Thời Gian
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCatChuyenDM(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                    var query = from itemLSCT in db.LichSuChungTus
                                where itemLSCT.CreateDate.Value.Date >= TuNgay.Date && itemLSCT.CreateDate.Value.Date <= DenNgay.Date && itemLSCT.SoPhieu != null
                                //orderby itemLSCT.SoPhieu ascending
                                select new
                                {
                                    In = false,
                                    itemLSCT.SoPhieu,
                                    Ma = itemLSCT.SoPhieu,
                                    DanhBo = itemLSCT.NhanNK_DanhBo,
                                    HoTen = itemLSCT.NhanNK_HoTen,
                                    itemLSCT.NguoiKy,
                                    itemLSCT.CatDM,
                                    itemLSCT.YeuCauCat,
                                    itemLSCT.NhanDM,
                                };
                    return Function.CLinQToDataTable.LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                return db.LichSuChungTus.SingleOrDefault(itemLSCT => itemLSCT.MaLSCT == MaLSCT);
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

        /// <summary>
        /// Lấy LichSuChungTu dự theo Số Phiếu!=null & Danh Bộ
        /// </summary>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public List<LichSuChungTu> getLichSuChungTubyDanhBo(string DanhBo)
        {
            try
            {
                return db.LichSuChungTus.Where(itemLSCT => itemLSCT.SoPhieu != null && itemLSCT.DanhBo == DanhBo).OrderBy(itemLSCT => itemLSCT.CreateDate).ToList();
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
                return db.LichSuChungTus.Any(itemLSCT => itemLSCT.SoPhieu == SoPhieu);
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
                return db.LichSuChungTus.Any(itemLSCT => itemLSCT.DanhBo == DanhBo && itemLSCT.MaCT == MaCT && itemLSCT.MaDon != null);
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
                return db.LichSuChungTus.FirstOrDefault(itemLSCT => itemLSCT.DanhBo == DanhBo && itemLSCT.MaCT == MaCT && itemLSCT.MaDon != null).MaDon.Value;
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

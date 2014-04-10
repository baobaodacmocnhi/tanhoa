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
        protected static DB_KTKS_DonKHDataContext db = new DB_KTKS_DonKHDataContext();

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
                            join itemLCT in db.LoaiChungTus on itemCT.MaLCT equals itemLCT.MaLCT
                            where itemCTCT.DanhBo == DanhBo
                            select new
                            {
                                itemCTCT.DanhBo,
                                itemCTCT.Lo,
                                itemCTCT.Phong,
                                itemCT.MaLCT,
                                itemLCT.TenLCT,
                                itemCTCT.MaCT,
                                itemCT.DiaChi,
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
                db = new DB_KTKS_DonKHDataContext();
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
                        flagEdited = true;
                    }
                    else
                    {
                        MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                ///Kiểm tra Địa Chỉ có thay đổi hay không
                if (chungtuCN.DiaChi != chungtu.DiaChi)
                {
                    chungtuCN.DiaChi = chungtu.DiaChi;
                    chungtuCN.ModifyDate = DateTime.Now;
                }

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
                        ///Cập nhật bảng CTChungTu
                        ctchungtuCN.SoNKDangKy = ctchungtu.SoNKDangKy;

                        //ctchungtuCN.ThoiHan = ctchungtu.ThoiHan;
                        //if (ctchungtu.ThoiHan != null)
                        //    ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
                        //    ctchungtuCN.NgayHetHan = ctchungtuCN.CreateDate.Value.AddMonths(ctchungtu.ThoiHan.Value);
                        //else
                        //    ctchungtuCN.NgayHetHan = null;

                        ctchungtuCN.ModifyDate = DateTime.Now;
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

    }
}

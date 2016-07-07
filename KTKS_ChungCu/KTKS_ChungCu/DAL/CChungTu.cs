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

        public DataTable LoadDSChungTu_DB_Lo(string DanhBo,string Lo)
        {
            try
            {
                var query = from itemCTCT in db.CTChungTus
                            join itemCT in db.ChungTus on itemCTCT.MaCT equals itemCT.MaCT
                            //join itemLCT in dbDonKH.LoaiChungTus on itemCT.MaLCT equals itemLCT.MaLCT
                            where itemCTCT.DanhBo == DanhBo && itemCTCT.Lo == Lo
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.STT,
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

        public DataTable LoadDSChungTu_DB(string DanhBo)
        {
            try
            {
                var query = from itemCTCT in db.CTChungTus
                            join itemCT in db.ChungTus on itemCTCT.MaCT equals itemCT.MaCT
                            //join itemLCT in dbDonKH.LoaiChungTus on itemCT.MaLCT equals itemLCT.MaLCT
                            where itemCTCT.DanhBo == DanhBo
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.STT,
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

        public DataTable LoadDSChungTu_CT(string MaCT)
        {
            try
            {
                var query = from itemCTCT in db.CTChungTus
                            join itemCT in db.ChungTus on itemCTCT.MaCT equals itemCT.MaCT
                            //join itemLCT in dbDonKH.LoaiChungTus on itemCT.MaLCT equals itemLCT.MaLCT
                            where itemCTCT.MaCT == MaCT
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.STT,
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

        public DataTable LoadDSChungTu_CT(string DanhBo, string MaCT)
        {
            try
            {
                var query = from itemCTCT in db.CTChungTus
                            join itemCT in db.ChungTus on itemCTCT.MaCT equals itemCT.MaCT
                            //join itemLCT in dbDonKH.LoaiChungTus on itemCT.MaLCT equals itemLCT.MaLCT
                            where itemCTCT.DanhBo==DanhBo &&itemCTCT.MaCT == MaCT
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.STT,
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

        public DataTable LoadDSChungTu_HoTen(string HoTen)
        {
            try
            {
                var query = from itemCTCT in db.CTChungTus
                            join itemCT in db.ChungTus on itemCTCT.MaCT equals itemCT.MaCT
                            //join itemLCT in dbDonKH.LoaiChungTus on itemCT.MaLCT equals itemLCT.MaLCT
                            where itemCTCT.ChungTu.HoTen == HoTen
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.STT,
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

        public DataTable LoadDSChungTu_Lo(string Lo)
        {
            try
            {
                var query = from itemCTCT in db.CTChungTus
                            join itemCT in db.ChungTus on itemCTCT.MaCT equals itemCT.MaCT
                            //join itemLCT in dbDonKH.LoaiChungTus on itemCT.MaLCT equals itemLCT.MaLCT
                            where itemCTCT.Lo == Lo
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.STT,
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

        public DataTable LoadDSChungTu_Lo(string DanhBo,string Lo)
        {
            try
            {
                var query = from itemCTCT in db.CTChungTus
                            join itemCT in db.ChungTus on itemCTCT.MaCT equals itemCT.MaCT
                            //join itemLCT in dbDonKH.LoaiChungTus on itemCT.MaLCT equals itemLCT.MaLCT
                            where itemCTCT.DanhBo==DanhBo &&itemCTCT.Lo == Lo
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.STT,
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

        public DataTable LoadDSChungTu_Phong(string Phong)
        {
            try
            {
                var query = from itemCTCT in db.CTChungTus
                            join itemCT in db.ChungTus on itemCTCT.MaCT equals itemCT.MaCT
                            //join itemLCT in dbDonKH.LoaiChungTus on itemCT.MaLCT equals itemLCT.MaLCT
                            where itemCTCT.Phong == Phong
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.STT,
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

        public DataTable LoadDSChungTu_Phong(string DanhBo,string Phong)
        {
            try
            {
                var query = from itemCTCT in db.CTChungTus
                            join itemCT in db.ChungTus on itemCTCT.MaCT equals itemCT.MaCT
                            //join itemLCT in dbDonKH.LoaiChungTus on itemCT.MaLCT equals itemLCT.MaLCT
                            where itemCTCT.DanhBo==DanhBo&&itemCTCT.Phong == Phong
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.STT,
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

        public DataTable LoadDSChungTu_STT(string DanhBo,string Lo,int STT)
        {
            try
            {
                var query = from itemCTCT in db.CTChungTus
                            join itemCT in db.ChungTus on itemCTCT.MaCT equals itemCT.MaCT
                            //join itemLCT in dbDonKH.LoaiChungTus on itemCT.MaLCT equals itemLCT.MaLCT
                            where itemCTCT.DanhBo == DanhBo && itemCTCT.STT == STT && itemCTCT.Lo == Lo
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.STT,
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

        public DataTable LoadDSChungTu_STTs(string DanhBo,string Lo, int TuSTT, int DenSTT)
        {
            try
            {
                var query = from itemCTCT in db.CTChungTus
                            join itemCT in db.ChungTus on itemCTCT.MaCT equals itemCT.MaCT
                            //join itemLCT in dbDonKH.LoaiChungTus on itemCT.MaLCT equals itemLCT.MaLCT
                            where itemCTCT.DanhBo == DanhBo &&  itemCTCT.STT >= TuSTT && itemCTCT.STT <= DenSTT && itemCTCT.Lo==Lo
                            orderby itemCTCT.STT ascending
                            select new
                            {
                                itemCTCT.STT,
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

        public List<CTChungTu> GetDS(string MaCT)
        {
            return db.CTChungTus.Where(itemCT => itemCT.MaCT == MaCT).ToList();
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

        public int GetTongNKDangKy(string DanhBo)
        {
            return db.CTChungTus.Where(item => item.DanhBo == DanhBo).Sum(item => item.SoNKDangKy);
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

        public bool CheckCTChungTu(string DanhBo, string Lo, string Phong)
        {
            try
            {
                return db.CTChungTus.Any(itemCT => itemCT.DanhBo == DanhBo && itemCT.Lo == Lo && itemCT.Phong == Phong);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
        //            lichsuchungtu.MaLSCT = decimal.Parse(DateTime.Now.ToString("yy") + "1");
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

        /// <summary>
        /// Dùng cho Form Cập Nhật Sổ Đăng Ký, khi có >2 yêu cầu cắt nhân khẩu
        /// </summary>
        /// <param name="chungtu"></param>
        /// <param name="ctchungtu"></param>
        /// <param name="lichsuchungtu"></param>
        /// <param name="lstLichSuChungTu"></param>
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
                    ///Kiểm tra Tổng Nhân Khẩu có thay đổi hay không
                    if (chungtuCN.SoNKTong != chungtu.SoNKTong)
                        if (chungtu.SoNKTong - chungtuCN.SoNKTong + chungtuCN.SoNKConLai >= 0)
                        {
                            chungtuCN.SoNKConLai = chungtu.SoNKTong - chungtuCN.SoNKTong + chungtuCN.SoNKConLai;
                            chungtuCN.SoNKTong = chungtu.SoNKTong;
                            chungtuCN.ModifyDate = DateTime.Now;
                        }
                        else
                        {
                            chungtuCN.SoNKConLai = chungtu.SoNKTong;
                            chungtuCN.SoNKTong = chungtu.SoNKTong;
                            chungtuCN.ModifyDate = DateTime.Now;
                            //MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return false;
                        }
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
                        if (ctchungtu.YeuCauCat)
                        {
                            lichsuchungtu.SoPhieu = getMaxNextSoPhieuLSCT();
                            ctchungtu.SoPhieu = lichsuchungtu.SoPhieu;
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
                            lichsuchungtu.PhieuDuocKy = true;


                        }
                        if (ThemLichSuChungTu(lichsuchungtu) && ctchungtu.YeuCauCat)
                        {
                            ctchungtu.SoPhieu = lichsuchungtu.SoPhieu;
                            //CatChuyenDM catchuyendm = new CatChuyenDM();
                            //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
                            //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
                        }

                        if (ctchungtu.YeuCauCat2)
                        {
                            LichSuChungTu lichsuchungtu2 = new LichSuChungTu();
                            if (lichsuchungtu.ToXuLy)
                            {
                                lichsuchungtu2.ToXuLy = true;
                                lichsuchungtu2.MaDonTXL = lichsuchungtu.MaDonTXL;
                            }
                            else
                                lichsuchungtu2.MaDon = lichsuchungtu.MaDon;
                            lichsuchungtu2.MaCT = ctchungtu.MaCT;
                            lichsuchungtu2.DanhBo = ctchungtu.DanhBo;
                            lichsuchungtu2.SoNKTong = chungtuCN.SoNKTong;
                            lichsuchungtu2.SoNKDangKy = ctchungtu.SoNKDangKy;
                            lichsuchungtu2.SoNKConLai = chungtuCN.SoNKConLai;
                            lichsuchungtu2.ThoiHan = ctchungtu.ThoiHan;
                            lichsuchungtu2.NgayHetHan = ctchungtu.NgayHetHan;
                            ///
                            lichsuchungtu2.SoPhieu = getMaxNextSoPhieuLSCT();
                            ctchungtu.SoPhieu2 = lichsuchungtu2.SoPhieu;
                            ///
                            lichsuchungtu2.NhanNK_DanhBo = lichsuchungtu.NhanNK_DanhBo;
                            lichsuchungtu2.NhanNK_HoTen = lichsuchungtu.NhanNK_HoTen;
                            lichsuchungtu2.NhanNK_DiaChi = lichsuchungtu.NhanNK_DiaChi;
                            ///
                            lichsuchungtu2.YeuCauCat = true;
                            lichsuchungtu2.CatNK_MaCN = ctchungtu.CatNK_MaCN2;
                            lichsuchungtu2.CatNK_DanhBo = ctchungtu.CatNK_DanhBo2;
                            lichsuchungtu2.CatNK_HoTen = ctchungtu.CatNK_HoTen2;
                            lichsuchungtu2.CatNK_DiaChi = ctchungtu.CatNK_DiaChi2;
                            lichsuchungtu2.SoNKNhan = ctchungtu.CatNK_SoNKCat2;

                            CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                lichsuchungtu2.ChucVu = "GIÁM ĐỐC";
                            else
                                lichsuchungtu2.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            lichsuchungtu2.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            lichsuchungtu2.PhieuDuocKy = true;

                            if (ThemLichSuChungTu(lichsuchungtu2))
                            {
                                ctchungtu.SoPhieu2 = lichsuchungtu2.SoPhieu;
                                //CatChuyenDM catchuyendm = new CatChuyenDM();
                                //LSCTtoCCDM(lichsuchungtu2, ref catchuyendm);
                                //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
                            }
                        }

                        if (ctchungtu.YeuCauCat3)
                        {
                            LichSuChungTu lichsuchungtu3 = new LichSuChungTu();
                            if (lichsuchungtu.ToXuLy)
                            {
                                lichsuchungtu3.ToXuLy = true;
                                lichsuchungtu3.MaDonTXL = lichsuchungtu.MaDonTXL;
                            }
                            else
                                lichsuchungtu3.MaDon = lichsuchungtu.MaDon;
                            lichsuchungtu3.MaCT = ctchungtu.MaCT;
                            lichsuchungtu3.DanhBo = ctchungtu.DanhBo;
                            lichsuchungtu3.SoNKTong = chungtuCN.SoNKTong;
                            lichsuchungtu3.SoNKDangKy = ctchungtu.SoNKDangKy;
                            lichsuchungtu3.SoNKConLai = chungtuCN.SoNKConLai;
                            lichsuchungtu3.ThoiHan = ctchungtu.ThoiHan;
                            lichsuchungtu3.NgayHetHan = ctchungtu.NgayHetHan;
                            ///
                            lichsuchungtu3.SoPhieu = getMaxNextSoPhieuLSCT();
                            ctchungtu.SoPhieu3 = lichsuchungtu3.SoPhieu;
                            ///
                            lichsuchungtu3.NhanNK_DanhBo = lichsuchungtu.NhanNK_DanhBo;
                            lichsuchungtu3.NhanNK_HoTen = lichsuchungtu.NhanNK_HoTen;
                            lichsuchungtu3.NhanNK_DiaChi = lichsuchungtu.NhanNK_DiaChi;
                            ///
                            lichsuchungtu3.YeuCauCat = true;
                            lichsuchungtu3.CatNK_MaCN = ctchungtu.CatNK_MaCN3;
                            lichsuchungtu3.CatNK_DanhBo = ctchungtu.CatNK_DanhBo3;
                            lichsuchungtu3.CatNK_HoTen = ctchungtu.CatNK_HoTen3;
                            lichsuchungtu3.CatNK_DiaChi = ctchungtu.CatNK_DiaChi3;
                            lichsuchungtu3.SoNKNhan = ctchungtu.CatNK_SoNKCat3;

                            CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                lichsuchungtu3.ChucVu = "GIÁM ĐỐC";
                            else
                                lichsuchungtu3.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            lichsuchungtu3.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            lichsuchungtu3.PhieuDuocKy = true;

                            if (ThemLichSuChungTu(lichsuchungtu3))
                            {
                                ctchungtu.SoPhieu3 = lichsuchungtu3.SoPhieu;
                                //CatChuyenDM catchuyendm = new CatChuyenDM();
                                //LSCTtoCCDM(lichsuchungtu3, ref catchuyendm);
                                //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
                            }
                        }

                        if (ctchungtu.YeuCauCat4)
                        {
                            LichSuChungTu lichsuchungtu4 = new LichSuChungTu();
                            if (lichsuchungtu.ToXuLy)
                            {
                                lichsuchungtu4.ToXuLy = true;
                                lichsuchungtu4.MaDonTXL = lichsuchungtu.MaDonTXL;
                            }
                            else
                                lichsuchungtu4.MaDon = lichsuchungtu.MaDon;
                            lichsuchungtu4.MaCT = ctchungtu.MaCT;
                            lichsuchungtu4.DanhBo = ctchungtu.DanhBo;
                            lichsuchungtu4.SoNKTong = chungtuCN.SoNKTong;
                            lichsuchungtu4.SoNKDangKy = ctchungtu.SoNKDangKy;
                            lichsuchungtu4.SoNKConLai = chungtuCN.SoNKConLai;
                            lichsuchungtu4.ThoiHan = ctchungtu.ThoiHan;
                            lichsuchungtu4.NgayHetHan = ctchungtu.NgayHetHan;
                            ///
                            lichsuchungtu4.SoPhieu = getMaxNextSoPhieuLSCT();
                            ctchungtu.SoPhieu2 = lichsuchungtu4.SoPhieu;
                            ///
                            lichsuchungtu4.NhanNK_DanhBo = lichsuchungtu.NhanNK_DanhBo;
                            lichsuchungtu4.NhanNK_HoTen = lichsuchungtu.NhanNK_HoTen;
                            lichsuchungtu4.NhanNK_DiaChi = lichsuchungtu.NhanNK_DiaChi;
                            ///
                            lichsuchungtu4.YeuCauCat = true;
                            lichsuchungtu4.CatNK_MaCN = ctchungtu.CatNK_MaCN4;
                            lichsuchungtu4.CatNK_DanhBo = ctchungtu.CatNK_DanhBo4;
                            lichsuchungtu4.CatNK_HoTen = ctchungtu.CatNK_HoTen4;
                            lichsuchungtu4.CatNK_DiaChi = ctchungtu.CatNK_DiaChi4;
                            lichsuchungtu4.SoNKNhan = ctchungtu.CatNK_SoNKCat4;

                            CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                lichsuchungtu4.ChucVu = "GIÁM ĐỐC";
                            else
                                lichsuchungtu4.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            lichsuchungtu4.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            lichsuchungtu4.PhieuDuocKy = true;

                            if (ThemLichSuChungTu(lichsuchungtu4))
                            {
                                ctchungtu.SoPhieu4 = lichsuchungtu4.SoPhieu;
                                //CatChuyenDM catchuyendm = new CatChuyenDM();
                                //LSCTtoCCDM(lichsuchungtu4, ref catchuyendm);
                                //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
                            }
                        }

                        if (ctchungtu.YeuCauCat5)
                        {
                            LichSuChungTu lichsuchungtu5 = new LichSuChungTu();
                            if (lichsuchungtu.ToXuLy)
                            {
                                lichsuchungtu5.ToXuLy = true;
                                lichsuchungtu5.MaDonTXL = lichsuchungtu.MaDonTXL;
                            }
                            else
                                lichsuchungtu5.MaDon = lichsuchungtu.MaDon;
                            lichsuchungtu5.MaCT = ctchungtu.MaCT;
                            lichsuchungtu5.DanhBo = ctchungtu.DanhBo;
                            lichsuchungtu5.SoNKTong = chungtuCN.SoNKTong;
                            lichsuchungtu5.SoNKDangKy = ctchungtu.SoNKDangKy;
                            lichsuchungtu5.SoNKConLai = chungtuCN.SoNKConLai;
                            lichsuchungtu5.ThoiHan = ctchungtu.ThoiHan;
                            lichsuchungtu5.NgayHetHan = ctchungtu.NgayHetHan;
                            ///
                            lichsuchungtu5.SoPhieu = getMaxNextSoPhieuLSCT();
                            ctchungtu.SoPhieu2 = lichsuchungtu5.SoPhieu;
                            ///
                            lichsuchungtu5.NhanNK_DanhBo = lichsuchungtu.NhanNK_DanhBo;
                            lichsuchungtu5.NhanNK_HoTen = lichsuchungtu.NhanNK_HoTen;
                            lichsuchungtu5.NhanNK_DiaChi = lichsuchungtu.NhanNK_DiaChi;
                            ///
                            lichsuchungtu5.YeuCauCat = true;
                            lichsuchungtu5.CatNK_MaCN = ctchungtu.CatNK_MaCN5;
                            lichsuchungtu5.CatNK_DanhBo = ctchungtu.CatNK_DanhBo5;
                            lichsuchungtu5.CatNK_HoTen = ctchungtu.CatNK_HoTen5;
                            lichsuchungtu5.CatNK_DiaChi = ctchungtu.CatNK_DiaChi5;
                            lichsuchungtu5.SoNKNhan = ctchungtu.CatNK_SoNKCat5;

                            CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                lichsuchungtu5.ChucVu = "GIÁM ĐỐC";
                            else
                                lichsuchungtu5.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            lichsuchungtu5.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            lichsuchungtu5.PhieuDuocKy = true;

                            if (ThemLichSuChungTu(lichsuchungtu5))
                            {
                                ctchungtu.SoPhieu5 = lichsuchungtu5.SoPhieu;
                                //CatChuyenDM catchuyendm = new CatChuyenDM();
                                //LSCTtoCCDM(lichsuchungtu5, ref catchuyendm);
                                //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
                            }
                        }
                        db.SubmitChanges();

                        //for (int i = 0; i < lstLichSuChungTu.Count; i++)
                        //{
                        //    ///Cập nhật bảng LichSuChungTu
                        //    lstLichSuChungTu[i].MaCT = ctchungtu.MaCT;
                        //    lstLichSuChungTu[i].DanhBo = ctchungtu.DanhBo;
                        //    lstLichSuChungTu[i].SoNKTong = chungtuCN.SoNKTong;
                        //    lstLichSuChungTu[i].SoNKDangKy = ctchungtu.SoNKDangKy;
                        //    lstLichSuChungTu[i].SoNKConLai = chungtuCN.SoNKConLai;
                        //    lstLichSuChungTu[i].ThoiHan = ctchungtu.ThoiHan;
                        //    lstLichSuChungTu[i].NgayHetHan = ctchungtu.NgayHetHan;
                        //    ///
                        //    lstLichSuChungTu[i].SoPhieu = getMaxNextSoPhieuLSCT();
                        //    switch (i)
                        //    {
                        //        case 0:
                        //            ctchungtu.SoPhieu2 = lstLichSuChungTu[i].SoPhieu;
                        //            break;
                        //        case 1:
                        //            ctchungtu.SoPhieu3 = lstLichSuChungTu[i].SoPhieu;
                        //            break;
                        //        case 2:
                        //            ctchungtu.SoPhieu4 = lstLichSuChungTu[i].SoPhieu;
                        //            break;
                        //        case 3:
                        //            ctchungtu.SoPhieu5 = lstLichSuChungTu[i].SoPhieu;
                        //            break;
                        //    }

                        //    lstLichSuChungTu[i].NhanDM = true;
                        //    lstLichSuChungTu[i].YCCat = true;

                        //    lstLichSuChungTu[i].CatNK_MaCN = ctchungtu.CatNK_MaCN;
                        //    lstLichSuChungTu[i].CatNK_DanhBo = ctchungtu.CatNK_DanhBo;
                        //    lstLichSuChungTu[i].CatNK_HoTen = ctchungtu.CatNK_HoTen;
                        //    lstLichSuChungTu[i].CatNK_DiaChi = ctchungtu.CatNK_DiaChi;
                        //    lstLichSuChungTu[i].SoNKNhan = ctchungtu.CatNK_SoNKCat;
                        //    CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
                        //    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        //    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                        //        lstLichSuChungTu[i].ChucVu = "GIÁM ĐỐC";
                        //    else
                        //        lstLichSuChungTu[i].ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        //    lstLichSuChungTu[i].NguoiKy = bangiamdoc.HoTen.ToUpper();

                        //    ThemLichSuChungTu(lstLichSuChungTu[i]);
                        //}
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
        /// <param name="lstLichSuChungTu"></param>
        /// <returns></returns>
        public bool SuaChungTu(ChungTu chungtu, CTChungTu ctchungtu, LichSuChungTu lichsuchungtu)
        {
            try
            {
                if (db.Connection.State == System.Data.ConnectionState.Closed)
                    db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                bool flagEdited = false;
                bool flagGiam = false;
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
                        chungtuCN.SoNKConLai = chungtu.SoNKTong;
                        chungtuCN.SoNKTong = chungtu.SoNKTong;
                        chungtuCN.ModifyDate = DateTime.Now;
                        flagEdited = true;
                        flagGiam = true;
                        //MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //return false;
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
                }

                ///Cập Nhật bảng CTChungTu khi thay đổi Số Nhân Khẩu đăng ký (frmSoDK)
                CTChungTu ctchungtuCN = getCTChungTubyID(ctchungtu.DanhBo, ctchungtu.MaCT);
                ///Kiểm tra Số Nhân Khẩu đăng ký có thay đổi hay không
                if (ctchungtuCN.SoNKDangKy != ctchungtu.SoNKDangKy)
                    if (flagGiam)
                    {
                        ///Cập nhật Số Nhân Khẩu Cấp cho bảng ChungTu
                        chungtuCN.SoNKConLai = chungtuCN.SoNKConLai - ctchungtu.SoNKDangKy;
                        chungtuCN.SoNKDaCap = ctchungtu.SoNKDangKy;
                        chungtuCN.ModifyDate = DateTime.Now;
                        ///Cập nhật bảng CTChungTu
                        ctchungtuCN.SoNKDangKy = ctchungtu.SoNKDangKy;
                        ctchungtuCN.ModifyDate = DateTime.Now;
                        flagEdited = true;
                    }
                    else
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
                            flagEdited = true;
                        }
                        else
                        {
                            MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                if (ctchungtuCN.STT != ctchungtu.STT || ctchungtuCN.ThoiHan != ctchungtu.ThoiHan || ctchungtuCN.Lo != ctchungtu.Lo || ctchungtuCN.Phong != ctchungtu.Phong || ctchungtuCN.GhiChu != ctchungtu.GhiChu || (ctchungtuCN.NgayHetHan != ctchungtu.NgayHetHan && ctchungtu.NgayHetHan != null))
                {
                    if (ctchungtuCN.ThoiHan != ctchungtu.ThoiHan)
                    {
                        ctchungtuCN.ThoiHan = ctchungtu.ThoiHan;
                        if (ctchungtu.ThoiHan != null)
                        {
                            ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
                            ///Khi gia hạn refresh lại ngày tạo để tính ngày gia hạn
                            ctchungtuCN.CreateDate = DateTime.Now;
                            ctchungtuCN.NgayHetHan = ctchungtuCN.CreateDate.Value.AddMonths(ctchungtu.ThoiHan.Value);
                        }
                        else
                            ctchungtuCN.NgayHetHan = null;
                        flagEdited = true;
                    }
                    if (ctchungtu.NgayHetHan != null)
                    {
                        ctchungtuCN.CreateDate = DateTime.Now;
                        ctchungtuCN.NgayHetHan = ctchungtu.NgayHetHan;
                        flagEdited = true;
                    }
                    if (ctchungtuCN.STT != ctchungtu.STT)
                        ctchungtuCN.STT = ctchungtu.STT;
                    if (ctchungtuCN.Lo != ctchungtu.Lo)
                        ctchungtuCN.Lo = ctchungtu.Lo;
                    if (ctchungtuCN.Phong != ctchungtu.Phong)
                        ctchungtuCN.Phong = ctchungtu.Phong;
                    if (ctchungtuCN.GhiChu != ctchungtu.GhiChu)
                        ctchungtuCN.GhiChu = ctchungtu.GhiChu;
                    ctchungtuCN.ModifyDate = DateTime.Now;

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
                    ctchungtuCN.CatNK_GhiChu = ctchungtu.CatNK_GhiChu;
                    ctchungtuCN.CatNK_MaCT = ctchungtu.CatNK_MaCT;
                    ///Nếu phiếu đã có
                    if (ctchungtuCN.SoPhieu.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu.Value);
                        lichsuchungtuCN.CatNK_MaCN = ctchungtu.CatNK_MaCN;
                        lichsuchungtuCN.CatNK_DanhBo = ctchungtu.CatNK_DanhBo;
                        lichsuchungtuCN.CatNK_HoTen = ctchungtu.CatNK_HoTen;
                        lichsuchungtuCN.CatNK_DiaChi = ctchungtu.CatNK_DiaChi;
                        lichsuchungtuCN.SoNKNhan = ctchungtu.CatNK_SoNKCat;
                        lichsuchungtuCN.GhiChu = ctchungtu.CatNK_GhiChu;
                        lichsuchungtuCN.CatNK_MaCT = ctchungtu.CatNK_MaCT;
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
                        //ctchungtuCN.SoPhieu = lichsuchungtu.SoPhieu;
                        lichsuchungtu.YeuCauCat = true;

                        lichsuchungtu.CatNK_MaCN = ctchungtu.CatNK_MaCN;
                        lichsuchungtu.CatNK_DanhBo = ctchungtu.CatNK_DanhBo;
                        lichsuchungtu.CatNK_HoTen = ctchungtu.CatNK_HoTen;
                        lichsuchungtu.CatNK_DiaChi = ctchungtu.CatNK_DiaChi;
                        lichsuchungtu.SoNKNhan = ctchungtu.CatNK_SoNKCat;
                        lichsuchungtu.GhiChu = ctchungtu.CatNK_GhiChu;
                        lichsuchungtu.CatNK_MaCT = ctchungtu.CatNK_MaCT;
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

                #region Yêu Cầu Cắt 2,3,4,5

                //if (ctchungtu.YeuCauCat2 != ctchungtuCN.YeuCauCat2)
                if (ctchungtu.YeuCauCat2)
                {
                    ctchungtuCN.YeuCauCat2 = true;
                    ctchungtuCN.CatNK_MaCN2 = ctchungtu.CatNK_MaCN2;
                    ctchungtuCN.CatNK_DanhBo2 = ctchungtu.CatNK_DanhBo2;
                    ctchungtuCN.CatNK_HoTen2 = ctchungtu.CatNK_HoTen2;
                    ctchungtuCN.CatNK_DiaChi2 = ctchungtu.CatNK_DiaChi2;
                    ctchungtuCN.CatNK_SoNKCat2 = ctchungtu.CatNK_SoNKCat2;
                    ctchungtuCN.CatNK_GhiChu2 = ctchungtu.CatNK_GhiChu2;
                    ctchungtuCN.CatNK_MaCT2 = ctchungtu.CatNK_MaCT2;
                    ///
                    if (ctchungtuCN.SoPhieu2.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN2 = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu2.Value);
                        lichsuchungtuCN2.CatNK_MaCN = ctchungtu.CatNK_MaCN2;
                        lichsuchungtuCN2.CatNK_DanhBo = ctchungtu.CatNK_DanhBo2;
                        lichsuchungtuCN2.CatNK_HoTen = ctchungtu.CatNK_HoTen2;
                        lichsuchungtuCN2.CatNK_DiaChi = ctchungtu.CatNK_DiaChi2;
                        lichsuchungtuCN2.SoNKNhan = ctchungtu.CatNK_SoNKCat2;
                        lichsuchungtuCN2.GhiChu = ctchungtu.CatNK_GhiChu2;
                        lichsuchungtuCN2.CatNK_MaCT = ctchungtu.CatNK_MaCT2;
                        if (SuaLichSuChungTu(lichsuchungtuCN2))
                        {
                            //CatChuyenDM catchuyendm = _cCatChuyenDM.getCatChuyenDMbySoPhieu(ctchungtuCN.SoPhieu2.Value);
                            //catchuyendm.CatNK_MaCN = lichsuchungtuCN2.CatNK_MaCN;
                            //catchuyendm.CatNK_DanhBo = lichsuchungtuCN2.CatNK_DanhBo;
                            //catchuyendm.CatNK_HoTen = lichsuchungtuCN2.CatNK_HoTen;
                            //catchuyendm.CatNK_DiaChi = lichsuchungtuCN2.CatNK_DiaChi;
                            //catchuyendm.SoNKNhan = lichsuchungtuCN2.SoNKNhan;

                            //_cCatChuyenDM.SuaCatChuyemDM(catchuyendm);
                        }
                    }
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
                        //ctchungtuCN.SoPhieu2 = lichsuchungtu.SoPhieu;
                        lichsuchungtu.YeuCauCat = true;

                        lichsuchungtu.CatNK_MaCN = ctchungtu.CatNK_MaCN2;
                        lichsuchungtu.CatNK_DanhBo = ctchungtu.CatNK_DanhBo2;
                        lichsuchungtu.CatNK_HoTen = ctchungtu.CatNK_HoTen2;
                        lichsuchungtu.CatNK_DiaChi = ctchungtu.CatNK_DiaChi2;
                        lichsuchungtu.SoNKNhan = ctchungtu.CatNK_SoNKCat2;
                        lichsuchungtu.GhiChu = ctchungtu.CatNK_GhiChu2;
                        lichsuchungtu.CatNK_MaCT = ctchungtu.CatNK_MaCT2;
                        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            lichsuchungtu.ChucVu = "GIÁM ĐỐC";
                        else
                            lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        if (ThemLichSuChungTu(lichsuchungtu))
                        {
                            ctchungtuCN.SoPhieu2 = lichsuchungtu.SoPhieu;
                            //CatChuyenDM catchuyendm = new CatChuyenDM();
                            //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
                            //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
                        }
                    }
                }
                else
                {
                    ctchungtuCN.YeuCauCat2 = false;
                    if (ctchungtuCN.SoPhieu2.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu2.Value);
                        XoaLichSuChungTu(lichsuchungtuCN);
                    }
                }

                //if (ctchungtu.YeuCauCat3 != ctchungtuCN.YeuCauCat3)
                if (ctchungtu.YeuCauCat3)
                {
                    ctchungtuCN.YeuCauCat3 = true;
                    ctchungtuCN.CatNK_MaCN3 = ctchungtu.CatNK_MaCN3;
                    ctchungtuCN.CatNK_DanhBo3 = ctchungtu.CatNK_DanhBo3;
                    ctchungtuCN.CatNK_HoTen3 = ctchungtu.CatNK_HoTen3;
                    ctchungtuCN.CatNK_DiaChi3 = ctchungtu.CatNK_DiaChi3;
                    ctchungtuCN.CatNK_SoNKCat3 = ctchungtu.CatNK_SoNKCat3;
                    ctchungtuCN.CatNK_GhiChu3 = ctchungtu.CatNK_GhiChu3;
                    ctchungtuCN.CatNK_MaCT3 = ctchungtu.CatNK_MaCT3;
                    ///
                    if (ctchungtuCN.SoPhieu3.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN3 = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu3.Value);
                        lichsuchungtuCN3.CatNK_MaCN = ctchungtu.CatNK_MaCN3;
                        lichsuchungtuCN3.CatNK_DanhBo = ctchungtu.CatNK_DanhBo3;
                        lichsuchungtuCN3.CatNK_HoTen = ctchungtu.CatNK_HoTen3;
                        lichsuchungtuCN3.CatNK_DiaChi = ctchungtu.CatNK_DiaChi3;
                        lichsuchungtuCN3.SoNKNhan = ctchungtu.CatNK_SoNKCat3;
                        lichsuchungtuCN3.GhiChu = ctchungtu.CatNK_GhiChu3;
                        lichsuchungtuCN3.CatNK_MaCT = ctchungtu.CatNK_MaCT3;
                        if (SuaLichSuChungTu(lichsuchungtuCN3))
                        {
                            //CatChuyenDM catchuyendm = _cCatChuyenDM.getCatChuyenDMbySoPhieu(ctchungtuCN.SoPhieu3.Value);
                            //catchuyendm.CatNK_MaCN = lichsuchungtuCN3.CatNK_MaCN;
                            //catchuyendm.CatNK_DanhBo = lichsuchungtuCN3.CatNK_DanhBo;
                            //catchuyendm.CatNK_HoTen = lichsuchungtuCN3.CatNK_HoTen;
                            //catchuyendm.CatNK_DiaChi = lichsuchungtuCN3.CatNK_DiaChi;
                            //catchuyendm.SoNKNhan = lichsuchungtuCN3.SoNKNhan;

                            //_cCatChuyenDM.SuaCatChuyemDM(catchuyendm);
                        }
                    }
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
                        //ctchungtuCN.SoPhieu3 = lichsuchungtu.SoPhieu;
                        lichsuchungtu.YeuCauCat = true;

                        lichsuchungtu.CatNK_MaCN = ctchungtu.CatNK_MaCN3;
                        lichsuchungtu.CatNK_DanhBo = ctchungtu.CatNK_DanhBo3;
                        lichsuchungtu.CatNK_HoTen = ctchungtu.CatNK_HoTen3;
                        lichsuchungtu.CatNK_DiaChi = ctchungtu.CatNK_DiaChi3;
                        lichsuchungtu.SoNKNhan = ctchungtu.CatNK_SoNKCat3;
                        lichsuchungtu.GhiChu = ctchungtu.CatNK_GhiChu3;
                        lichsuchungtu.CatNK_MaCT = ctchungtu.CatNK_MaCT3;
                        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            lichsuchungtu.ChucVu = "GIÁM ĐỐC";
                        else
                            lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        if (ThemLichSuChungTu(lichsuchungtu))
                        {
                            ctchungtuCN.SoPhieu3 = lichsuchungtu.SoPhieu;
                            //CatChuyenDM catchuyendm = new CatChuyenDM();
                            //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
                            //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
                        }
                    }
                }
                else
                {
                    ctchungtuCN.YeuCauCat3 = false;
                    if (ctchungtuCN.SoPhieu3.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu3.Value);
                        XoaLichSuChungTu(lichsuchungtuCN);
                    }
                }

                //if (ctchungtu.YeuCauCat4 != ctchungtuCN.YeuCauCat4)
                if (ctchungtu.YeuCauCat4)
                {
                    ctchungtuCN.YeuCauCat4 = true;
                    ctchungtuCN.CatNK_MaCN4 = ctchungtu.CatNK_MaCN4;
                    ctchungtuCN.CatNK_DanhBo4 = ctchungtu.CatNK_DanhBo4;
                    ctchungtuCN.CatNK_HoTen4 = ctchungtu.CatNK_HoTen4;
                    ctchungtuCN.CatNK_DiaChi4 = ctchungtu.CatNK_DiaChi4;
                    ctchungtuCN.CatNK_SoNKCat4 = ctchungtu.CatNK_SoNKCat4;
                    ctchungtuCN.CatNK_GhiChu4 = ctchungtu.CatNK_GhiChu4;
                    ctchungtuCN.CatNK_MaCT4 = ctchungtu.CatNK_MaCT4;
                    ///
                    if (ctchungtuCN.SoPhieu4.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN4 = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu4.Value);
                        lichsuchungtuCN4.CatNK_MaCN = ctchungtu.CatNK_MaCN4;
                        lichsuchungtuCN4.CatNK_DanhBo = ctchungtu.CatNK_DanhBo4;
                        lichsuchungtuCN4.CatNK_HoTen = ctchungtu.CatNK_HoTen4;
                        lichsuchungtuCN4.CatNK_DiaChi = ctchungtu.CatNK_DiaChi4;
                        lichsuchungtuCN4.SoNKNhan = ctchungtu.CatNK_SoNKCat4;
                        lichsuchungtuCN4.GhiChu = ctchungtu.CatNK_GhiChu4;
                        lichsuchungtuCN4.CatNK_MaCT = ctchungtu.CatNK_MaCT4;
                        if (SuaLichSuChungTu(lichsuchungtuCN4))
                        {
                            //CatChuyenDM catchuyendm = _cCatChuyenDM.getCatChuyenDMbySoPhieu(ctchungtuCN.SoPhieu4.Value);
                            //catchuyendm.CatNK_MaCN = lichsuchungtuCN4.CatNK_MaCN;
                            //catchuyendm.CatNK_DanhBo = lichsuchungtuCN4.CatNK_DanhBo;
                            //catchuyendm.CatNK_HoTen = lichsuchungtuCN4.CatNK_HoTen;
                            //catchuyendm.CatNK_DiaChi = lichsuchungtuCN4.CatNK_DiaChi;
                            //catchuyendm.SoNKNhan = lichsuchungtuCN4.SoNKNhan;

                            //_cCatChuyenDM.SuaCatChuyemDM(catchuyendm);
                        }
                    }
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
                        //ctchungtuCN.SoPhieu4 = lichsuchungtu.SoPhieu;
                        lichsuchungtu.YeuCauCat = true;

                        lichsuchungtu.CatNK_MaCN = ctchungtu.CatNK_MaCN4;
                        lichsuchungtu.CatNK_DanhBo = ctchungtu.CatNK_DanhBo4;
                        lichsuchungtu.CatNK_HoTen = ctchungtu.CatNK_HoTen4;
                        lichsuchungtu.CatNK_DiaChi = ctchungtu.CatNK_DiaChi4;
                        lichsuchungtu.SoNKNhan = ctchungtu.CatNK_SoNKCat4;
                        lichsuchungtu.GhiChu = ctchungtu.CatNK_GhiChu4;
                        lichsuchungtu.CatNK_MaCT = ctchungtu.CatNK_MaCT4;
                        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            lichsuchungtu.ChucVu = "GIÁM ĐỐC";
                        else
                            lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        if (ThemLichSuChungTu(lichsuchungtu))
                        {
                            ctchungtuCN.SoPhieu4 = lichsuchungtu.SoPhieu;
                            //CatChuyenDM catchuyendm = new CatChuyenDM();
                            //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
                            //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
                        }
                    }
                }
                else
                {
                    ctchungtuCN.YeuCauCat4 = false;
                    if (ctchungtuCN.SoPhieu4.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu4.Value);
                        XoaLichSuChungTu(lichsuchungtuCN);
                    }
                }

                //if (ctchungtu.YeuCauCat5 != ctchungtuCN.YeuCauCat5)
                if (ctchungtu.YeuCauCat5)
                {
                    ctchungtuCN.YeuCauCat5 = true;
                    ctchungtuCN.CatNK_MaCN5 = ctchungtu.CatNK_MaCN5;
                    ctchungtuCN.CatNK_DanhBo5 = ctchungtu.CatNK_DanhBo5;
                    ctchungtuCN.CatNK_HoTen5 = ctchungtu.CatNK_HoTen5;
                    ctchungtuCN.CatNK_DiaChi5 = ctchungtu.CatNK_DiaChi5;
                    ctchungtuCN.CatNK_SoNKCat5 = ctchungtu.CatNK_SoNKCat5;
                    ctchungtuCN.CatNK_GhiChu5 = ctchungtu.CatNK_GhiChu5;
                    ctchungtuCN.CatNK_MaCT5 = ctchungtu.CatNK_MaCT5;
                    ///
                    if (ctchungtuCN.SoPhieu5.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN5 = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu5.Value);
                        lichsuchungtuCN5.CatNK_MaCN = ctchungtu.CatNK_MaCN5;
                        lichsuchungtuCN5.CatNK_DanhBo = ctchungtu.CatNK_DanhBo5;
                        lichsuchungtuCN5.CatNK_HoTen = ctchungtu.CatNK_HoTen5;
                        lichsuchungtuCN5.CatNK_DiaChi = ctchungtu.CatNK_DiaChi5;
                        lichsuchungtuCN5.SoNKNhan = ctchungtu.CatNK_SoNKCat5;
                        lichsuchungtuCN5.GhiChu = ctchungtu.CatNK_GhiChu5;
                        lichsuchungtuCN5.CatNK_MaCT = ctchungtu.CatNK_MaCT5;
                        if (SuaLichSuChungTu(lichsuchungtuCN5))
                        {
                            //CatChuyenDM catchuyendm = _cCatChuyenDM.getCatChuyenDMbySoPhieu(ctchungtuCN.SoPhieu5.Value);
                            //catchuyendm.CatNK_MaCN = lichsuchungtuCN5.CatNK_MaCN;
                            //catchuyendm.CatNK_DanhBo = lichsuchungtuCN5.CatNK_DanhBo;
                            //catchuyendm.CatNK_HoTen = lichsuchungtuCN5.CatNK_HoTen;
                            //catchuyendm.CatNK_DiaChi = lichsuchungtuCN5.CatNK_DiaChi;
                            //catchuyendm.SoNKNhan = lichsuchungtuCN5.SoNKNhan;

                            //_cCatChuyenDM.SuaCatChuyemDM(catchuyendm);
                        }
                    }
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
                        //ctchungtuCN.SoPhieu5 = lichsuchungtu.SoPhieu;
                        lichsuchungtu.YeuCauCat = true;

                        lichsuchungtu.CatNK_MaCN = ctchungtu.CatNK_MaCN5;
                        lichsuchungtu.CatNK_DanhBo = ctchungtu.CatNK_DanhBo5;
                        lichsuchungtu.CatNK_HoTen = ctchungtu.CatNK_HoTen5;
                        lichsuchungtu.CatNK_DiaChi = ctchungtu.CatNK_DiaChi5;
                        lichsuchungtu.SoNKNhan = ctchungtu.CatNK_SoNKCat5;
                        lichsuchungtu.GhiChu = ctchungtu.CatNK_GhiChu5;
                        lichsuchungtu.CatNK_MaCT = ctchungtu.CatNK_MaCT5;
                        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            lichsuchungtu.ChucVu = "GIÁM ĐỐC";
                        else
                            lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        if (ThemLichSuChungTu(lichsuchungtu))
                        {
                            ctchungtuCN.SoPhieu5 = lichsuchungtu.SoPhieu;
                            //CatChuyenDM catchuyendm = new CatChuyenDM();
                            //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
                            //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
                        }
                    }
                }
                else
                {
                    ctchungtuCN.YeuCauCat5 = false;
                    if (ctchungtuCN.SoPhieu5.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN = getLichSuChungTubySoPhieu(ctchungtuCN.SoPhieu5.Value);
                        XoaLichSuChungTu(lichsuchungtuCN);
                    }
                }

                #endregion

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
                db.Transaction.Commit();
                //MessageBox.Show("Thành công Sửa ChungTu Method", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbChungCuDataContext();
                return false;
            }
        }

        public bool SuaChungTu(DanhSachChungTu dsct, LichSuChungTu lichsuchungtu)
        {
            try
            {
                if (db.Connection.State == System.Data.ConnectionState.Closed)
                    db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                if (dsct.YeuCauCat)
                {
                    //chungtuCN.YeuCauCat = true;
                    //chungtuCN.CatNK_MaCN = chungtu.CatNK_MaCN;
                    //chungtuCN.CatNK_DanhBo = chungtu.CatNK_DanhBo;
                    //chungtuCN.CatNK_HoTen = chungtu.CatNK_HoTen;
                    //chungtuCN.CatNK_DiaChi = chungtu.CatNK_DiaChi;
                    //chungtuCN.CatNK_SoNKCat = chungtu.CatNK_SoNKCat;
                    ///
                    dsct.YeuCauCat = true;
                    dsct.CatNK_MaCN = dsct.CatNK_MaCN;
                    dsct.CatNK_DanhBo = dsct.CatNK_DanhBo;
                    dsct.CatNK_HoTen = dsct.CatNK_HoTen;
                    dsct.CatNK_DiaChi = dsct.CatNK_DiaChi;
                    dsct.CatNK_SoNKCat = dsct.CatNK_SoNKCat;
                    dsct.CatNK_GhiChu = dsct.CatNK_GhiChu;
                    dsct.CatNK_MaCT = dsct.CatNK_MaCT;
                    ///Nếu phiếu đã có
                    if (dsct.SoPhieu.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN = getLichSuChungTubySoPhieu(dsct.SoPhieu.Value);
                        lichsuchungtuCN.CatNK_MaCN = dsct.CatNK_MaCN;
                        lichsuchungtuCN.CatNK_DanhBo = dsct.CatNK_DanhBo;
                        lichsuchungtuCN.CatNK_HoTen = dsct.CatNK_HoTen;
                        lichsuchungtuCN.CatNK_DiaChi = dsct.CatNK_DiaChi;
                        lichsuchungtuCN.SoNKNhan = dsct.CatNK_SoNKCat;
                        lichsuchungtuCN.GhiChu = dsct.CatNK_GhiChu;
                        lichsuchungtuCN.CatNK_MaCT = dsct.CatNK_MaCT;
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
                        lichsuchungtu.MaCT = dsct.MaCT;
                        lichsuchungtu.DanhBo = dsct.DanhBo;
                        lichsuchungtu.SoNKTong = dsct.SoNKTong;
                        lichsuchungtu.SoNKDangKy = dsct.SoNKDangKy;
                        lichsuchungtu.ThoiHan = dsct.ThoiHan;
                        lichsuchungtu.NgayHetHan = dsct.NgayHetHan;
                        ///
                        lichsuchungtu.SoPhieu = getMaxNextSoPhieuLSCT();
                        //ctchungtuCN.SoPhieu = lichsuchungtu.SoPhieu;
                        lichsuchungtu.YeuCauCat = true;

                        lichsuchungtu.CatNK_MaCN = dsct.CatNK_MaCN;
                        lichsuchungtu.CatNK_DanhBo = dsct.CatNK_DanhBo;
                        lichsuchungtu.CatNK_HoTen = dsct.CatNK_HoTen;
                        lichsuchungtu.CatNK_DiaChi = dsct.CatNK_DiaChi;
                        lichsuchungtu.SoNKNhan = dsct.CatNK_SoNKCat;
                        lichsuchungtu.GhiChu = dsct.CatNK_GhiChu;
                        lichsuchungtu.CatNK_MaCT = dsct.CatNK_MaCT;
                        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            lichsuchungtu.ChucVu = "GIÁM ĐỐC";
                        else
                            lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        if (ThemLichSuChungTu(lichsuchungtu))
                        {
                            dsct.SoPhieu = lichsuchungtu.SoPhieu;
                            //CatChuyenDM catchuyendm = new CatChuyenDM();
                            //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
                            //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
                        }
                    }
                }
                else
                {
                    dsct.YeuCauCat = false;
                    if (dsct.SoPhieu.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN = getLichSuChungTubySoPhieu(dsct.SoPhieu.Value);
                        XoaLichSuChungTu(lichsuchungtuCN);
                    }
                }

                #region Yêu Cầu Cắt 2,3,4,5

                //if (ctchungtu.YeuCauCat2 != ctchungtuCN.YeuCauCat2)
                if (dsct.YeuCauCat2)
                {
                    dsct.YeuCauCat2 = true;
                    dsct.CatNK_MaCN2 = dsct.CatNK_MaCN2;
                    dsct.CatNK_DanhBo2 = dsct.CatNK_DanhBo2;
                    dsct.CatNK_HoTen2 = dsct.CatNK_HoTen2;
                    dsct.CatNK_DiaChi2 = dsct.CatNK_DiaChi2;
                    dsct.CatNK_SoNKCat2 = dsct.CatNK_SoNKCat2;
                    dsct.CatNK_GhiChu2 = dsct.CatNK_GhiChu2;
                    dsct.CatNK_MaCT2 = dsct.CatNK_MaCT2;
                    ///
                    if (dsct.SoPhieu2.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN2 = getLichSuChungTubySoPhieu(dsct.SoPhieu2.Value);
                        lichsuchungtuCN2.CatNK_MaCN = dsct.CatNK_MaCN2;
                        lichsuchungtuCN2.CatNK_DanhBo = dsct.CatNK_DanhBo2;
                        lichsuchungtuCN2.CatNK_HoTen = dsct.CatNK_HoTen2;
                        lichsuchungtuCN2.CatNK_DiaChi = dsct.CatNK_DiaChi2;
                        lichsuchungtuCN2.SoNKNhan = dsct.CatNK_SoNKCat2;
                        lichsuchungtuCN2.GhiChu = dsct.CatNK_GhiChu2;
                        lichsuchungtuCN2.CatNK_MaCT = dsct.CatNK_MaCT2;
                        if (SuaLichSuChungTu(lichsuchungtuCN2))
                        {
                            //CatChuyenDM catchuyendm = _cCatChuyenDM.getCatChuyenDMbySoPhieu(ctchungtuCN.SoPhieu2.Value);
                            //catchuyendm.CatNK_MaCN = lichsuchungtuCN2.CatNK_MaCN;
                            //catchuyendm.CatNK_DanhBo = lichsuchungtuCN2.CatNK_DanhBo;
                            //catchuyendm.CatNK_HoTen = lichsuchungtuCN2.CatNK_HoTen;
                            //catchuyendm.CatNK_DiaChi = lichsuchungtuCN2.CatNK_DiaChi;
                            //catchuyendm.SoNKNhan = lichsuchungtuCN2.SoNKNhan;

                            //_cCatChuyenDM.SuaCatChuyemDM(catchuyendm);
                        }
                    }
                    else
                    {
                        lichsuchungtu.MaCT = dsct.MaCT;
                        lichsuchungtu.DanhBo = dsct.DanhBo;
                        lichsuchungtu.SoNKTong = dsct.SoNKTong;
                        lichsuchungtu.SoNKDangKy = dsct.SoNKDangKy;
                        lichsuchungtu.ThoiHan = dsct.ThoiHan;
                        lichsuchungtu.NgayHetHan = dsct.NgayHetHan;
                        ///
                        lichsuchungtu.SoPhieu = getMaxNextSoPhieuLSCT();
                        //ctchungtuCN.SoPhieu2 = lichsuchungtu.SoPhieu;
                        lichsuchungtu.YeuCauCat = true;

                        lichsuchungtu.CatNK_MaCN = dsct.CatNK_MaCN2;
                        lichsuchungtu.CatNK_DanhBo = dsct.CatNK_DanhBo2;
                        lichsuchungtu.CatNK_HoTen = dsct.CatNK_HoTen2;
                        lichsuchungtu.CatNK_DiaChi = dsct.CatNK_DiaChi2;
                        lichsuchungtu.SoNKNhan = dsct.CatNK_SoNKCat2;
                        lichsuchungtu.GhiChu = dsct.CatNK_GhiChu2;
                        lichsuchungtu.CatNK_MaCT = dsct.CatNK_MaCT2;
                        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            lichsuchungtu.ChucVu = "GIÁM ĐỐC";
                        else
                            lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        if (ThemLichSuChungTu(lichsuchungtu))
                        {
                            dsct.SoPhieu2 = lichsuchungtu.SoPhieu;
                            //CatChuyenDM catchuyendm = new CatChuyenDM();
                            //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
                            //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
                        }
                    }
                }
                else
                {
                    dsct.YeuCauCat2 = false;
                    if (dsct.SoPhieu2.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN = getLichSuChungTubySoPhieu(dsct.SoPhieu2.Value);
                        XoaLichSuChungTu(lichsuchungtuCN);
                    }
                }

                //if (ctchungtu.YeuCauCat3 != ctchungtuCN.YeuCauCat3)
                if (dsct.YeuCauCat3)
                {
                    dsct.YeuCauCat3 = true;
                    dsct.CatNK_MaCN3 = dsct.CatNK_MaCN3;
                    dsct.CatNK_DanhBo3 = dsct.CatNK_DanhBo3;
                    dsct.CatNK_HoTen3 = dsct.CatNK_HoTen3;
                    dsct.CatNK_DiaChi3 = dsct.CatNK_DiaChi3;
                    dsct.CatNK_SoNKCat3 = dsct.CatNK_SoNKCat3;
                    dsct.CatNK_GhiChu3 = dsct.CatNK_GhiChu3;
                    dsct.CatNK_MaCT3 = dsct.CatNK_MaCT3;
                    ///
                    if (dsct.SoPhieu3.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN3 = getLichSuChungTubySoPhieu(dsct.SoPhieu3.Value);
                        lichsuchungtuCN3.CatNK_MaCN = dsct.CatNK_MaCN3;
                        lichsuchungtuCN3.CatNK_DanhBo = dsct.CatNK_DanhBo3;
                        lichsuchungtuCN3.CatNK_HoTen = dsct.CatNK_HoTen3;
                        lichsuchungtuCN3.CatNK_DiaChi = dsct.CatNK_DiaChi3;
                        lichsuchungtuCN3.SoNKNhan = dsct.CatNK_SoNKCat3;
                        lichsuchungtuCN3.GhiChu = dsct.CatNK_GhiChu3;
                        lichsuchungtuCN3.CatNK_MaCT = dsct.CatNK_MaCT3;
                        if (SuaLichSuChungTu(lichsuchungtuCN3))
                        {
                            //CatChuyenDM catchuyendm = _cCatChuyenDM.getCatChuyenDMbySoPhieu(ctchungtuCN.SoPhieu3.Value);
                            //catchuyendm.CatNK_MaCN = lichsuchungtuCN3.CatNK_MaCN;
                            //catchuyendm.CatNK_DanhBo = lichsuchungtuCN3.CatNK_DanhBo;
                            //catchuyendm.CatNK_HoTen = lichsuchungtuCN3.CatNK_HoTen;
                            //catchuyendm.CatNK_DiaChi = lichsuchungtuCN3.CatNK_DiaChi;
                            //catchuyendm.SoNKNhan = lichsuchungtuCN3.SoNKNhan;

                            //_cCatChuyenDM.SuaCatChuyemDM(catchuyendm);
                        }
                    }
                    else
                    {
                        lichsuchungtu.MaCT = dsct.MaCT;
                        lichsuchungtu.DanhBo = dsct.DanhBo;
                        lichsuchungtu.SoNKTong = dsct.SoNKTong;
                        lichsuchungtu.SoNKDangKy = dsct.SoNKDangKy;
                        lichsuchungtu.ThoiHan = dsct.ThoiHan;
                        lichsuchungtu.NgayHetHan = dsct.NgayHetHan;
                        ///
                        lichsuchungtu.SoPhieu = getMaxNextSoPhieuLSCT();
                        //ctchungtuCN.SoPhieu3 = lichsuchungtu.SoPhieu;
                        lichsuchungtu.YeuCauCat = true;

                        lichsuchungtu.CatNK_MaCN = dsct.CatNK_MaCN3;
                        lichsuchungtu.CatNK_DanhBo = dsct.CatNK_DanhBo3;
                        lichsuchungtu.CatNK_HoTen = dsct.CatNK_HoTen3;
                        lichsuchungtu.CatNK_DiaChi = dsct.CatNK_DiaChi3;
                        lichsuchungtu.SoNKNhan = dsct.CatNK_SoNKCat3;
                        lichsuchungtu.GhiChu = dsct.CatNK_GhiChu3;
                        lichsuchungtu.CatNK_MaCT = dsct.CatNK_MaCT3;
                        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            lichsuchungtu.ChucVu = "GIÁM ĐỐC";
                        else
                            lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        if (ThemLichSuChungTu(lichsuchungtu))
                        {
                            dsct.SoPhieu3 = lichsuchungtu.SoPhieu;
                            //CatChuyenDM catchuyendm = new CatChuyenDM();
                            //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
                            //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
                        }
                    }
                }
                else
                {
                    dsct.YeuCauCat3 = false;
                    if (dsct.SoPhieu3.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN = getLichSuChungTubySoPhieu(dsct.SoPhieu3.Value);
                        XoaLichSuChungTu(lichsuchungtuCN);
                    }
                }

                //if (ctchungtu.YeuCauCat4 != ctchungtuCN.YeuCauCat4)
                if (dsct.YeuCauCat4)
                {
                    dsct.YeuCauCat4 = true;
                    dsct.CatNK_MaCN4 = dsct.CatNK_MaCN4;
                    dsct.CatNK_DanhBo4 = dsct.CatNK_DanhBo4;
                    dsct.CatNK_HoTen4 = dsct.CatNK_HoTen4;
                    dsct.CatNK_DiaChi4 = dsct.CatNK_DiaChi4;
                    dsct.CatNK_SoNKCat4 = dsct.CatNK_SoNKCat4;
                    dsct.CatNK_GhiChu4 = dsct.CatNK_GhiChu4;
                    dsct.CatNK_MaCT4 = dsct.CatNK_MaCT4;
                    ///
                    if (dsct.SoPhieu4.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN4 = getLichSuChungTubySoPhieu(dsct.SoPhieu4.Value);
                        lichsuchungtuCN4.CatNK_MaCN = dsct.CatNK_MaCN4;
                        lichsuchungtuCN4.CatNK_DanhBo = dsct.CatNK_DanhBo4;
                        lichsuchungtuCN4.CatNK_HoTen = dsct.CatNK_HoTen4;
                        lichsuchungtuCN4.CatNK_DiaChi = dsct.CatNK_DiaChi4;
                        lichsuchungtuCN4.SoNKNhan = dsct.CatNK_SoNKCat4;
                        lichsuchungtuCN4.GhiChu = dsct.CatNK_GhiChu4;
                        lichsuchungtuCN4.CatNK_MaCT = dsct.CatNK_MaCT4;
                        if (SuaLichSuChungTu(lichsuchungtuCN4))
                        {
                            //CatChuyenDM catchuyendm = _cCatChuyenDM.getCatChuyenDMbySoPhieu(ctchungtuCN.SoPhieu4.Value);
                            //catchuyendm.CatNK_MaCN = lichsuchungtuCN4.CatNK_MaCN;
                            //catchuyendm.CatNK_DanhBo = lichsuchungtuCN4.CatNK_DanhBo;
                            //catchuyendm.CatNK_HoTen = lichsuchungtuCN4.CatNK_HoTen;
                            //catchuyendm.CatNK_DiaChi = lichsuchungtuCN4.CatNK_DiaChi;
                            //catchuyendm.SoNKNhan = lichsuchungtuCN4.SoNKNhan;

                            //_cCatChuyenDM.SuaCatChuyemDM(catchuyendm);
                        }
                    }
                    else
                    {
                        lichsuchungtu.MaCT = dsct.MaCT;
                        lichsuchungtu.DanhBo = dsct.DanhBo;
                        lichsuchungtu.SoNKTong = dsct.SoNKTong;
                        lichsuchungtu.SoNKDangKy = dsct.SoNKDangKy;
                        lichsuchungtu.ThoiHan = dsct.ThoiHan;
                        lichsuchungtu.NgayHetHan = dsct.NgayHetHan;
                        ///
                        lichsuchungtu.SoPhieu = getMaxNextSoPhieuLSCT();
                        //ctchungtuCN.SoPhieu4 = lichsuchungtu.SoPhieu;
                        lichsuchungtu.YeuCauCat = true;

                        lichsuchungtu.CatNK_MaCN = dsct.CatNK_MaCN4;
                        lichsuchungtu.CatNK_DanhBo = dsct.CatNK_DanhBo4;
                        lichsuchungtu.CatNK_HoTen = dsct.CatNK_HoTen4;
                        lichsuchungtu.CatNK_DiaChi = dsct.CatNK_DiaChi4;
                        lichsuchungtu.SoNKNhan = dsct.CatNK_SoNKCat4;
                        lichsuchungtu.GhiChu = dsct.CatNK_GhiChu4;
                        lichsuchungtu.CatNK_MaCT = dsct.CatNK_MaCT4;
                        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            lichsuchungtu.ChucVu = "GIÁM ĐỐC";
                        else
                            lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        if (ThemLichSuChungTu(lichsuchungtu))
                        {
                            dsct.SoPhieu4 = lichsuchungtu.SoPhieu;
                            //CatChuyenDM catchuyendm = new CatChuyenDM();
                            //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
                            //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
                        }
                    }
                }
                else
                {
                    dsct.YeuCauCat4 = false;
                    if (dsct.SoPhieu4.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN = getLichSuChungTubySoPhieu(dsct.SoPhieu4.Value);
                        XoaLichSuChungTu(lichsuchungtuCN);
                    }
                }

                //if (ctchungtu.YeuCauCat5 != ctchungtuCN.YeuCauCat5)
                if (dsct.YeuCauCat5)
                {
                    dsct.YeuCauCat5 = true;
                    dsct.CatNK_MaCN5 = dsct.CatNK_MaCN5;
                    dsct.CatNK_DanhBo5 = dsct.CatNK_DanhBo5;
                    dsct.CatNK_HoTen5 = dsct.CatNK_HoTen5;
                    dsct.CatNK_DiaChi5 = dsct.CatNK_DiaChi5;
                    dsct.CatNK_SoNKCat5 = dsct.CatNK_SoNKCat5;
                    dsct.CatNK_GhiChu5 = dsct.CatNK_GhiChu5;
                    dsct.CatNK_MaCT5 = dsct.CatNK_MaCT5;
                    ///
                    if (dsct.SoPhieu5.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN5 = getLichSuChungTubySoPhieu(dsct.SoPhieu5.Value);
                        lichsuchungtuCN5.CatNK_MaCN = dsct.CatNK_MaCN5;
                        lichsuchungtuCN5.CatNK_DanhBo = dsct.CatNK_DanhBo5;
                        lichsuchungtuCN5.CatNK_HoTen = dsct.CatNK_HoTen5;
                        lichsuchungtuCN5.CatNK_DiaChi = dsct.CatNK_DiaChi5;
                        lichsuchungtuCN5.SoNKNhan = dsct.CatNK_SoNKCat5;
                        lichsuchungtuCN5.GhiChu = dsct.CatNK_GhiChu5;
                        lichsuchungtuCN5.CatNK_MaCT = dsct.CatNK_MaCT5;
                        if (SuaLichSuChungTu(lichsuchungtuCN5))
                        {
                            //CatChuyenDM catchuyendm = _cCatChuyenDM.getCatChuyenDMbySoPhieu(ctchungtuCN.SoPhieu5.Value);
                            //catchuyendm.CatNK_MaCN = lichsuchungtuCN5.CatNK_MaCN;
                            //catchuyendm.CatNK_DanhBo = lichsuchungtuCN5.CatNK_DanhBo;
                            //catchuyendm.CatNK_HoTen = lichsuchungtuCN5.CatNK_HoTen;
                            //catchuyendm.CatNK_DiaChi = lichsuchungtuCN5.CatNK_DiaChi;
                            //catchuyendm.SoNKNhan = lichsuchungtuCN5.SoNKNhan;

                            //_cCatChuyenDM.SuaCatChuyemDM(catchuyendm);
                        }
                    }
                    else
                    {
                        lichsuchungtu.MaCT = dsct.MaCT;
                        lichsuchungtu.DanhBo = dsct.DanhBo;
                        lichsuchungtu.SoNKTong = dsct.SoNKTong;
                        lichsuchungtu.SoNKDangKy = dsct.SoNKDangKy;
                        lichsuchungtu.ThoiHan = dsct.ThoiHan;
                        lichsuchungtu.NgayHetHan = dsct.NgayHetHan;
                        ///
                        lichsuchungtu.SoPhieu = getMaxNextSoPhieuLSCT();
                        //ctchungtuCN.SoPhieu5 = lichsuchungtu.SoPhieu;
                        lichsuchungtu.YeuCauCat = true;

                        lichsuchungtu.CatNK_MaCN = dsct.CatNK_MaCN5;
                        lichsuchungtu.CatNK_DanhBo = dsct.CatNK_DanhBo5;
                        lichsuchungtu.CatNK_HoTen = dsct.CatNK_HoTen5;
                        lichsuchungtu.CatNK_DiaChi = dsct.CatNK_DiaChi5;
                        lichsuchungtu.SoNKNhan = dsct.CatNK_SoNKCat5;
                        lichsuchungtu.GhiChu = dsct.CatNK_GhiChu5;
                        lichsuchungtu.CatNK_MaCT = dsct.CatNK_MaCT5;
                        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            lichsuchungtu.ChucVu = "GIÁM ĐỐC";
                        else
                            lichsuchungtu.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        lichsuchungtu.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        if (ThemLichSuChungTu(lichsuchungtu))
                        {
                            dsct.SoPhieu5 = lichsuchungtu.SoPhieu;
                            //CatChuyenDM catchuyendm = new CatChuyenDM();
                            //LSCTtoCCDM(lichsuchungtu, ref catchuyendm);
                            //_cCatChuyenDM.ThemCatChuyenDM(catchuyendm);
                        }
                    }
                }
                else
                {
                    dsct.YeuCauCat5 = false;
                    if (dsct.SoPhieu5.HasValue)
                    {
                        LichSuChungTu lichsuchungtuCN = getLichSuChungTubySoPhieu(dsct.SoPhieu5.Value);
                        XoaLichSuChungTu(lichsuchungtuCN);
                    }
                }

                #endregion

                db.SubmitChanges();
                db.Transaction.Commit();
                //MessageBox.Show("Thành công Sửa ChungTu Method", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbChungCuDataContext();
                return false;
            }
        }

        public bool SuaChungTu_ThongTin(ChungTu chungtu, CTChungTu ctchungtu, LichSuChungTu lichsuchungtu)
        {
            try
            {
                if (db.Connection.State == System.Data.ConnectionState.Closed)
                    db.Connection.Open();
                db.Transaction = db.Connection.BeginTransaction();

                bool flagEdited = false;
                bool flagGiam = false;
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
                        chungtuCN.SoNKConLai = chungtu.SoNKTong;
                        chungtuCN.SoNKTong = chungtu.SoNKTong;
                        chungtuCN.ModifyDate = DateTime.Now;
                        flagEdited = true;
                        flagGiam = true;
                        //MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //return false;
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
                }

                ///Cập Nhật bảng CTChungTu khi thay đổi Số Nhân Khẩu đăng ký (frmSoDK)
                CTChungTu ctchungtuCN = getCTChungTubyID(ctchungtu.DanhBo, ctchungtu.MaCT);
                ///Kiểm tra Số Nhân Khẩu đăng ký có thay đổi hay không
                if (ctchungtuCN.SoNKDangKy != ctchungtu.SoNKDangKy)
                    if (flagGiam)
                    {
                        ///Cập nhật Số Nhân Khẩu Cấp cho bảng ChungTu
                        chungtuCN.SoNKConLai = chungtuCN.SoNKConLai - ctchungtu.SoNKDangKy;
                        chungtuCN.SoNKDaCap = ctchungtu.SoNKDangKy;
                        chungtuCN.ModifyDate = DateTime.Now;
                        ///Cập nhật bảng CTChungTu
                        ctchungtuCN.SoNKDangKy = ctchungtu.SoNKDangKy;
                        ctchungtuCN.ModifyDate = DateTime.Now;
                        flagEdited = true;
                    }
                    else
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
                            flagEdited = true;
                        }
                        else
                        {
                            MessageBox.Show("Sổ Đăng Ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                if (ctchungtuCN.STT != ctchungtu.STT || ctchungtuCN.ThoiHan != ctchungtu.ThoiHan || ctchungtuCN.Lo != ctchungtu.Lo || ctchungtuCN.Phong != ctchungtu.Phong || ctchungtuCN.GhiChu != ctchungtu.GhiChu || (ctchungtuCN.NgayHetHan != ctchungtu.NgayHetHan && ctchungtu.NgayHetHan != null))
                {
                    if (ctchungtuCN.ThoiHan != ctchungtu.ThoiHan)
                    {
                        ctchungtuCN.ThoiHan = ctchungtu.ThoiHan;
                        if (ctchungtu.ThoiHan != null)
                        {
                            ///Cập nhật ngày hết hạn dựa vào ngày tạo record này(ngày nhận đơn)
                            ///Khi gia hạn refresh lại ngày tạo để tính ngày gia hạn
                            ctchungtuCN.CreateDate = DateTime.Now;
                            ctchungtuCN.NgayHetHan = ctchungtuCN.CreateDate.Value.AddMonths(ctchungtu.ThoiHan.Value);
                        }
                        else
                            ctchungtuCN.NgayHetHan = null;
                        flagEdited = true;
                    }
                    if (ctchungtu.NgayHetHan != null)
                    {
                        ctchungtuCN.CreateDate = DateTime.Now;
                        ctchungtuCN.NgayHetHan = ctchungtu.NgayHetHan;
                        flagEdited = true;
                    }
                    if (ctchungtuCN.STT != ctchungtu.STT)
                        ctchungtuCN.STT = ctchungtu.STT;
                    if (ctchungtuCN.Lo != ctchungtu.Lo)
                        ctchungtuCN.Lo = ctchungtu.Lo;
                    if (ctchungtuCN.Phong != ctchungtu.Phong)
                        ctchungtuCN.Phong = ctchungtu.Phong;
                    if (ctchungtuCN.GhiChu != ctchungtu.GhiChu)
                        ctchungtuCN.GhiChu = ctchungtu.GhiChu;
                    ctchungtuCN.ModifyDate = DateTime.Now;

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
                db.Transaction.Commit();
                //MessageBox.Show("Thành công Sửa ChungTu Method", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                db.Transaction.Rollback();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbChungCuDataContext();
                return false;
            }
        }

        public bool XoaChungTu(string DanhBo, string MaCT)
        {
            try
            {
                ChungTu chungtuCN = getChungTubyID(MaCT);
                CTChungTu ctchungtuCN = getCTChungTubyID(DanhBo,MaCT);

                chungtuCN.SoNKConLai += ctchungtuCN.SoNKDangKy;
                db.CTChungTus.DeleteOnSubmit(ctchungtuCN);
                db.SubmitChanges();
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
                    lichsuchungtu.MaLSCT = decimal.Parse("1" + DateTime.Now.ToString("yy"));
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
                                    itemLSCT.STT,
                                    itemLSCT.Lo,
                                    itemLSCT.Phong,
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
                                    itemLSCT.GhiChu,
                                    itemLSCT.CatNK_MaCT,
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
                                    itemLSCT.STT,
                                    itemLSCT.Lo,
                                    itemLSCT.Phong,
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
                                    itemLSCT.GhiChu,
                                    itemLSCT.CatNK_MaCT,
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
                                    itemLSCT.STT,
                                    itemLSCT.Lo,
                                    itemLSCT.Phong,
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
                                    itemLSCT.GhiChu,
                                    itemLSCT.CatNK_MaCT,
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

        public DataTable LoadDSCatChuyenDMBySTT(string DanhBo,string Lo,int STT)
        {
            //string a = "";
            try
            {
                var query = from itemLSCT in db.LichSuChungTus
                            //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                            where itemLSCT.SoPhieu != null && itemLSCT.DanhBo == DanhBo && itemLSCT.STT==STT && itemLSCT.Lo==Lo
                            //where itemLSCT.MaLSCT == 126114
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.STT,
                                itemLSCT.Lo,
                                itemLSCT.Phong,
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
                                itemLSCT.GhiChu,
                                itemLSCT.CatNK_MaCT,
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

        public DataTable LoadDSCatChuyenDMBySTTs(string DanhBo, string Lo,int TuSTT,int DenSTT)
        {
            //string a = "";
            try
            {
                var query = from itemLSCT in db.LichSuChungTus
                            //join itemDCBD in db.DCBDs on itemLSCT.MaDon equals itemDCBD.MaDon
                            where itemLSCT.SoPhieu != null && itemLSCT.DanhBo == DanhBo && itemLSCT.STT >= TuSTT && itemLSCT.STT <= DenSTT && itemLSCT.Lo==Lo
                            //where itemLSCT.MaLSCT == 126114
                            orderby itemLSCT.CreateDate ascending
                            select new
                            {
                                itemLSCT.STT,
                                itemLSCT.Lo,
                                itemLSCT.Phong,
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
                                itemLSCT.GhiChu,
                                itemLSCT.CatNK_MaCT,
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
                                    itemLSCT.STT,
                                    itemLSCT.Lo,
                                    itemLSCT.Phong,
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
                                    itemLSCT.GhiChu,
                                    itemLSCT.CatNK_MaCT,
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
                                    itemLSCT.STT,
                                    itemLSCT.Lo,
                                    itemLSCT.Phong,
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
                                    itemLSCT.GhiChu,
                                    itemLSCT.CatNK_MaCT,
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

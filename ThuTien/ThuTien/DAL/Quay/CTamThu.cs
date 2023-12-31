using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.Quay
{
    class CTamThu : CDAL
    {
        public bool Them(TAMTHU tamthu)
        {
            try
            {
                if (_db.TAMTHUs.Count() > 0)
                    tamthu.ID_TAMTHU = _db.TAMTHUs.Max(item => item.ID_TAMTHU) + 1;
                else
                    tamthu.ID_TAMTHU = 1;
                tamthu.CreateDate = DateTime.Now;
                tamthu.CreateBy = CNguoiDung.MaND;
                _db.TAMTHUs.InsertOnSubmit(tamthu);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Them(TAMTHU tamthu, DateTime CreateDate)
        {
            try
            {
                if (_db.TAMTHUs.Count() > 0)
                    tamthu.ID_TAMTHU = _db.TAMTHUs.Max(item => item.ID_TAMTHU) + 1;
                else
                    tamthu.ID_TAMTHU = 1;
                tamthu.CreateDate = CreateDate;
                tamthu.CreateBy = CNguoiDung.MaND;
                _db.TAMTHUs.InsertOnSubmit(tamthu);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(TAMTHU tamthu)
        {
            try
            {
                tamthu.ModifyDate = DateTime.Now;
                tamthu.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(TAMTHU tamthu)
        {
            try
            {
                _db.TAMTHUs.DeleteOnSubmit(tamthu);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaAn(string SoHoaDon)
        {
            try
            {
                string sql = "";
                sql = "update TAMTHU set Xoa=1 where Xoa=0 and SoHoaDon='" + SoHoaDon + "'";
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(string SoHoaDon, out bool ChuyenKhoan)
        {
            if (_db.TAMTHUs.Any(item => item.SoHoaDon == SoHoaDon))
                ChuyenKhoan = _db.TAMTHUs.SingleOrDefault(item => item.SoHoaDon == SoHoaDon).ChuyenKhoan;
            else
                ChuyenKhoan = false;
            return _db.TAMTHUs.Any(item => item.SoHoaDon == SoHoaDon);
        }

        public bool CheckExist(int MaHD, out bool ChuyenKhoan)
        {
            if (_db.TAMTHUs.Any(item => item.FK_HOADON == MaHD))
                ChuyenKhoan = _db.TAMTHUs.SingleOrDefault(item => item.FK_HOADON == MaHD).ChuyenKhoan;
            else
                ChuyenKhoan = false;
            return _db.TAMTHUs.Any(item => item.FK_HOADON == MaHD);
        }

        public bool CheckExist(string SoHoaDon, out string Loai)
        {
            Loai = "";
            if (_db.TAMTHUs.Any(item => item.SoHoaDon == SoHoaDon))
            {
                if (_db.TAMTHUs.SingleOrDefault(item => item.SoHoaDon == SoHoaDon).ChuyenKhoan)
                    Loai = "Chuyển Khoản, ngày " + _db.TAMTHUs.SingleOrDefault(item => item.SoHoaDon == SoHoaDon).CreateDate.Value.ToString("dd/MM/yyyy");
                else
                    Loai = "Quầy, ngày " + _db.TAMTHUs.SingleOrDefault(item => item.SoHoaDon == SoHoaDon).CreateDate.Value.ToString("dd/MM/yyyy");
                return true;
            }
            else
                return false;
        }

        public bool CheckExist(int MaHD, out string Loai)
        {
            Loai = "";
            if (_db.TAMTHUs.Any(item => item.FK_HOADON == MaHD))
            {
                if (_db.TAMTHUs.SingleOrDefault(item => item.FK_HOADON == MaHD).ChuyenKhoan)
                    Loai = "Chuyển Khoản, ngày " + _db.TAMTHUs.SingleOrDefault(item => item.FK_HOADON == MaHD).CreateDate.Value.ToString("dd/MM/yyyy");
                else
                    Loai = "Quầy, ngày " + _db.TAMTHUs.SingleOrDefault(item => item.FK_HOADON == MaHD).CreateDate.Value.ToString("dd/MM/yyyy");
                return true;
            }
            else
                return false;
        }

        public bool CheckExist(string SoHoaDon, bool ChuyenKhoan)
        {
            return _db.TAMTHUs.Any(item => item.SoHoaDon == SoHoaDon && item.ChuyenKhoan == ChuyenKhoan);
        }

        public bool CheckExist(int MaHD, bool ChuyenKhoan)
        {
            return _db.TAMTHUs.Any(item => item.FK_HOADON == MaHD && item.ChuyenKhoan == ChuyenKhoan);
        }

        public bool CheckExist(string SoHoaDon)
        {
            return _db.TAMTHUs.Any(item => item.SoHoaDon == SoHoaDon);
        }

        public bool CheckExist_Quay(string SoHoaDon)
        {
            return _db.TAMTHUs.Any(item => item.SoHoaDon == SoHoaDon && item.ChuyenKhoan == false);
        }

        public DataTable getDS_Quay(bool HDDT, bool ChuyenKhoan, DateTime TuNgay, DateTime DenNgay)
        {
            if (HDDT == false)
            {
                var query = from itemTT in _db.TAMTHUs
                            join itemHD in _db.HOADONs on itemTT.FK_HOADON equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            //join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                            //from itemtableDN in tableDN.DefaultIfEmpty()
                            join itemNH in _db.NGANHANGs on itemTT.MaNH equals itemNH.ID_NGANHANG into tableNH
                            from itemtableNH in tableNH.DefaultIfEmpty()
                            where itemTT.CreateDate.Value.Date >= TuNgay.Date && itemTT.CreateDate.Value.Date <= DenNgay.Date && itemTT.ChuyenKhoan == ChuyenKhoan
                            && (itemHD.NAM < 2020 || (itemHD.NAM == 2020 && itemHD.KY < 7))
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                MaTT = itemTT.ID_TAMTHU,
                                MaHD = itemHD.ID_HOADON,
                                itemTT.SoPhieu,
                                itemHD.NGAYGIAITRACH,
                                itemTT.CreateDate,
                                itemHD.SOHOADON,
                                itemHD.SOPHATHANH,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                itemHD.TIEUTHU,
                                itemHD.GIABAN,
                                ThueGTGT = itemHD.THUE,
                                PhiBVMT = itemHD.PHI,
                                itemHD.TONGCONG,
                                HanhThu = itemtableND.HoTen,
                                To = itemtableND.TT_To.TenTo,
                                //HanhThu = _db.TT_CTDongNuocs.Any(item => item.MaHD == itemHD.ID_HOADON && item.TT_DongNuoc.Huy == false && item.TT_DongNuoc.MaNV_DongNuoc != null) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemA => itemA.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.MaHD == itemHD.ID_HOADON && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
                                //To = _db.TT_CTDongNuocs.Any(item => item.MaHD == itemHD.ID_HOADON && item.TT_DongNuoc.Huy == false && item.TT_DongNuoc.MaNV_DongNuoc != null) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemA => itemA.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.MaHD == itemHD.ID_HOADON && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
                                itemTT.MaNH,
                                TenNH = itemtableNH.NGANHANG1,
                                GiaBieu = itemHD.GB,
                                itemTT.TienDu,
                                itemTT.Tra,
                                itemTT.NgayTra,
                                itemTT.GhiChuTra,
                                //DangNgan = itemtableDN.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
            {
                var query2 = from itemTT in _db.TAMTHUs
                             join itemHD in _db.HOADONs on itemTT.FK_HOADON equals itemHD.ID_HOADON
                             join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                             from itemtableND in tableND.DefaultIfEmpty()
                             //join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                             //from itemtableDN in tableDN.DefaultIfEmpty()
                             join itemNH in _db.NGANHANGs on itemTT.MaNH equals itemNH.ID_NGANHANG into tableNH
                             from itemtableNH in tableNH.DefaultIfEmpty()
                             where itemTT.CreateDate.Value.Date >= TuNgay.Date && itemTT.CreateDate.Value.Date <= DenNgay.Date && itemTT.ChuyenKhoan == ChuyenKhoan
                              && (itemHD.NAM > 2020 || (itemHD.NAM == 2020 && itemHD.KY >= 7))
                             orderby itemHD.MALOTRINH ascending
                             select new
                             {
                                 MaTT = itemTT.ID_TAMTHU,
                                 MaHD = itemHD.ID_HOADON,
                                 itemTT.SoPhieu,
                                 itemHD.NGAYGIAITRACH,
                                 itemTT.CreateDate,
                                 itemHD.SOHOADON,
                                 itemHD.SOPHATHANH,
                                 Ky = itemHD.KY + "/" + itemHD.NAM,
                                 MLT = itemHD.MALOTRINH,
                                 DanhBo = itemHD.DANHBA,
                                 HoTen = itemHD.TENKH,
                                 DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                 itemHD.TIEUTHU,
                                 itemHD.GIABAN,
                                 ThueGTGT = itemHD.THUE,
                                 PhiBVMT = itemHD.PHI,
                                 itemHD.TONGCONG,
                                 HanhThu = itemtableND.HoTen,
                                 To = itemtableND.TT_To.TenTo,
                                 //HanhThu = _db.TT_CTDongNuocs.Any(item => item.MaHD == itemHD.ID_HOADON && item.TT_DongNuoc.Huy == false && item.TT_DongNuoc.MaNV_DongNuoc != null) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemA => itemA.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.MaHD == itemHD.ID_HOADON && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
                                 //To = _db.TT_CTDongNuocs.Any(item => item.MaHD == itemHD.ID_HOADON && item.TT_DongNuoc.Huy == false && item.TT_DongNuoc.MaNV_DongNuoc != null) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemA => itemA.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.MaHD == itemHD.ID_HOADON && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
                                 itemTT.MaNH,
                                 TenNH = itemtableNH.NGANHANG1,
                                 GiaBieu = itemHD.GB,
                                 itemTT.TienDu,
                                 itemTT.Tra,
                                 itemTT.NgayTra,
                                 itemTT.GhiChuTra,
                                 //DangNgan = itemtableDN.HoTen,
                             };
                return LINQToDataTable(query2);
            }
        }

        public DataTable getDS(bool HDDT, bool ChuyenKhoan, DateTime TuNgay, DateTime DenNgay, int FromDot, int ToDot)
        {
            if (HDDT == false)
            {
                var query = from itemTT in _db.TAMTHUs
                            join itemHD in _db.HOADONs on itemTT.FK_HOADON equals itemHD.ID_HOADON
                            join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                            from itemtableND in tableND.DefaultIfEmpty()
                            //join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                            //from itemtableDN in tableDN.DefaultIfEmpty()
                            join itemNH in _db.NGANHANGs on itemTT.MaNH equals itemNH.ID_NGANHANG into tableNH
                            from itemtableNH in tableNH.DefaultIfEmpty()
                            where itemTT.CreateDate.Value.Date >= TuNgay.Date && itemTT.CreateDate.Value.Date <= DenNgay.Date && itemTT.ChuyenKhoan == ChuyenKhoan
                            && (itemHD.NAM < 2020 || (itemHD.NAM == 2020 && itemHD.KY < 7)) && itemHD.DOT >= FromDot && itemHD.DOT <= ToDot
                            orderby itemHD.MALOTRINH ascending
                            select new
                            {
                                MaTT = itemTT.ID_TAMTHU,
                                MaHD = itemHD.ID_HOADON,
                                itemTT.SoPhieu,
                                itemHD.NGAYGIAITRACH,
                                itemTT.CreateDate,
                                itemHD.SOHOADON,
                                itemHD.SOPHATHANH,
                                Ky = itemHD.KY + "/" + itemHD.NAM,
                                MLT = itemHD.MALOTRINH,
                                DanhBo = itemHD.DANHBA,
                                HoTen = itemHD.TENKH,
                                DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                itemHD.TIEUTHU,
                                itemHD.GIABAN,
                                ThueGTGT = itemHD.THUE,
                                PhiBVMT = itemHD.PHI,
                                itemHD.TONGCONG,
                                HanhThu = itemtableND.HoTen,
                                To = itemtableND.TT_To.TenTo,
                                //HanhThu = _db.TT_CTDongNuocs.Any(item => item.MaHD == itemHD.ID_HOADON && item.TT_DongNuoc.Huy == false && item.TT_DongNuoc.MaNV_DongNuoc != null) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemA => itemA.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.MaHD == itemHD.ID_HOADON && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
                                //To = _db.TT_CTDongNuocs.Any(item => item.MaHD == itemHD.ID_HOADON && item.TT_DongNuoc.Huy == false && item.TT_DongNuoc.MaNV_DongNuoc != null) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemA => itemA.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.MaHD == itemHD.ID_HOADON && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
                                itemTT.MaNH,
                                TenNH = itemtableNH.NGANHANG1,
                                GiaBieu = itemHD.GB,
                                itemTT.TienDu,
                                itemTT.Tra,
                                itemTT.NgayTra,
                                itemTT.GhiChuTra,
                                //DangNgan = itemtableDN.HoTen,
                            };
                return LINQToDataTable(query);
            }
            else
            {
                var query2 = from itemTT in _db.TAMTHUs
                             join itemHD in _db.HOADONs on itemTT.FK_HOADON equals itemHD.ID_HOADON
                             join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                             from itemtableND in tableND.DefaultIfEmpty()
                             //join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                             //from itemtableDN in tableDN.DefaultIfEmpty()
                             join itemNH in _db.NGANHANGs on itemTT.MaNH equals itemNH.ID_NGANHANG into tableNH
                             from itemtableNH in tableNH.DefaultIfEmpty()
                             where itemTT.CreateDate.Value.Date >= TuNgay.Date && itemTT.CreateDate.Value.Date <= DenNgay.Date && itemTT.ChuyenKhoan == ChuyenKhoan
                              && (itemHD.NAM > 2020 || (itemHD.NAM == 2020 && itemHD.KY >= 7)) && itemHD.DOT >= FromDot && itemHD.DOT <= ToDot
                             orderby itemHD.MALOTRINH ascending
                             select new
                             {
                                 MaTT = itemTT.ID_TAMTHU,
                                 MaHD = itemHD.ID_HOADON,
                                 itemTT.SoPhieu,
                                 itemHD.NGAYGIAITRACH,
                                 itemTT.CreateDate,
                                 itemHD.SOHOADON,
                                 itemHD.SOPHATHANH,
                                 Ky = itemHD.KY + "/" + itemHD.NAM,
                                 MLT = itemHD.MALOTRINH,
                                 DanhBo = itemHD.DANHBA,
                                 HoTen = itemHD.TENKH,
                                 DiaChi = itemHD.SO + " " + itemHD.DUONG,
                                 itemHD.TIEUTHU,
                                 itemHD.GIABAN,
                                 ThueGTGT = itemHD.THUE,
                                 PhiBVMT = itemHD.PHI,
                                 itemHD.TONGCONG,
                                 HanhThu = itemtableND.HoTen,
                                 To = itemtableND.TT_To.TenTo,
                                 //HanhThu = _db.TT_CTDongNuocs.Any(item => item.MaHD == itemHD.ID_HOADON && item.TT_DongNuoc.Huy == false && item.TT_DongNuoc.MaNV_DongNuoc != null) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemA => itemA.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.MaHD == itemHD.ID_HOADON && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).HoTen : itemtableND.HoTen,
                                 //To = _db.TT_CTDongNuocs.Any(item => item.MaHD == itemHD.ID_HOADON && item.TT_DongNuoc.Huy == false && item.TT_DongNuoc.MaNV_DongNuoc != null) == true ? _db.TT_NguoiDungs.SingleOrDefault(itemA => itemA.MaND == _db.TT_CTDongNuocs.SingleOrDefault(item => item.MaHD == itemHD.ID_HOADON && item.TT_DongNuoc.Huy == false).TT_DongNuoc.MaNV_DongNuoc).TT_To.TenTo : itemtableND.TT_To.TenTo,
                                 itemTT.MaNH,
                                 TenNH = itemtableNH.NGANHANG1,
                                 GiaBieu = itemHD.GB,
                                 itemTT.TienDu,
                                 itemTT.Tra,
                                 itemTT.NgayTra,
                                 itemTT.GhiChuTra,
                                 //DangNgan = itemtableDN.HoTen,
                             };
                return LINQToDataTable(query2);
            }
        }

        public DataTable GetDS(bool ChuyenKhoan, string DanhBo)
        {
            var query = from itemTT in _db.TAMTHUs
                        join itemHD in _db.HOADONs on itemTT.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemNH in _db.NGANHANGs on itemTT.MaNH equals itemNH.ID_NGANHANG into tableNH
                        from itemtableNH in tableNH.DefaultIfEmpty()
                        where itemTT.Xoa == false && itemTT.DANHBA == DanhBo && itemTT.ChuyenKhoan == ChuyenKhoan
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            MaTT = itemTT.ID_TAMTHU,
                            itemTT.SoPhieu,
                            itemHD.NGAYGIAITRACH,
                            itemTT.CreateDate,
                            itemHD.SOHOADON,
                            itemHD.SOPHATHANH,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            itemTT.MaNH,
                            TenNH = itemtableNH.NGANHANG1,
                            GiaBieu = itemHD.GB,
                            itemTT.TienDu,
                            itemTT.Tra,
                            itemTT.NgayTra,
                            itemTT.GhiChuTra,
                            Ky2 = itemHD.KY,
                            itemHD.NAM,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDS(bool ChuyenKhoan, string DanhBo, DateTime TuNgay, DateTime DenNgay)
        {
            var query = from itemTT in _db.TAMTHUs
                        join itemHD in _db.HOADONs on itemTT.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemNH in _db.NGANHANGs on itemTT.MaNH equals itemNH.ID_NGANHANG into tableNH
                        from itemtableNH in tableNH.DefaultIfEmpty()
                        where itemTT.CreateDate.Value.Date >= TuNgay.Date && itemTT.CreateDate.Value.Date <= DenNgay.Date && itemTT.Xoa == false && itemTT.DANHBA == DanhBo && itemTT.ChuyenKhoan == ChuyenKhoan
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            MaTT = itemTT.ID_TAMTHU,
                            itemTT.SoPhieu,
                            itemHD.NGAYGIAITRACH,
                            itemTT.CreateDate,
                            itemHD.SOHOADON,
                            itemHD.SOPHATHANH,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TIEUTHU,
                            itemHD.GIABAN,
                            ThueGTGT = itemHD.THUE,
                            PhiBVMT = itemHD.PHI,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            itemTT.MaNH,
                            TenNH = itemtableNH.NGANHANG1,
                            GiaBieu = itemHD.GB,
                            itemTT.TienDu,
                            itemTT.Tra,
                            itemTT.NgayTra,
                            itemTT.GhiChuTra,
                            Ky2 = itemHD.KY,
                            itemHD.NAM,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTon(bool ChuyenKhoan)
        {
            var query = from itemTT in _db.TAMTHUs
                        join itemHD in _db.HOADONs on itemTT.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemTT.Xoa == false && itemTT.ChuyenKhoan == ChuyenKhoan && itemHD.NGAYGIAITRACH == null
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemTT.CreateDate,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSTon_KyMoi(bool ChuyenKhoan)
        {
            var query = from itemTT in _db.TAMTHUs
                        join itemHD in _db.HOADONs on itemTT.FK_HOADON equals itemHD.ID_HOADON
                        where itemTT.Xoa == false && itemTT.ChuyenKhoan == ChuyenKhoan && itemHD.NGAYGIAITRACH == null
                        && itemHD.KY == DateTime.Now.Month && itemHD.NAM == DateTime.Now.Year
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            MaHD = itemHD.ID_HOADON,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            DanhBo = itemHD.DANHBA,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTon(int MaTo, bool ChuyenKhoan)
        {
            var query = from itemTT in _db.TAMTHUs
                        join itemHD in _db.HOADONs on itemTT.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemTT.Xoa == false && itemTT.ChuyenKhoan == ChuyenKhoan && itemHD.NGAYGIAITRACH == null
                        && Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemTT.CreateDate,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            itemHD.TONGCONG,
                            HanhThu = itemtableND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable getDSSaiSot_ChuyenKhoan(DateTime FromCreateDate, DateTime ToCreateDate, int FromDot, int ToDot)
        {
            //return ExecuteQuery_DataTable("select DanhBo=DANHBA,SLTamThu=COUNT(DANHBA),SLTon=(select SoLuong=COUNT(DANHBA) from HOADON where (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(NGAYGIAITRACH as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "')) and DANHBA=TAMTHU.DANHBA group by DANHBA)"
            //        + " from TAMTHU where CAST(CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and ChuyenKhoan=1"
            //        + " group by DANHBA"
            //        + " having COUNT(DANHBA)!=(select SoLuong=COUNT(DANHBA) from HOADON where (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(NGAYGIAITRACH as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "')) and DANHBA=TAMTHU.DANHBA group by DANHBA)");
            return ExecuteQuery_DataTable("select DanhBo=tt.DANHBA,SLTamThu=COUNT(tt.DANHBA),SLTon=(select SoLuong=COUNT(DANHBA) from HOADON where (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(NGAYGIAITRACH as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "')) and DANHBA=tt.DANHBA group by DANHBA)"
                     + " from TAMTHU tt,HOADON hd where CAST(tt.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(tt.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and ChuyenKhoan=1"
                     + " and tt.FK_HOADON=hd.ID_HOADON and hd.DOT>=" + FromDot + " and hd.DOT<=" + ToDot
                     + " group by tt.DANHBA"
                     + " having COUNT(tt.DANHBA)!=(select SoLuong=COUNT(DANHBA) from HOADON where (NGAYGIAITRACH is null or (CAST(NGAYGIAITRACH as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(NGAYGIAITRACH as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "')) and DANHBA=tt.DANHBA group by DANHBA)");
        }

        public List<TAMTHU> GetDSBySoPhieu(decimal SoPhieu)
        {
            return _db.TAMTHUs.Where(item => item.SoPhieu == SoPhieu).ToList();
        }

        public TAMTHU GetByMaTT(int MaTT)
        {
            return _db.TAMTHUs.SingleOrDefault(item => item.ID_TAMTHU == MaTT);
        }

        public decimal GetMaxSoPhieu()
        {
            if (_db.TAMTHUs.Max(item => item.SoPhieu) == null)
            {
                return decimal.Parse("1" + DateTime.Now.ToString("yy"));
            }
            else
            {
                string ID = "SoPhieu";
                string Table = "TAMTHU";
                decimal SoPhieu = _db.ExecuteQuery<decimal>("declare @Ma int " +
                    "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                    "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                return getMaxNextIDTable(SoPhieu);
            }
        }

        public string GetTenNganHang(string SoHoaDon)
        {
            if (_db.TAMTHUs.Any(itemTT => itemTT.SoHoaDon == SoHoaDon && itemTT.MaNH != null))
                return _db.NGANHANGs.SingleOrDefault(item => item.ID_NGANHANG == _db.TAMTHUs.SingleOrDefault(itemTT => itemTT.SoHoaDon == SoHoaDon && itemTT.MaNH != null).MaNH).NGANHANG1;
            else
                return "";
        }
    }
}

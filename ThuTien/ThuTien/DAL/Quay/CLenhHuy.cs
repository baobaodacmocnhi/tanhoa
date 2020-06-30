using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.Quay
{
    class CLenhHuy : CDAL
    {
        public bool Them(TT_LenhHuy lenhhuy)
        {
            try
            {
                lenhhuy.CreateDate = DateTime.Now;
                lenhhuy.CreateBy = CNguoiDung.MaND;
                _db.TT_LenhHuys.InsertOnSubmit(lenhhuy);
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

        public bool Xoa(TT_LenhHuy lenhhuy)
        {
            try
            {
                _db.TT_LenhHuys.DeleteOnSubmit(lenhhuy);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(TT_LenhHuy lenhhuy)
        {
            try
            {
                lenhhuy.ModifyDate = DateTime.Now;
                lenhhuy.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(string SoHoaDon)
        {
            try
            {
                string sql = "";
                sql = "delete TT_LenhHuy where SoHoaDon='" + SoHoaDon + "'";
                return LinQ_ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckExist(string SoHoaDon)
        {
            if (_db.HOADONs.Any(itemHD => itemHD.SOHOADON == SoHoaDon))
                return _db.TT_LenhHuys.Any(item => item.MaHD == _db.HOADONs.SingleOrDefault(itemHD => itemHD.SOHOADON == SoHoaDon).ID_HOADON);
            else
                return false;
        }

        public bool CheckExist_Ton(string DanhBo,int Nam,int Ky)
        {
            var query = from item in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on item.MaHD equals itemHD.ID_HOADON
                        where itemHD.NGAYGIAITRACH == null && itemHD.DANHBA == DanhBo && itemHD.NAM == Nam && itemHD.KY == Ky
                        select new
                        {
                            itemHD.ID_HOADON,
                        };
            if (query.Count() > 0)
            {
                return true;
            }
            else
                return false;
        }

        //public bool CheckExist(string SoHoaDon,int Nam,int Ky)
        //{
        //    return _db.TT_LenhHuys.Any(item => item.SoHoaDon == SoHoaDon && item.CreateDate.Value.Year == Nam && item.CreateDate.Value.Month == Ky);
        //}

        public TT_LenhHuy Get(string SoHoaDon)
        {
            return _db.TT_LenhHuys.SingleOrDefault(item => item.SoHoaDon == SoHoaDon);
        }

        public TT_LenhHuy getMoiNhat(string DanhBo)
        {
            if (_db.TT_LenhHuys.Any(item => item.DanhBo == DanhBo) == true)
                return _db.TT_LenhHuys.Where(item => item.DanhBo == DanhBo).OrderByDescending(item => item.CreateDate).First();
            else
                return null;
        }

        public DataTable GetDS()
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(int MaTo)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                           && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime CreateDate)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemLH.CreateDate.Value.Date == CreateDate.Date
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDS(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemLH.CreateDate.Value.Date >= FromCreateDate.Date && itemLH.CreateDate.Value.Date <= ToCreateDate.Date
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTon()
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.NGAYGIAITRACH == null
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTon(int Nam)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where itemHD.NAM == Nam && itemHD.NGAYGIAITRACH == null
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTon_To(int MaTo)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                           && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                           && itemHD.NGAYGIAITRACH == null
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTon_To(int MaTo, int Nam)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                           && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                           && itemHD.NAM == Nam && itemHD.NGAYGIAITRACH == null
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSTon_ExceptDongNuoc(int MaTo, DateTime NgayKiemTra)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.MaHD equals itemHD.ID_HOADON
                        where !(from itemCT in _db.TT_CTDongNuocs select itemCT.SoHoaDon).Contains(itemLH.SoHoaDon)
                        && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.Date > NgayKiemTra.Date)
                        && Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                                && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                        orderby itemHD.MALOTRINH ascending
                        select new
                        {
                            MaDN = "",
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            DanhBo = itemHD.DANHBA,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOHOADON,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            itemHD.TONGCONG,
                            TenTo = "",
                            NhanVien = "",
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDangNgan()
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                        from itemtableDN in tableDN.DefaultIfEmpty()
                        where itemHD.NGAYGIAITRACH != null
                        orderby itemHD.NGAYGIAITRACH descending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                            DangNgan = itemtableDN.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDangNgan(int Nam)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                        from itemtableDN in tableDN.DefaultIfEmpty()
                        where itemHD.NAM == Nam && itemHD.NGAYGIAITRACH != null
                        orderby itemHD.NGAYGIAITRACH descending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                            DangNgan = itemtableDN.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDangNgan_To(int MaTo)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                        from itemtableDN in tableDN.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                           && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                           && itemHD.NGAYGIAITRACH != null
                        orderby itemHD.NGAYGIAITRACH descending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                            DangNgan = itemtableDN.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDangNgan_To(int MaTo, int Nam)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.MaHD equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND into tableND
                        from itemtableND in tableND.DefaultIfEmpty()
                        join itemDN in _db.TT_NguoiDungs on itemHD.MaNV_DangNgan equals itemDN.MaND into tableDN
                        from itemtableDN in tableDN.DefaultIfEmpty()
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                           && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                           && itemHD.NAM == Nam && itemHD.NGAYGIAITRACH != null
                        orderby itemHD.NGAYGIAITRACH descending
                        select new
                        {
                            itemHD.NGAYGIAITRACH,
                            itemLH.SoHoaDon,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            MLT = itemHD.MALOTRINH,
                            itemHD.SOPHATHANH,
                            itemHD.TONGCONG,
                            itemLH.TinhTrang,
                            HanhThu = itemtableND.HoTen,
                            To = itemtableND.TT_To.TenTo,
                            GiaBieu = itemHD.GB,
                            itemLH.Cat,
                            DangNgan = itemtableDN.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetTinhTrangMoiNhat(string DanhBo)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.MaHD equals itemHD.ID_HOADON
                        where itemHD.DANHBA == DanhBo
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            Ky = itemHD.KY + "/" + itemHD.NAM,
                            itemLH.TinhTrang,
                        };
            return LINQToDataTable(query.Take(1));
        }

        public DataTable GetDSDanhBoTon(int MaTo)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.MaHD equals itemHD.ID_HOADON
                        where Convert.ToInt32(itemHD.MAY) >= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).TuCuonGCS
                           && Convert.ToInt32(itemHD.MAY) <= _db.TT_Tos.SingleOrDefault(itemTo => itemTo.MaTo == MaTo).DenCuonGCS
                           && itemHD.NGAYGIAITRACH == null
                        select new
                        {
                            DanhBo = itemHD.DANHBA,
                        };
            return LINQToDataTable(query.Distinct());
        }

        public string GetTinhTrang(string SoHoaDon)
        {
            return _db.TT_LenhHuys.SingleOrDefault(item => item.SoHoaDon == SoHoaDon).TinhTrang;
        }

        //thời hạn lùi 7 ngày
        public bool GetCatByDanhBo(string DanhBo)
        {
            var query = from itemLH in _db.TT_LenhHuys
                        join itemHD in _db.HOADONs on itemLH.SoHoaDon equals itemHD.SOHOADON
                        where itemHD.DANHBA == DanhBo && (itemHD.NGAYGIAITRACH == null || itemHD.NGAYGIAITRACH.Value.AddDays(7).Date >= DateTime.Now.Date)
                        orderby itemHD.ID_HOADON descending
                        select new
                        {
                            itemLH.Cat,
                        };
            if (query.ToList().Count > 0)
                return query.FirstOrDefault().Cat;
            else
                return false;
        }


    }
}

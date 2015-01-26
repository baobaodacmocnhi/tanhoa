using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.TongHop
{
    class CDCHD:CDAL
    {
        dbKTKS_DonKHDataContext _dbKTKS_DonKH = new dbKTKS_DonKHDataContext();

        public bool Them(DIEUCHINH_HD dchd)
        {
            try
            {
                //if (_db.DIEUCHINH_HDs.Count() > 0)
                //    hoadon.ID_DIEUCHINH_HD = _db.DIEUCHINH_HDs.Max(item => item.ID_DIEUCHINH_HD) + 1;
                //else
                //    hoadon.ID_DIEUCHINH_HD = 1;
                dchd.CreateDate = DateTime.Now;
                dchd.CreateBy = CNguoiDung.MaND;
                _db.DIEUCHINH_HDs.InsertOnSubmit(dchd);
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

        public bool Sua(DIEUCHINH_HD dchd)
        {
            try
            {
                dchd.ModifyDate = DateTime.Now;
                dchd.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(DIEUCHINH_HD dchd)
        {
            try
            {
                _db.DIEUCHINH_HDs.DeleteOnSubmit(dchd);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool CheckBySoHoaDon(string SoHoaDon)
        {
            try
            {
                return _db.DIEUCHINH_HDs.Any(item => item.SoHoaDon == SoHoaDon && item.TangGiam == null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DIEUCHINH_HD> GetDS()
        {
            return _db.DIEUCHINH_HDs.ToList();
        } 

        public DataTable GetDSChuaDCHD(int MaNV)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND
                        where itemDC.CreateBy == MaNV && itemDC.TangGiam==null
                        select new
                        {
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            itemHD.NGAYGIAITRACH,
                            itemDC.CreateDate,
                            itemHD.SOHOADON,
                            itemHD.SOPHATHANH,
                            itemHD.NAM,
                            itemHD.KY,
                            itemHD.DOT,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBan_Start=itemDC.GIABAN_BD,
                            ThueGTGT_Start = itemDC.THUE_BD,
                            PhiBVMT_Start = itemDC.PHI_BD,
                            TongCong_Start=itemDC.TONGCONG_BD,
                            itemDC.TangGiam,
                            TongCong_BD=itemDC.TONGCONG_DC,
                            TongCong_End=itemDC.TONGCONG_END,
                            HanhThu = itemND.TT_To.TenTo + ": " + itemND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DataTable GetDSDaDCHD(int MaNV)
        {
            var query = from itemDC in _db.DIEUCHINH_HDs
                        join itemHD in _db.HOADONs on itemDC.FK_HOADON equals itemHD.ID_HOADON
                        join itemND in _db.TT_NguoiDungs on itemHD.MaNV_HanhThu equals itemND.MaND
                        where itemDC.CreateBy == MaNV && itemDC.TangGiam != null
                        select new
                        {
                            MaDCHD = itemDC.ID_DIEUCHINH_HD,
                            itemHD.NGAYGIAITRACH,
                            itemDC.CreateDate,
                            itemHD.SOHOADON,
                            itemHD.SOPHATHANH,
                            itemHD.NAM,
                            itemHD.KY,
                            itemHD.DOT,
                            MLT = itemHD.MALOTRINH,
                            DanhBo = itemHD.DANHBA,
                            HoTen = itemHD.TENKH,
                            DiaChi = itemHD.SO + " " + itemHD.DUONG,
                            GiaBan_Start = itemDC.GIABAN_BD,
                            ThueGTGT_Start = itemDC.THUE_BD,
                            PhiBVMT_Start = itemDC.PHI_BD,
                            TongCong_Start = itemDC.TONGCONG_BD,
                            itemDC.TangGiam,
                            TongCong_BD = itemDC.TONGCONG_DC,
                            TongCong_End = itemDC.TONGCONG_END,
                            HanhThu = itemND.TT_To.TenTo + ": " + itemND.HoTen,
                        };
            return LINQToDataTable(query);
        }

        public DIEUCHINH_HD GetByMaDCHD(int MaDC)
        {
            return _db.DIEUCHINH_HDs.SingleOrDefault(item => item.ID_DIEUCHINH_HD == MaDC);
        }

        public DonKH GetDonKHbyID(decimal MaDon)
        {
            return _dbKTKS_DonKH.DonKHs.SingleOrDefault(itemDonKH => itemDonKH.MaDon == MaDon);
        }

        public DonTXL GetDonTXLbyID(decimal MaDon)
        {
            return _dbKTKS_DonKH.DonTXLs.SingleOrDefault(itemDonTXL => itemDonTXL.MaDon == MaDon);
        }

        public CTDCHD GetCTDCHDBySoPhieu(decimal SoPhieu)
        {
            return _dbKTKS_DonKH.CTDCHDs.SingleOrDefault(item => item.MaCTDCHD == SoPhieu);
        }
    }
}

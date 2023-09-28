using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using System.Data;

namespace DocSo_PC.DAL.QuanTri
{
    class CNguoiDung : CDAL
    {
        static string _Nam;
        public static string Nam
        {
            get { return CNguoiDung._Nam; }
            set { CNguoiDung._Nam = value; }
        }

        static string _Ky;
        public static string Ky
        {
            get { return CNguoiDung._Ky; }
            set { CNguoiDung._Ky = value; }
        }

        static string _Dot;
        public static string Dot
        {
            get { return CNguoiDung._Dot; }
            set { CNguoiDung._Dot = value; }
        }

        static int _TuMayDS;
        public static int TuMayDS
        {
            get { return _TuMayDS; }
            set { _TuMayDS = value; }
        }

        static int _DenMayDS;
        public static int DenMayDS
        {
            get { return _DenMayDS; }
            set { _DenMayDS = value; }
        }

        static int _MaND;
        public static int MaND
        {
            get { return _MaND; }
            set { _MaND = value; }
        }

        static string _TaiKhoan;
        public static string TaiKhoan
        {
            get { return CNguoiDung._TaiKhoan; }
            set { CNguoiDung._TaiKhoan = value; }
        }

        static string _HoTen;
        public static string HoTen
        {
            get { return CNguoiDung._HoTen; }
            set { CNguoiDung._HoTen = value; }
        }

        static int _MaTo;
        public static int MaTo
        {
            get { return CNguoiDung._MaTo; }
            set { CNguoiDung._MaTo = value; }
        }

        static string _TenTo;
        public static string TenTo
        {
            get { return CNguoiDung._TenTo; }
            set { CNguoiDung._TenTo = value; }
        }

        static bool _Admin;
        public static bool Admin
        {
            get { return CNguoiDung._Admin; }
            set { CNguoiDung._Admin = value; }
        }

        static bool _PhoGiamDoc;
        public static bool PhoGiamDoc
        {
            get { return CNguoiDung._PhoGiamDoc; }
            set { CNguoiDung._PhoGiamDoc = value; }
        }

        static bool _Doi;
        public static bool Doi
        {
            get { return CNguoiDung._Doi; }
            set { CNguoiDung._Doi = value; }
        }

        static bool _DoiXem;
        public static bool DoiXem
        {
            get { return CNguoiDung._DoiXem; }
            set { CNguoiDung._DoiXem = value; }
        }

        static bool _ToTruong;
        public static bool ToTruong
        {
            get { return CNguoiDung._ToTruong; }
            set { CNguoiDung._ToTruong = value; }
        }

        static bool _ThuKy;
        public static bool ThuKy
        {
            get { return CNguoiDung._ThuKy; }
            set { CNguoiDung._ThuKy = value; }
        }

        static string _ChucVu = "";
        public static string ChucVu
        {
            get { return CNguoiDung._ChucVu; }
            set { CNguoiDung._ChucVu = value; }
        }

        static string _NguoiKy = "";
        public static string NguoiKy
        {
            get { return CNguoiDung._NguoiKy; }
            set { CNguoiDung._NguoiKy = value; }
        }

        static string _TenPhong = "ĐỘI QUẢN LÝ ĐỒNG HỒ NƯỚC";
        public static string TenPhong
        {
            get { return CNguoiDung._TenPhong; }
            set { CNguoiDung._TenPhong = value; }
        }

        static string _DanhBos = "";
        public static string DanhBos
        {
            get { return CNguoiDung._DanhBos; }
            set { CNguoiDung._DanhBos = value; }
        }

        static bool _updateChuyenListing;
        public static bool updateChuyenListing
        {
            get { return CNguoiDung._updateChuyenListing; }
            set { CNguoiDung._updateChuyenListing = value; }
        }

        static System.Data.DataTable _dtQuyenNhom;
        public static System.Data.DataTable dtQuyenNhom
        {
            get { return CNguoiDung._dtQuyenNhom; }
            set { CNguoiDung._dtQuyenNhom = value; }
        }

        static System.Data.DataTable _dtQuyenNguoiDung;
        public static System.Data.DataTable dtQuyenNguoiDung
        {
            get { return CNguoiDung._dtQuyenNguoiDung; }
            set { CNguoiDung._dtQuyenNguoiDung = value; }
        }

        public static bool CheckQuyen(string TenMenu, string LoaiQuyen)
        {
            string query = "";
            switch (LoaiQuyen)
            {
                case "Xem":
                    query = "TenMenu ='" + TenMenu + "' and Xem=1";
                    break;
                case "Them":
                    query = "TenMenu ='" + TenMenu + "' and Them=1";
                    break;
                case "Sua":
                    query = "TenMenu ='" + TenMenu + "' and Sua=1";
                    break;
                case "Xoa":
                    query = "TenMenu ='" + TenMenu + "' and Xoa=1";
                    break;
                default:
                    break;
            }
            System.Data.DataRow[] drs;
            ///Kiểm tra quyền theo Nhóm
            if (_dtQuyenNhom != null)
            {
                drs = dtQuyenNhom.Select(query);
                if (drs.Count() > 0)
                    return true;
                else
                    if (dtQuyenNguoiDung != null)
                    {
                        ///Kiểm tra quyền theo Người Dùng
                        drs = dtQuyenNguoiDung.Select(query);
                        if (drs.Count() > 0)
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
            }
            else
                if (dtQuyenNguoiDung != null)
                {
                    ///Kiểm tra quyền theo Người Dùng
                    drs = dtQuyenNguoiDung.Select(query);
                    if (drs.Count() > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
        }

        public bool Them(NguoiDung nguoidung)
        {
            try
            {
                if (_db.NguoiDungs.Count() > 0)
                    nguoidung.MaND = _db.NguoiDungs.Max(item => item.MaND) + 1;
                else
                    nguoidung.MaND = 1;
                nguoidung.CreateDate = DateTime.Now;
                nguoidung.CreateBy = CNguoiDung.MaND;
                _db.NguoiDungs.InsertOnSubmit(nguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(NguoiDung nguoidung)
        {
            try
            {
                nguoidung.ModifyDate = DateTime.Now;
                nguoidung.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(List<NguoiDung> lstND)
        {
            try
            {
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Xoa(NguoiDung nguoidung)
        {
            try
            {
                _db.PhanQuyenNguoiDungs.DeleteAllOnSubmit(nguoidung.PhanQuyenNguoiDungs.ToList());
                _db.NguoiDungs.DeleteOnSubmit(nguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public List<NguoiDung> GetDS()
        {
            return _db.NguoiDungs.OrderBy(item => item.STT).ToList();
        }

        public List<NguoiDung> GetDSChamCong()
        {
            return _db.NguoiDungs.Where(item => item.MaND != 0 && item.ChamCong == true).OrderBy(item => item.STT).ToList();
        }

        /// <summary>
        /// Lấy Danh Sách Nhân Viên ngoài trừ Mã ND truyền vào
        /// </summary>
        /// <param name="MaND"></param>
        /// <returns></returns>
        public List<NguoiDung> GetDSExceptMaND(int MaND)
        {
            return _db.NguoiDungs.Where(item => item.MaND != MaND && item.MaND != 0 && item.An == false && item.PhoGiamDoc == false).OrderBy(item => item.STT).ToList();
        }

        public List<NguoiDung> GetDSExceptMaND_Doi(int MaND)
        {
            return _db.NguoiDungs.Where(item => item.MaND != MaND && item.MaND != 0 && item.PhoGiamDoc == false).OrderBy(item => item.STT).ToList();
        }

        public List<NguoiDung> GetDS_Admin()
        {
            return _db.NguoiDungs.OrderBy(item => item.STT).ToList();
        }

        /// <summary>
        /// Lấy Danh Sách Nhân Viên thuộc Tổ truyền vào
        /// </summary>
        /// <param name="MaTo"></param>
        /// <returns></returns>
        public List<NguoiDung> GetDSHanhThuByMaTo(int MaTo)
        {
            return _db.NguoiDungs.Where(item => item.MaTo == MaTo && item.HanhThu == true).OrderBy(item => item.STT).ToList();
        }

        public List<NguoiDung> GetDSByMaTo(int MaTo)
        {
            return _db.NguoiDungs.Where(item => item.MaTo == MaTo && (item.HanhThu == true || item.ToTruong)).OrderBy(item => item.STT).ToList();
        }

        public List<NguoiDung> GetDSByToVanPhong(int MaTo)
        {
            return _db.NguoiDungs.Where(item => item.MaTo == MaTo && item.To.HanhThu == false && item.VanPhong == true).OrderBy(item => item.STT).ToList();
        }

        public List<NguoiDung> GetDSDongNuocByMaTo(int MaTo)
        {
            return _db.NguoiDungs.Where(item => item.MaTo == MaTo && item.DongNuoc == true).OrderBy(item => item.STT).ToList();
        }

        public DataTable getDS_KTXM()
        {
            return _cDAL.LINQToDataTable(_db.NguoiDungs.Where(item => item.KTXM == true).OrderBy(item => item.STT).ToList());
        }

        public NguoiDung GetByMaND(int MaND)
        {
            return _db.NguoiDungs.SingleOrDefault(item => item.MaND == MaND);
        }

        public NguoiDung GetByTaiKhoan(string TaiKhoan)
        {
            try
            {
                return _db.NguoiDungs.SingleOrDefault(item => item.TaiKhoan == TaiKhoan);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return null;
            }

        }

        public bool DangNhap(string TaiKhoan, string MatKhau)
        {
            try
            {
                return _db.NguoiDungs.Any(item => item.TaiKhoan == TaiKhoan && item.MatKhau == MatKhau);
            }
            catch (Exception)
            {
                return false;
            }

        }

        public string GetHoTenByMaND(int MaND)
        {
            return _db.NguoiDungs.SingleOrDefault(item => item.MaND == MaND).HoTen;
        }

        public string GetTenToByMaND(int MaND)
        {
            return _db.NguoiDungs.SingleOrDefault(item => item.MaND == MaND).To.TenTo;
        }

        public string GetDienThoaiByMaND(int MaND)
        {
            return _db.NguoiDungs.SingleOrDefault(item => item.MaND == MaND).DienThoai;
        }

        public int GetMaNVByHoTen(string HoTen)
        {
            return _db.NguoiDungs.SingleOrDefault(item => item.HoTen == HoTen).MaND;
        }

        public int GetMaxSTT()
        {
            if (_db.NguoiDungs.Count() == 0)
                return 0;
            else
                return _db.NguoiDungs.Max(item => item.STT).Value;
        }

        public string getChucVu()
        {
            return _db.NguoiDungs.SingleOrDefault(item => item.KyTen == true).ChucVu;
        }

        public string getNguoiKy()
        {
            return _db.NguoiDungs.SingleOrDefault(item => item.KyTen == true).HoTen;
        }

    }
}

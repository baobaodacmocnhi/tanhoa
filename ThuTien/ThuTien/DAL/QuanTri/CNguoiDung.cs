using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using System.Data;

namespace ThuTien.DAL.QuanTri
{
    class CNguoiDung : CDAL
    {
        static int _MaND;
        public static int MaND
        {
            get { return _MaND; }
            set { _MaND = value; }
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

        static string _MaKemBamChi;
        public static string MaKemBamChi
        {
            get { return CNguoiDung._MaKemBamChi; }
            set { CNguoiDung._MaKemBamChi = value; }
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

        static bool _ToTruong;
        public static bool ToTruong
        {
            get { return CNguoiDung._ToTruong; }
            set { CNguoiDung._ToTruong = value; }
        }

        static bool _SyncNopTien;
        public static bool SyncNopTien
        {
            get { return CNguoiDung._SyncNopTien; }
            set { CNguoiDung._SyncNopTien = value; }
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

        static string _Name_PC;
        public static string Name_PC
        {
            get { return CNguoiDung._Name_PC; }
            set { CNguoiDung._Name_PC = value; }
        }

        static string _IP_PC;
        public static string IP_PC
        {
            get { return CNguoiDung._IP_PC; }
            set { CNguoiDung._IP_PC = value; }
        }

        static int _ID_DangNhap = -1;
        public static int ID_DangNhap
        {
            get { return CNguoiDung._ID_DangNhap; }
            set { CNguoiDung._ID_DangNhap = value; }
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

        public static void initial()
        {
            CNguoiDung.MaND = -1;
            CNguoiDung.HoTen = "";
            CNguoiDung.MaKemBamChi = "";
            CNguoiDung.Admin = false;
            CNguoiDung.PhoGiamDoc = false;
            CNguoiDung.Doi = false;
            CNguoiDung.ToTruong = false;
            CNguoiDung.SyncNopTien = false;
            CNguoiDung.MaTo = -1;
            CNguoiDung.TenTo = "";
            CNguoiDung.dtQuyenNhom = null;
            CNguoiDung.dtQuyenNguoiDung = null;
            CNguoiDung.Name_PC = "";
            CNguoiDung.IP_PC = "";
            CNguoiDung.ID_DangNhap = -1;
        }

        public bool Them(TT_NguoiDung nguoidung)
        {
            try
            {
                if (_db.TT_NguoiDungs.Count() > 0)
                    nguoidung.MaND = _db.TT_NguoiDungs.Max(item => item.MaND) + 1;
                else
                    nguoidung.MaND = 1;
                nguoidung.CreateDate = DateTime.Now;
                nguoidung.CreateBy = CNguoiDung.MaND;
                _db.TT_NguoiDungs.InsertOnSubmit(nguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(TT_NguoiDung nguoidung)
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

        public bool Sua(List<TT_NguoiDung> lstND)
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

        public bool Xoa(TT_NguoiDung nguoidung)
        {
            try
            {
                _db.TT_NguoiDungs.DeleteOnSubmit(nguoidung);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public List<TT_NguoiDung> GetDS()
        {
            return _db.TT_NguoiDungs.OrderBy(item => item.STT).ToList();
        }

        public List<TT_NguoiDung> GetDSChamCong()
        {
            return _db.TT_NguoiDungs.Where(item => item.MaND != 0 && item.ChamCong == true && item.An == false).OrderBy(item => item.STT).ToList();
        }

        /// <summary>
        /// Lấy Danh Sách Nhân Viên ngoài trừ Mã ND truyền vào
        /// </summary>
        /// <param name="MaND"></param>
        /// <returns></returns>
        public List<TT_NguoiDung> GetDSExceptMaND(int MaND)
        {
            return _db.TT_NguoiDungs.Where(item => item.MaND != MaND && item.MaND != 0 && item.An == false && item.PhoGiamDoc == false).OrderBy(item => item.STT).ToList();
        }

        public List<TT_NguoiDung> GetDSExceptMaND_Doi(int MaND)
        {
            return _db.TT_NguoiDungs.Where(item => item.MaND != MaND && item.MaND != 0 && item.PhoGiamDoc == false).OrderBy(item => item.STT).ToList();
        }

        public List<TT_NguoiDung> GetDS_Admin()
        {
            return _db.TT_NguoiDungs.OrderBy(item => item.STT).ToList();
        }

        /// <summary>
        /// Lấy Danh Sách Nhân Viên thuộc Tổ truyền vào
        /// </summary>
        /// <param name="MaTo"></param>
        /// <returns></returns>
        public List<TT_NguoiDung> GetDSHanhThuByMaTo(int MaTo)
        {
            return _db.TT_NguoiDungs.Where(item => item.MaTo == MaTo && item.HanhThu == true).OrderBy(item => item.STT).ToList();
        }

        public List<TT_NguoiDung> GetDSByMaTo(int MaTo)
        {
            return _db.TT_NguoiDungs.Where(item => item.MaTo == MaTo && (item.HanhThu == true || item.ToTruong)).OrderBy(item => item.STT).ToList();
        }

        public List<TT_NguoiDung> GetDSByToVanPhong(int MaTo)
        {
            return _db.TT_NguoiDungs.Where(item => item.MaTo == MaTo && item.TT_To.HanhThu == false && item.VanPhong == true).OrderBy(item => item.STT).ToList();
        }

        public List<TT_NguoiDung> GetDSDongNuocByMaTo(int MaTo)
        {
            return _db.TT_NguoiDungs.Where(item => item.MaTo == MaTo && item.DongNuoc == true).OrderBy(item => item.STT).ToList();
        }

        public List<TT_NguoiDung> getDS_DongNuoc()
        {
            return _db.TT_NguoiDungs.Where(item => item.TT_To.DongNuoc == true && item.DongNuoc == true).OrderBy(item => item.STT).ToList();
        }

        public List<TT_NguoiDung> GetDSDongNuocToTruongByMaTo(int MaTo)
        {
            return _db.TT_NguoiDungs.Where(item => item.MaTo == MaTo && (item.DongNuoc == true || item.ToTruong == true)).OrderBy(item => item.STT).ToList();
        }

        public TT_NguoiDung GetByMaND(int MaND)
        {
            return _db.TT_NguoiDungs.SingleOrDefault(item => item.MaND == MaND);
        }

        public TT_NguoiDung GetByTaiKhoan(string TaiKhoan)
        {
            try
            {
                return _db.TT_NguoiDungs.SingleOrDefault(item => item.TaiKhoan == TaiKhoan);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return null;
            }

        }

        public TT_NguoiDung getChuyenKhoan()
        {
            return _db.TT_NguoiDungs.FirstOrDefault(item => item.HoTen.Contains("Chuyển Khoản"));
        }

        public TT_NguoiDung getQuay()
        {
            return _db.TT_NguoiDungs.FirstOrDefault(item => item.HoTen.Contains("Quầy"));
        }

        public bool DangNhap(string TaiKhoan, string MatKhau)
        {
            try
            {
                return _db.TT_NguoiDungs.Any(item => item.TaiKhoan == TaiKhoan && item.MatKhau == MatKhau && item.An == false);
            }
            catch (Exception)
            {
                return false;
            }

        }

        public string GetHoTenByMaND(int MaND)
        {
            return _db.TT_NguoiDungs.SingleOrDefault(item => item.MaND == MaND).HoTen;
        }

        public string GetTenToByMaND(int MaND)
        {
            return _db.TT_NguoiDungs.SingleOrDefault(item => item.MaND == MaND).TT_To.TenTo;
        }

        public string GetDienThoaiByMaND(int MaND)
        {
            return _db.TT_NguoiDungs.SingleOrDefault(item => item.MaND == MaND).DienThoai;
        }

        public int GetMaNVByHoTen(string HoTen)
        {
            return _db.TT_NguoiDungs.SingleOrDefault(item => item.HoTen == HoTen).MaND;
        }

        public int GetMaxSTT()
        {
            if (_db.TT_NguoiDungs.Count() == 0)
                return 0;
            else
                return _db.TT_NguoiDungs.Max(item => item.STT).Value;
        }

        public bool DangNhap(TT_DangNhap en)
        {
            try
            {
                if (_db.TT_DangNhaps.Count() > 0)
                    en.ID = _db.TT_DangNhaps.Max(item => item.ID) + 1;
                else
                    en.ID = 1;
                en.CreateDate = DateTime.Now;
                en.CreateBy = CNguoiDung.MaND;
                _db.TT_DangNhaps.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public static bool DangXuat()
        {
            try
            {
                if (CNguoiDung.ID_DangNhap != -1)
                {
                    TT_DangNhap en = _db.TT_DangNhaps.SingleOrDefault(item => item.ID == CNguoiDung.ID_DangNhap);
                    en.ModifyDate = DateTime.Now;
                    en.ModifyBy = CNguoiDung.MaND;
                    _db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Danh sách đăng nhập

        public DataTable getDS_DangNhap()
        {
            var query = from item in _db.TT_DangNhaps
                        join itemND in _db.TT_NguoiDungs on item.MaND equals itemND.MaND
                        where item.ModifyBy == null
                        select new
                          {
                              itemND.HoTen,
                              item.Name_PC,
                          };
            return LINQToDataTable(query);
        }
    }
}

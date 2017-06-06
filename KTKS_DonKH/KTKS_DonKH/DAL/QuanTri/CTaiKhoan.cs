using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Data;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.QuanTri
{
    class CTaiKhoan : CDAL
    {
        /// <summary>
        /// Giảm Tiền Nước bao nhiêu %
        /// </summary>
        private const int _giamTienNuoc = 10;
        public static int GiamTienNuoc
        {
            get { return CTaiKhoan._giamTienNuoc; }
        }

        private static int _maUser = -1;
        public static int MaUser
        {
            get { return CTaiKhoan._maUser; }
            set { CTaiKhoan._maUser = value; }
        }

        private static int _maNhom = -1;
        public static int MaNhom
        {
            get { return CTaiKhoan._maNhom; }
            set { CTaiKhoan._maNhom = value; }
        }

        private static string _taiKhoan = "";
        public static string TaiKhoan
        {
            get { return CTaiKhoan._taiKhoan; }
            set { CTaiKhoan._taiKhoan = value; }
        }

        private static string _hoTen = "";
        public static string HoTen
        {
            get { return CTaiKhoan._hoTen; }
            set { CTaiKhoan._hoTen = value; }
        }

        private static string _MaKiemBamChi = "";
        public static string MaKiemBamChi
        {
            get { return CTaiKhoan._MaKiemBamChi; }
            set { CTaiKhoan._MaKiemBamChi = value; }
        }

        static bool _Admin;
        public static bool Admin
        {
            get { return CTaiKhoan._Admin; }
            set { CTaiKhoan._Admin = value; }
        }

        static bool _PhoGiamDoc;
        public static bool PhoGiamDoc
        {
            get { return CTaiKhoan._PhoGiamDoc; }
            set { CTaiKhoan._PhoGiamDoc = value; }
        }

        static bool _TruongPhong;
        public static bool TruongPhong
        {
            get { return CTaiKhoan._TruongPhong; }
            set { CTaiKhoan._TruongPhong = value; }
        }

        static bool _ToTruong;
        public static bool ToTruong
        {
            get { return CTaiKhoan._ToTruong; }
            set { CTaiKhoan._ToTruong = value; }
        }

        static bool _ThuKy;
        public static bool ThuKy
        {
            get { return CTaiKhoan._ThuKy; }
            set { CTaiKhoan._ThuKy = value; }
        }

        static bool _ToKH;
        public static bool ToKH
        {
            get { return CTaiKhoan._ToKH; }
            set { CTaiKhoan._ToKH = value; }
        }

        static bool _ToXL;
        public static bool ToXL
        {
            get { return CTaiKhoan._ToXL; }
            set { CTaiKhoan._ToXL = value; }
        }

        static bool _ToBC;
        public static bool ToBC
        {
            get { return CTaiKhoan._ToBC; }
            set { CTaiKhoan._ToBC = value; }
        }

        static System.Data.DataTable _dtQuyenNhom;
        public static System.Data.DataTable dtQuyenNhom
        {
            get { return CTaiKhoan._dtQuyenNhom; }
            set { CTaiKhoan._dtQuyenNhom = value; }
        }

        static System.Data.DataTable _dtQuyenNguoiDung;
        public static System.Data.DataTable dtQuyenNguoiDung
        {
            get { return CTaiKhoan._dtQuyenNguoiDung; }
            set { CTaiKhoan._dtQuyenNguoiDung = value; }
        }

        public bool DangNhap(string taikhoan, string matkhau)
        {
            try
            {
                return db.Users.Any(item => item.TaiKhoan == taikhoan && item.MatKhau == matkhau);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void DangXuat()
        {
            if (_taiKhoan != "")
            {
                //db.Users.Single(item => item.TaiKhoan == _taiKhoan).Login = false;
                //db.SubmitChanges();
            }
            _maUser = -1;
            _taiKhoan = "";
            _hoTen = "";
            _MaKiemBamChi = "";
            ///
            db.Connection.Close();
        }

        public bool Them(User nguoidung)
        {
            try
            {
                if (!db.Users.Any(item => item.TaiKhoan == nguoidung.TaiKhoan))
                {
                    if (db.Users.Count() > 0)
                        nguoidung.MaU = db.Users.Max(itemU => itemU.MaU) + 1;
                    else
                        nguoidung.MaU = 1;
                    nguoidung.CreateDate = DateTime.Now;
                    nguoidung.CreateBy = CTaiKhoan.MaUser;
                    db.Users.InsertOnSubmit(nguoidung);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này đã có người sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.Users);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool Xoa(User nguoidung)
        {
            try
            {
                db.Users.DeleteOnSubmit(nguoidung);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool Sua(User nguoidung)
        {
            try
            {
                nguoidung.ModifyDate = DateTime.Now;
                nguoidung.ModifyBy = CTaiKhoan.MaUser;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool ThayDoiMatKhau(string MatKhauCu, string MatKhauMoi)
        {
            try
            {
                if (db.Users.Any(item => item.MaU == MaUser && item.MatKhau == MatKhauCu))
                {
                    db.Users.Single(item => item.MaU == MaUser).MatKhau = MatKhauMoi;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                db = new dbKinhDoanhDataContext();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public User Get(int MaU)
        {
            return db.Users.SingleOrDefault(item => item.MaU == MaU);
        }

        public User Get(string TaiKhoan)
        {
            return db.Users.SingleOrDefault(item => item.TaiKhoan == TaiKhoan);
        }

        public List<User> GetDS()
        {
            return db.Users.Where(item => item.An == false).OrderBy(item => item.STT).ToList();
        }

        public List<User> GetDS_Admin()
        {
            return db.Users.OrderBy(item => item.STT).ToList();
        }

        public List<User> GetDSExceptMaND(int MaND)
        {
            return db.Users.Where(item => item.MaU != MaND && item.MaU != 0 && item.An == false && item.PhoGiamDoc == false).OrderBy(item => item.STT).ToList();
        }

        public DataTable GetDS_KTXM(string Loai)
        {
            switch (Loai)
            {
                case "TKH":
                    return LINQToDataTable(db.Users.Where(item => item.KTXM == true && item.ToKH == true && item.An == false).OrderBy(item => item.STT).ToList());
                case "TXL":
                    return LINQToDataTable(db.Users.Where(item => item.KTXM == true && item.ToXL == true && item.An == false).OrderBy(item => item.STT).ToList());
                case "TBC":
                    return LINQToDataTable(db.Users.Where(item => item.KTXM == true && item.ToBC == true && item.An == false).OrderBy(item => item.STT).ToList());
                default:
                    return null;
            }
        }

        public DataTable GetDS_ThuKy(string Loai)
        {
            switch (Loai)
            {
                case "TKH":
                    return LINQToDataTable(db.Users.Where(item => item.KTXM == false && item.ToKH == true && item.An == false).OrderBy(item => item.STT).ToList());
                case "TXL":
                    return LINQToDataTable(db.Users.Where(item => item.KTXM == false && item.ToXL == true && item.An == false).OrderBy(item => item.STT).ToList());
                case "TBC":
                    return LINQToDataTable(db.Users.Where(item => item.KTXM == false && item.ToBC == true && item.An == false).OrderBy(item => item.STT).ToList());
                case "TVP":
                    return LINQToDataTable(db.Users.Where(item => item.ToVP == true && item.An == false).OrderBy(item => item.STT).ToList());
                default:
                    return null;
            }
        }

        public string GetHoTen(int MaU)
        {
            return db.Users.SingleOrDefault(item => item.MaU == MaU).HoTen;
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

        public int GetMaxSTT()
        {
            if (db.Users.Count() == 0)
                return 0;
            else
                return db.Users.Max(item => item.STT).Value;
        }
    }
}

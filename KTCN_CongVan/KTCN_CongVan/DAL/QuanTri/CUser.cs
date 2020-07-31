using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTCN_CongVan.LinQ;
using System.Data;

namespace KTCN_CongVan.DAL.QuanTri
{
    class CUser : CDAL
    {
        static int _ID;
        public static int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        static string _HoTen;
        public static string HoTen
        {
            get { return CUser._HoTen; }
            set { CUser._HoTen = value; }
        }

        static int _MaTo;
        public static int MaTo
        {
            get { return CUser._MaTo; }
            set { CUser._MaTo = value; }
        }

        static string _TenTo;
        public static string TenTo
        {
            get { return CUser._TenTo; }
            set { CUser._TenTo = value; }
        }

        static bool _Admin;
        public static bool Admin
        {
            get { return CUser._Admin; }
            set { CUser._Admin = value; }
        }

        static bool _PhoGiamDoc;
        public static bool PhoGiamDoc
        {
            get { return CUser._PhoGiamDoc; }
            set { CUser._PhoGiamDoc = value; }
        }

        static bool _Doi;
        public static bool Doi
        {
            get { return CUser._Doi; }
            set { CUser._Doi = value; }
        }

        static bool _ToTruong;
        public static bool ToTruong
        {
            get { return CUser._ToTruong; }
            set { CUser._ToTruong = value; }
        }

        static int _IDPhong;
        public static int IDPhong
        {
            get { return CUser._IDPhong; }
            set { CUser._IDPhong = value; }
        }

        static int _IDNhom;
        public static int IDNhom
        {
            get { return CUser._IDNhom; }
            set { CUser._IDNhom = value; }
        }

        static System.Data.DataTable _dtQuyenNhom;
        public static System.Data.DataTable dtQuyenNhom
        {
            get { return CUser._dtQuyenNhom; }
            set { CUser._dtQuyenNhom = value; }
        }

        static System.Data.DataTable _dtQuyenNguoiDung;
        public static System.Data.DataTable dtQuyenNguoiDung
        {
            get { return CUser._dtQuyenNguoiDung; }
            set { CUser._dtQuyenNguoiDung = value; }
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
            CUser.ID = -1;
            CUser.HoTen = "";
            CUser.Admin = false;
            CUser.IDPhong = -1;
            CUser.IDNhom = -1;
            CUser.dtQuyenNguoiDung = null;
            CUser.dtQuyenNhom = null;
        }

        public bool Them(User en)
        {
            try
            {
                if (_db.Users.Count() > 0)
                    en.ID = _db.Users.Max(item => item.ID) + 1;
                else
                    en.ID = 1;
                en.CreateDate = DateTime.Now;
                en.CreateBy = CUser.ID;
                _db.Users.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool Sua(User en)
        {
            try
            {
                en.ModifyDate = DateTime.Now;
                en.ModifyBy = CUser.ID;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(List<User> lstND)
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

        public bool Xoa(User en)
        {
            try
            {
                _db.Users.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public List<User> GetDS()
        {
            return _db.Users.OrderBy(item => item.STT).ToList();
        }

        public List<User> GetDSChamCong()
        {
            return _db.Users.Where(item => item.ID != 0  && item.An==false).OrderBy(item => item.STT).ToList();
        }

        /// <summary>
        /// Lấy Danh Sách Nhân Viên ngoài trừ Mã ND truyền vào
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<User> GetDSExceptMaND(int ID)
        {
            return _db.Users.Where(item => item.ID != ID && item.ID != 0 && item.An == false ).OrderBy(item => item.STT).ToList();
        }

        public List<User> GetDSExceptMaND_Doi(int ID)
        {
            return _db.Users.Where(item => item.ID != ID && item.ID != 0 ).OrderBy(item => item.STT).ToList();
        }

        public List<User> GetDS_Admin()
        {
            return _db.Users.OrderBy(item => item.STT).ToList();
        }

        public User GetByMaND(int ID)
        {
            return _db.Users.SingleOrDefault(item => item.ID == ID);
        }

        public User GetByTaiKhoan(string TaiKhoan)
        {
            try
            {
                return _db.Users.SingleOrDefault(item => item.Username == TaiKhoan);
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
                return _db.Users.Any(item => item.Username == TaiKhoan && item.Password == MatKhau && item.An == false);
            }
            catch (Exception)
            {
                return false;
            }

        }

        public string GetHoTenByMaND(int ID)
        {
            return _db.Users.SingleOrDefault(item => item.ID == ID).Name;
        }

        public int GetMaNVByHoTen(string HoTen)
        {
            return _db.Users.SingleOrDefault(item => item.Name == HoTen).ID;
        }

        public int GetMaxSTT()
        {
            if (_db.Users.Count() == 0)
                return 0;
            else
                return _db.Users.Max(item => item.STT).Value;
        }

    }
}

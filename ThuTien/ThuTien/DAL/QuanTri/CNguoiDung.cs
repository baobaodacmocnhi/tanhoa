using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;

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

        static System.Data.DataTable _dtQuyen;
        public static System.Data.DataTable DtQuyen
        {
            get { return CNguoiDung._dtQuyen; }
            set { CNguoiDung._dtQuyen = value; }
        }

        public static bool CheckQuyen(string TenMenu, string LoaiQuyen)
        {
            string query = "";
            switch (LoaiQuyen)
            {
                case "Xem":
                    query = "TenMenu like '" + TenMenu + "' and Xem=1";
                    break;
                case "Them":
                    query = "TenMenu like '" + TenMenu + "' and Them=1";
                    break;
                case "Sua":
                    query = "TenMenu like '" + TenMenu + "' and Sua=1";
                    break;
                case "Xoa":
                    query = "TenMenu like '" + TenMenu + "' and Xoa=1";
                    break;
                default:
                    break;
            }
            System.Data.DataRow[] drs = _dtQuyen.Select(query);
            if (drs.Count() > 0)
                return true;
            else
                return false;
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
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return false;
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
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
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
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return false;
            }
        }

        public List<TT_NguoiDung> GetDSNguoiDung()
        {
            return _db.TT_NguoiDungs.ToList();
        }

        public TT_NguoiDung GetNguoiDungByMaND(int MaND)
        {
            return _db.TT_NguoiDungs.SingleOrDefault(item => item.MaND == MaND);
        }

        public TT_NguoiDung GetNguoiDungByTaiKhoan(string TaiKhoan)
        {
            return _db.TT_NguoiDungs.SingleOrDefault(item => item.TaiKhoan == TaiKhoan);
        }

        public bool DangNhap(string TaiKhoan, string MatKhau)
        {
            return _db.TT_NguoiDungs.Any(item => item.TaiKhoan == TaiKhoan && item.MatKhau == MatKhau);
        }
    }
}

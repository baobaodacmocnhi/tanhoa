using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Data;
using KTKS_DonKH.Function;
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

        /// <summary>
        /// Kiểm tra đăng nhập
        /// </summary>
        /// <param name="taikhoan">string</param>
        /// <param name="matkhau">string</param>
        /// <returns>true/false</returns>
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

        public List<User> GetDS()
        {
            return db.Users.OrderBy(item => item.STT).ToList();
        }

        public List<User> GetDS_Admin()
        {
            return db.Users.OrderBy(item => item.STT).ToList();
        }

        public List<User> GetDSExceptMaND(int MaND)
        {
            return db.Users.Where(item => item.MaU != MaND && item.MaU != 0 && item.An == false && item.PhoGiamDoc == false).OrderBy(item => item.STT).ToList();
        }

        /// <summary>
        /// Lấy danh sách tài khoản
        /// </summary>
        /// <returns>datatable</returns>
        public DataTable LoadDSTaiKhoan_Old()
        {
            try
            {
                    var taikhoans = from itemUser in db.Users
                                    where itemUser.MaU != 0 && itemUser.TaiKhoan != TaiKhoan
                                    select new
                                    {
                                        MaU = itemUser.MaU,
                                        HoTen = itemUser.HoTen,
                                        TaiKhoan = itemUser.TaiKhoan,
                                        MatKhau = itemUser.MatKhau,
                                    };
                    ///1 tài khoản có nhiều quyền chưa biết làm ntn nên jờ tạm làm theo cách chạy vòng lập add từng record
                    DataTable table = new DataTable();
                    table.Columns.Add("MaU", typeof(string));
                    table.Columns.Add("HoTen", typeof(string));
                    table.Columns.Add("TaiKhoan", typeof(string));
                    table.Columns.Add("MatKhau", typeof(string));
                    table.Columns.Add("QTaiKhoan", typeof(bool));
                    table.Columns.Add("QCapNhat", typeof(bool));
                    table.Columns.Add("QNhanDonKH", typeof(bool));
                    table.Columns.Add("QQLDonKH", typeof(bool));
                    table.Columns.Add("QKTXM", typeof(bool));
                    table.Columns.Add("QQLKTXM", typeof(bool));
                    table.Columns.Add("QDCBD", typeof(bool));
                    table.Columns.Add("QCHDB", typeof(bool));
                    table.Columns.Add("QTTTL", typeof(bool));

                    foreach (var itemTK in taikhoans)
                    {
                        var quyens = from itemDetailRole in db.DetailRoles
                                     where itemDetailRole.MaU == itemTK.MaU
                                     orderby itemDetailRole.MaR ascending
                                     select itemDetailRole;

                        ///MaR=1 => quyền Tài Khoản
                        ///MaR=2 => quyền Cập Nhật
                        ///MaR=3 => quyền Nhận Đơn Khách Hàng
                        ///MaR=4 => quyền Quản Lý Đơn Khách Hàng
                        ///MaR=5 => quyền Kiểm Tra Xác Minh
                        ///MaR=6 => quyền Quản Lý Kiểm Tra Xác Minh
                        ///MaR=7 => quyền Điều Chỉnh Biến Động
                        ///MaR=8 => quyền Cắt Hủy Danh Bộ
                        ///MaR=9 => quyền Thảo Thư Trả Lời
                        table.Rows.Add(itemTK.MaU, itemTK.HoTen, itemTK.TaiKhoan, itemTK.MatKhau,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 1).QuyenCapNhat,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 2).QuyenCapNhat,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 3).QuyenCapNhat,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 4).QuyenCapNhat,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 5).QuyenCapNhat,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 6).QuyenCapNhat,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 7).QuyenCapNhat,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 8).QuyenCapNhat,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 9).QuyenCapNhat
                                        );
                    }
                    return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách tài khoản
        /// </summary>
        /// <returns></returns>
        public List<User> LoadDSTaiKhoan()
        {
            try
            {
                    return db.Users.Where(itemUser => itemUser.MaU != 0 && itemUser.TaiKhoan != TaiKhoan).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách User thuộc Tổ Xử Lý
        /// </summary>
        /// <returns></returns>
        public List<User> LoadDSTaiKhoanTXL()
        {
            try
            {
                return db.Users.Where(itemUser => itemUser.MaU != 0 && itemUser.ToXuLy == true).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách User thuộc Tổ Khách Hàng
        /// </summary>
        /// <returns></returns>
        public List<User> LoadDSTaiKhoanTKH()
        {
            try
            {
                return db.Users.Where(itemUser => itemUser.MaU != 0 && itemUser.ToKH == true).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách User thuộc Tổ Văn Phòng
        /// </summary>
        /// <returns></returns>
        public List<User> LoadDSTaiKhoanTVP()
        {
            try
            {
                return db.Users.Where(itemUser => itemUser.MaU != 0 && itemUser.ToVP == true).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy tài khoản
        /// </summary>
        /// <param name="MaU">int</param>
        /// <returns>class</returns>
        public User GetByID(int MaU)
        {
            try
            {
                return db.Users.SingleOrDefault(item => item.MaU == MaU);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public User GetByTaiKhoan(string TaiKhoan)
        {
            try
            {
                return db.Users.SingleOrDefault(item => item.TaiKhoan == TaiKhoan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Họ Tên người dùng bằng Tài Khoản đăng nhập
        /// </summary>
        /// <param name="TaiKhoan"></param>
        /// <returns></returns>
        public string getHoTenUserbyID(int MaU)
        {
            try
            {
                return db.Users.Single(item => item.MaU == MaU).HoTen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
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
                        ///Cấp quyền mặc định = False
                        ///i tương ứng với số quyền trong bảng DetailRole
                        for (int i = 1; i <= 13; i++)
                        {
                            DetailRole qTaiKhoan = new DetailRole();
                            qTaiKhoan.MaR = i;
                            qTaiKhoan.QuyenXem = false;
                            qTaiKhoan.QuyenCapNhat = false;
                            nguoidung.DetailRoles.Add(qTaiKhoan);
                        }
                        db.SubmitChanges();
                        //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }    
        }

        public bool Xoa(User nguoidung)
        {
            try
            {
                    foreach (var itemDetailRole in db.DetailRoles.Where(itemTaiKhoan => itemTaiKhoan.MaU == nguoidung.MaU))
                    {
                        db.DetailRoles.DeleteOnSubmit(itemDetailRole);
                    }
                    db.Users.DeleteOnSubmit(nguoidung);
                    db.SubmitChanges();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
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
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        /// <summary>
        /// Cập nhật quyền truy cập của tài khoản
        /// </summary>
        /// <param name="MaR">int</param>
        /// <param name="Value">true/false</param>
        public bool SuaQuyen(int MaU, int MaR, string Quyen,bool Value)
        {
            try
            {
                    if (Quyen == "QuyenXem")
                        db.DetailRoles.Single(itemRoleTaiKhoan => itemRoleTaiKhoan.MaU == MaU && itemRoleTaiKhoan.MaR == MaR).QuyenXem = Value;
                    else
                        if (Quyen == "QuyenCapNhat")
                            db.DetailRoles.Single(itemRoleTaiKhoan => itemRoleTaiKhoan.MaU == MaU && itemRoleTaiKhoan.MaR == MaR).QuyenCapNhat = Value;
                    db.DetailRoles.Single(itemRoleTaiKhoan => itemRoleTaiKhoan.MaU == MaU && itemRoleTaiKhoan.MaR == MaR).User.ModifyDate = DateTime.Now;
                    db.DetailRoles.Single(itemRoleTaiKhoan => itemRoleTaiKhoan.MaU == MaU && itemRoleTaiKhoan.MaR == MaR).User.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool ThayDoiMatKhau(string MatKhauCu, string MatKhauMoi)
        {
            try
            {
                if (db.Users.Any(itemTaiKhoan => itemTaiKhoan.TaiKhoan == TaiKhoan && itemTaiKhoan.MatKhau == MatKhauCu))
                {
                    db.Users.Single(itemTaiKhoan => itemTaiKhoan.TaiKhoan == TaiKhoan).MatKhau = MatKhauMoi;
                    db.SubmitChanges();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.Users);
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

        public DataTable LoadDSRolebyUser(int MaU)
        {
            try
            {
                    var queryRoles = from itemDR in db.DetailRoles
                                     where itemDR.MaU == MaU
                                     select new
                                     {
                                         itemDR.MaR,
                                         itemDR.Role.TenR,
                                         itemDR.QuyenXem,
                                         itemDR.QuyenCapNhat
                                     };
                    return LINQToDataTable(queryRoles);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KTKS_DonKH.LinQ;
using System.Data;
using KTKS_DonKH.Function;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.HeThong
{
    class CTaiKhoan : CDAL
    {
        private static string _taiKhoan = "";
        private static string _hoTen = "";
        private static bool _roleTaiKhoan = false;
        private static bool _roleCapNhat = false;
        private static bool _roleNhanDonKH = false;
        private static bool _roleQLDonKH = false;
        private static bool _roleKTXM = false;
        private static bool _roleDCBD = false;
        private static bool _roleCHDB = false;
        private static bool _roleTTTL = false;

        public static string TaiKhoan
        {
            get { return CTaiKhoan._taiKhoan; }
            set { CTaiKhoan._taiKhoan = value; }
        }
        public static string HoTen
        {
            get { return CTaiKhoan._hoTen; }
            set { CTaiKhoan._hoTen = value; }
        }
        public static bool RoleTaiKhoan
        {
            get { return CTaiKhoan._roleTaiKhoan; }
            set { CTaiKhoan._roleTaiKhoan = value; }
        }
        public static bool RoleCapNhat
        {
            get { return CTaiKhoan._roleCapNhat; }
            set { CTaiKhoan._roleCapNhat = value; }
        }
        public static bool RoleNhanDonKH
        {
            get { return CTaiKhoan._roleNhanDonKH; }
            set { CTaiKhoan._roleNhanDonKH = value; }
        }
        public static bool RoleQLDonKH
        {
            get { return CTaiKhoan._roleQLDonKH; }
            set { CTaiKhoan._roleQLDonKH = value; }
        }
        public static bool RoleKTXM
        {
            get { return CTaiKhoan._roleKTXM; }
            set { CTaiKhoan._roleKTXM = value; }
        }
        public static bool RoleDCBD
        {
            get { return CTaiKhoan._roleDCBD; }
            set { CTaiKhoan._roleDCBD = value; }
        }
        public static bool RoleCHDB
        {
            get { return CTaiKhoan._roleCHDB; }
            set { CTaiKhoan._roleCHDB = value; }
        }
        public static bool RoleTTTL
        {
            get { return CTaiKhoan._roleTTTL; }
            set { CTaiKhoan._roleTTTL = value; }
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
                if (db.Users.Any(item => item.TaiKhoan == taikhoan && item.MatKhau == matkhau && item.Login == false))
                {
                    _taiKhoan = taikhoan;
                    _hoTen = db.Users.Single(item => item.TaiKhoan == taikhoan).HoTen;
                    ///Mã Role Tài Khoản là 1
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 1).CapQuyen == true)
                        _roleTaiKhoan = true;
                    else
                        _roleTaiKhoan = false;
                    ///Mã Role Cập Nhật là 2
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 2).CapQuyen == true)
                        _roleCapNhat = true;
                    else
                        _roleCapNhat = false;
                    ///Mã Role Nhận Đơn Khách Hàng là 3
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 3).CapQuyen == true)
                        _roleNhanDonKH = true;
                    else
                        _roleNhanDonKH = false;
                    ///Mã Role Quản Lý Đơn Khách Hàng là 4
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 4).CapQuyen == true)
                        _roleQLDonKH = true;
                    else
                        _roleQLDonKH = false;
                    ///Mã Role Kiểm Tra Xác Minh là 5
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 5).CapQuyen == true)
                        _roleKTXM = true;
                    else
                        _roleKTXM = false;
                    ///Mã Role Điều Chỉnh Biến Động là 6
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 6).CapQuyen == true)
                        _roleDCBD = true;
                    else
                        _roleDCBD = false;
                    ///Mã Role Cắt Hủy Danh Bộ là 7
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 7).CapQuyen == true)
                        _roleCHDB = true;
                    else
                        _roleCHDB = false;
                    ///Mã Role Thảo Thư Trả Lời là 8
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 8).CapQuyen == true)
                        _roleTTTL = true;
                    else
                        _roleTTTL = false;
                    //db.Users.Single(item => item.TaiKhoan == taikhoan && item.MatKhau == matkhau).Login = true;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show("Sai Tài Khoản,Mật Khẩu hoặc Tài Khoản đang được đăng nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể kết nối cơ sở dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _taiKhoan = "";
            _hoTen = "";
            _roleTaiKhoan = false;
            _roleCapNhat = false;
            _roleNhanDonKH = false;
            _roleQLDonKH = false;
            _roleKTXM = false;
            _roleDCBD = false;
            _roleCHDB = false;
            _roleTTTL = false;
        }

        /// <summary>
        /// Lấy danh sách tài khoản
        /// </summary>
        /// <returns>datatable</returns>
        public DataTable LoadDSTaiKhoan()
        {
            try
            {
                if (CTaiKhoan.RoleTaiKhoan)
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
                        ///MaR=6 => quyền Điều Chỉnh Biến Động
                        ///MaR=7 => quyền Cắt Hủy Danh Bộ
                        ///MaR=8 => quyền Thảo Thư Trả Lời
                        table.Rows.Add(itemTK.MaU, itemTK.HoTen, itemTK.TaiKhoan, itemTK.MatKhau,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 1).CapQuyen,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 2).CapQuyen,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 3).CapQuyen,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 4).CapQuyen,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 5).CapQuyen,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 6).CapQuyen,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 7).CapQuyen,
                                        quyens.FirstOrDefault(itemQ => itemQ.MaR == 8).CapQuyen
                                        );
                    }
                    return table;
                }
                else
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
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
        public User getUserbyID(int MaU)
        {
            try
            {
                return db.Users.Single(item => item.MaU == MaU);
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
        public string getHoTenUserbyTaiKhoan(string TaiKhoan)
        {
            try
            {
                return db.Users.Single(item => item.TaiKhoan == TaiKhoan).HoTen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemTaiKhoan(User nguoidung)
        {
            try
            {
                if (CTaiKhoan.RoleTaiKhoan)
                {
                    if (!db.Users.Any(item => item.TaiKhoan == nguoidung.TaiKhoan))
                    {
                        if (db.Users.Count() > 0)
                            nguoidung.MaU = db.Users.Max(itemU => itemU.MaU) + 1;
                        else
                            nguoidung.MaU = 1;
                        nguoidung.CreateDate = DateTime.Now;
                        nguoidung.CreateBy = CTaiKhoan.TaiKhoan;
                        db.Users.InsertOnSubmit(nguoidung);
                        ///Cấp quyền mặc định = False
                        ///i tương ứng với số quyền trong bảng DetailRole
                        for (int i = 1; i <= 8; i++)
                        {
                            DetailRole qTaiKhoan = new DetailRole();
                            qTaiKhoan.MaR = i;
                            qTaiKhoan.CapQuyen = false;
                            nguoidung.DetailRoles.Add(qTaiKhoan);
                        }
                        db.SubmitChanges();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này đã có người sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public bool XoaTaiKhoan(User nguoidung)
        {
            try
            {
                if (CTaiKhoan.RoleTaiKhoan)
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
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public bool SuaTaiKhoan(User nguoidung,bool ChangedTaiKhoan)
        {
            try
            {
                if (CTaiKhoan.RoleTaiKhoan)
                {
                    if (ChangedTaiKhoan)
                        if (!db.Users.Any(item => item.TaiKhoan == nguoidung.TaiKhoan))
                        {
                            nguoidung.ModifyDate = DateTime.Now;
                            nguoidung.ModifyBy = CTaiKhoan.TaiKhoan;
                            db.SubmitChanges();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản này đã có người sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    else
                    {
                        nguoidung.ModifyDate = DateTime.Now;
                        nguoidung.ModifyBy = CTaiKhoan.TaiKhoan;
                        db.SubmitChanges();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// Cập nhật quyền truy cập của tài khoản
        /// </summary>
        /// <param name="MaR">int</param>
        /// <param name="Value">true/false</param>
        public bool SuaQuyen(int MaU, int MaR, bool Value)
        {
            try
            {
                if (CTaiKhoan.RoleTaiKhoan)
                {
                    db.DetailRoles.Single(itemRoleTaiKhoan => itemRoleTaiKhoan.MaU == MaU && itemRoleTaiKhoan.MaR == MaR).CapQuyen = Value;
                    db.DetailRoles.Single(itemRoleTaiKhoan => itemRoleTaiKhoan.MaU == MaU && itemRoleTaiKhoan.MaR == MaR).User.ModifyDate = DateTime.Now;
                    db.DetailRoles.Single(itemRoleTaiKhoan => itemRoleTaiKhoan.MaU == MaU && itemRoleTaiKhoan.MaR == MaR).User.ModifyBy = CTaiKhoan.TaiKhoan;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}

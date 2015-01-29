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
        /// <summary>
        /// Giảm Tiền Nước bao nhiêu %
        /// </summary>
        private const int _giamTienNuoc = 10;
        public static int GiamTienNuoc
        {
            get { return CTaiKhoan._giamTienNuoc; }
        } 

        private static int _maUser = -1;
        private static string _taiKhoan = "";
        private static string _hoTen = "";
        private static string _MaKiemBamChi = "";

        public static string MaKiemBamChi
        {
            get { return CTaiKhoan._MaKiemBamChi; }
            set { CTaiKhoan._MaKiemBamChi = value; }
        }


        private static bool _roleTaiKhoan_Xem = false;
        public static bool RoleTaiKhoan_Xem
        {
            get { return CTaiKhoan._roleTaiKhoan_Xem; }
            set { CTaiKhoan._roleTaiKhoan_Xem = value; }
        }

        private static bool _roleCapNhat_Xem = false;
        public static bool RoleCapNhat_Xem
        {
            get { return CTaiKhoan._roleCapNhat_Xem; }
            set { CTaiKhoan._roleCapNhat_Xem = value; }
        }

        private static bool _roleNhanDonKH_Xem = false;
        public static bool RoleNhanDonKH_Xem
        {
            get { return CTaiKhoan._roleNhanDonKH_Xem; }
            set { CTaiKhoan._roleNhanDonKH_Xem = value; }
        }

        private static bool _roleQLDonKH_Xem = false;
        public static bool RoleQLDonKH_Xem
        {
            get { return CTaiKhoan._roleQLDonKH_Xem; }
            set { CTaiKhoan._roleQLDonKH_Xem = value; }
        }

        private static bool _roleKTXM_Xem = false;
        public static bool RoleKTXM_Xem
        {
            get { return CTaiKhoan._roleKTXM_Xem; }
            set { CTaiKhoan._roleKTXM_Xem = value; }
        }

        private static bool _roleQLKTXM_Xem = false;
        public static bool RoleQLKTXM_Xem
        {
            get { return CTaiKhoan._roleQLKTXM_Xem; }
            set { CTaiKhoan._roleQLKTXM_Xem = value; }
        }

        private static bool _roleDCBD_Xem = false;
        public static bool RoleDCBD_Xem
        {
            get { return CTaiKhoan._roleDCBD_Xem; }
            set { CTaiKhoan._roleDCBD_Xem = value; }
        }

        private static bool _roleCHDB_Xem = false;
        public static bool RoleCHDB_Xem
        {
            get { return CTaiKhoan._roleCHDB_Xem; }
            set { CTaiKhoan._roleCHDB_Xem = value; }
        }

        private static bool _roleTTTL_Xem = false;
        public static bool RoleTTTL_Xem
        {
            get { return CTaiKhoan._roleTTTL_Xem; }
            set { CTaiKhoan._roleTTTL_Xem = value; }
        }

        private static bool _roleBamChi_Xem = false;
        public static bool RoleBamChi_Xem
        {
            get { return CTaiKhoan._roleBamChi_Xem; }
            set { CTaiKhoan._roleBamChi_Xem = value; }
        }

        private static bool _roleQLBamChi_Xem = false;
        public static bool RoleQLBamChi_Xem
        {
            get { return CTaiKhoan._roleQLBamChi_Xem; }
            set { CTaiKhoan._roleQLBamChi_Xem = value; }
        }

        private static bool _roleDongNuoc_Xem = false;
        public static bool RoleDongNuoc_Xem
        {
            get { return CTaiKhoan._roleDongNuoc_Xem; }
            set { CTaiKhoan._roleDongNuoc_Xem = value; }
        }

        ///

        private static bool _roleTaiKhoan_CapNhat = false;
        public static bool RoleTaiKhoan_CapNhat
        {
            get { return CTaiKhoan._roleTaiKhoan_CapNhat; }
            set { CTaiKhoan._roleTaiKhoan_CapNhat = value; }
        }

        private static bool _roleCapNhat_CapNhat = false;
        public static bool RoleCapNhat_CapNhat
        {
            get { return CTaiKhoan._roleCapNhat_CapNhat; }
            set { CTaiKhoan._roleCapNhat_CapNhat = value; }
        }

        private static bool _roleNhanDonKH_CapNhat = false;
        public static bool RoleNhanDonKH_CapNhat
        {
            get { return CTaiKhoan._roleNhanDonKH_CapNhat; }
            set { CTaiKhoan._roleNhanDonKH_CapNhat = value; }
        }

        private static bool _roleQLDonKH_CapNhat = false;
        public static bool RoleQLDonKH_CapNhat
        {
            get { return CTaiKhoan._roleQLDonKH_CapNhat; }
            set { CTaiKhoan._roleQLDonKH_CapNhat = value; }
        }

        private static bool _roleKTXM_CapNhat = false;
        public static bool RoleKTXM_CapNhat
        {
            get { return CTaiKhoan._roleKTXM_CapNhat; }
            set { CTaiKhoan._roleKTXM_CapNhat = value; }
        }

        private static bool _roleQLKTXM_CapNhat = false;
        public static bool RoleQLKTXM_CapNhat
        {
            get { return CTaiKhoan._roleQLKTXM_CapNhat; }
            set { CTaiKhoan._roleQLKTXM_CapNhat = value; }
        }

        private static bool _roleDCBD_CapNhat = false;
        public static bool RoleDCBD_CapNhat
        {
            get { return CTaiKhoan._roleDCBD_CapNhat; }
            set { CTaiKhoan._roleDCBD_CapNhat = value; }
        }

        private static bool _roleCHDB_CapNhat = false;
        public static bool RoleCHDB_CapNhat
        {
            get { return CTaiKhoan._roleCHDB_CapNhat; }
            set { CTaiKhoan._roleCHDB_CapNhat = value; }
        }

        private static bool _roleTTTL_CapNhat = false;
        public static bool RoleTTTL_CapNhat
        {
            get { return CTaiKhoan._roleTTTL_CapNhat; }
            set { CTaiKhoan._roleTTTL_CapNhat = value; }
        }

        private static bool _roleBamChi_CapNhat = false;
        public static bool RoleBamChi_CapNhat
        {
            get { return CTaiKhoan._roleBamChi_CapNhat; }
            set { CTaiKhoan._roleBamChi_CapNhat = value; }
        }

        private static bool _roleQLBamChi_CapNhat = false;
        public static bool RoleQLBamChi_CapNhat
        {
            get { return CTaiKhoan._roleQLBamChi_CapNhat; }
            set { CTaiKhoan._roleQLBamChi_CapNhat = value; }
        }

        private static bool _roleDongNuoc_CapNhat = false;
        public static bool RoleDongNuoc_CapNhat
        {
            get { return CTaiKhoan._roleDongNuoc_CapNhat; }
            set { CTaiKhoan._roleDongNuoc_CapNhat = value; }
        }

        ///
        public static int MaUser
        {
            get { return CTaiKhoan._maUser; }
            set { CTaiKhoan._maUser = value; }
        }
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
                db = new DB_KTKS_DonKHDataContext();
                if (db.Users.Any(item => item.TaiKhoan == taikhoan && item.MatKhau == matkhau && item.Login == false))
                {
                    _maUser = db.Users.SingleOrDefault(item => item.TaiKhoan == taikhoan).MaU;
                    _taiKhoan = db.Users.SingleOrDefault(item => item.TaiKhoan == taikhoan).TaiKhoan;
                    _hoTen = db.Users.SingleOrDefault(item => item.TaiKhoan == taikhoan).HoTen;
                    _MaKiemBamChi = db.Users.SingleOrDefault(item => item.TaiKhoan == taikhoan).MaKiemBamChi;

                    ///Mã Role Tài Khoản là 1
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 1).QuyenXem == true)
                        _roleTaiKhoan_Xem = true;
                    else
                        _roleTaiKhoan_Xem = false;

                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 1).QuyenCapNhat == true)
                        _roleTaiKhoan_CapNhat = true;
                    else
                        _roleTaiKhoan_CapNhat = false;
                    ///Mã Role Cập Nhật là 2
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 2).QuyenXem == true)
                        _roleCapNhat_Xem = true;
                    else
                        _roleCapNhat_Xem = false;

                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 2).QuyenCapNhat == true)
                        _roleCapNhat_CapNhat = true;
                    else
                        _roleCapNhat_CapNhat = false;
                    ///Mã Role Nhận Đơn Khách Hàng là 3
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 3).QuyenXem == true)
                        _roleNhanDonKH_Xem = true;
                    else
                        _roleNhanDonKH_Xem = false;

                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 3).QuyenCapNhat == true)
                        _roleNhanDonKH_CapNhat = true;
                    else
                        _roleNhanDonKH_CapNhat = false;
                    ///Mã Role Quản Lý Đơn Khách Hàng là 4
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 4).QuyenXem == true)
                        _roleQLDonKH_Xem = true;
                    else
                        _roleQLDonKH_Xem = false;

                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 4).QuyenCapNhat == true)
                        _roleQLDonKH_CapNhat = true;
                    else
                        _roleQLDonKH_CapNhat = false;
                    ///Mã Role Kiểm Tra Xác Minh là 5
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 5).QuyenXem == true)
                        _roleKTXM_Xem = true;
                    else
                        _roleKTXM_Xem = false;

                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 5).QuyenCapNhat == true)
                        _roleKTXM_CapNhat = true;
                    else
                        _roleKTXM_CapNhat = false;
                    ///Mã Role Quản Lý Kiểm Tra Xác Minh là 6
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 6).QuyenXem == true)
                        _roleQLKTXM_Xem = true;
                    else
                        _roleQLKTXM_Xem = false;

                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 6).QuyenCapNhat == true)
                        _roleQLKTXM_CapNhat = true;
                    else
                        _roleQLKTXM_CapNhat = false;
                    ///Mã Role Điều Chỉnh Biến Động là 7
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 7).QuyenXem == true)
                        _roleDCBD_Xem = true;
                    else
                        _roleDCBD_Xem = false;

                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 7).QuyenCapNhat == true)
                        _roleDCBD_CapNhat = true;
                    else
                        _roleDCBD_CapNhat = false;
                    ///Mã Role Cắt Hủy Danh Bộ là 8
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 8).QuyenXem == true)
                        _roleCHDB_Xem = true;
                    else
                        _roleCHDB_Xem = false;

                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 8).QuyenCapNhat == true)
                        _roleCHDB_CapNhat = true;
                    else
                        _roleCHDB_CapNhat = false;
                    ///Mã Role Thảo Thư Trả Lời là 9
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 9).QuyenXem == true)
                        _roleTTTL_Xem = true;
                    else
                        _roleTTTL_Xem = false;

                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 9).QuyenCapNhat == true)
                        _roleTTTL_CapNhat = true;
                    else
                        _roleTTTL_CapNhat = false;
                    ///Mã Role Bấm Chì là 10
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 10).QuyenXem == true)
                        _roleBamChi_Xem = true;
                    else
                        _roleBamChi_Xem = false;

                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 10).QuyenCapNhat == true)
                        _roleBamChi_CapNhat = true;
                    else
                        _roleBamChi_CapNhat = false;
                    ///Mã Role Quản Lý Bấm Chì là 11
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 11).QuyenXem == true)
                        _roleQLBamChi_Xem = true;
                    else
                        _roleQLBamChi_Xem = false;

                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 11).QuyenCapNhat == true)
                        _roleQLBamChi_CapNhat = true;
                    else
                        _roleQLBamChi_CapNhat = false;
                    ///Mã Role Đóng Nước là 12
                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 12).QuyenXem == true)
                        _roleDongNuoc_Xem = true;
                    else
                        _roleDongNuoc_Xem = false;

                    if (db.DetailRoles.FirstOrDefault(item => item.User.TaiKhoan == taikhoan && item.MaR == 12).QuyenCapNhat == true)
                        _roleDongNuoc_CapNhat = true;
                    else
                        _roleDongNuoc_CapNhat = false;
                    //db.Users.Single(item => item.TaiKhoan == taikhoan && item.MatKhau == matkhau).Login = true;
                    //db.SubmitChanges();
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
            _maUser = -1;
            _taiKhoan = "";
            _hoTen = "";
            _MaKiemBamChi = "";
            _roleTaiKhoan_Xem = false;
            _roleCapNhat_Xem = false;
            _roleNhanDonKH_Xem = false;
            _roleQLDonKH_Xem = false;
            _roleKTXM_Xem = false;
            _roleQLKTXM_Xem = false;
            _roleDCBD_Xem = false;
            _roleCHDB_Xem = false;
            _roleTTTL_Xem = false;
            _roleBamChi_Xem = false;
            _roleQLBamChi_Xem = false;
            _roleDongNuoc_Xem = false;
            ///
            _roleTaiKhoan_CapNhat = false;
            _roleCapNhat_CapNhat = false;
            _roleNhanDonKH_CapNhat = false;
            _roleQLDonKH_CapNhat = false;
            _roleKTXM_CapNhat = false;
            _roleQLKTXM_CapNhat = false;
            _roleDCBD_CapNhat = false;
            _roleCHDB_CapNhat = false;
            _roleTTTL_CapNhat = false;
            _roleBamChi_CapNhat = false;
            _roleQLBamChi_CapNhat = false;
            _roleDongNuoc_CapNhat = false;
            ///
            db.Connection.Close();
        }

        /// <summary>
        /// Lấy danh sách tài khoản
        /// </summary>
        /// <returns>datatable</returns>
        public DataTable LoadDSTaiKhoan_Old()
        {
            try
            {
                if (CTaiKhoan.RoleTaiKhoan_Xem||CTaiKhoan.RoleTaiKhoan_CapNhat)
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
        /// Lấy danh sách tài khoản
        /// </summary>
        /// <returns></returns>
        public List<User> LoadDSTaiKhoan()
        {
            try
            {
                if (CTaiKhoan.RoleTaiKhoan_Xem || CTaiKhoan.RoleTaiKhoan_CapNhat)
                {
                    return db.Users.Where(itemUser => itemUser.MaU != 0 && itemUser.TaiKhoan != TaiKhoan).ToList();
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
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
        /// Lấy tài khoản
        /// </summary>
        /// <param name="MaU">int</param>
        /// <returns>class</returns>
        public User getUserbyID(int MaU)
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

        public bool ThemTaiKhoan(User nguoidung)
        {
            try
            {
                if (CTaiKhoan.RoleTaiKhoan_CapNhat)
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
                        for (int i = 1; i <= 12; i++)
                        {
                            DetailRole qTaiKhoan = new DetailRole();
                            qTaiKhoan.MaR = i;
                            qTaiKhoan.QuyenXem = false;
                            qTaiKhoan.QuyenCapNhat = false;
                            nguoidung.DetailRoles.Add(qTaiKhoan);
                        }
                        db.SubmitChanges();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này đã có người sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.Users);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public bool XoaTaiKhoan(User nguoidung)
        {
            try
            {
                if (CTaiKhoan.RoleTaiKhoan_CapNhat)
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

        public bool SuaTaiKhoan(User nguoidung,bool ChangedTaiKhoan)
        {
            try
            {
                if (CTaiKhoan.RoleTaiKhoan_CapNhat)
                {
                    if (ChangedTaiKhoan)
                        if (!db.Users.Any(item => item.TaiKhoan == nguoidung.TaiKhoan))
                        {
                            nguoidung.ModifyDate = DateTime.Now;
                            nguoidung.ModifyBy = CTaiKhoan.MaUser;
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
                    else
                    {
                        nguoidung.ModifyDate = DateTime.Now;
                        nguoidung.ModifyBy = CTaiKhoan.MaUser;
                        db.SubmitChanges();
                        //MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// Cập nhật quyền truy cập của tài khoản
        /// </summary>
        /// <param name="MaR">int</param>
        /// <param name="Value">true/false</param>
        public bool SuaQuyen(int MaU, int MaR, string Quyen,bool Value)
        {
            try
            {
                if (CTaiKhoan.RoleTaiKhoan_CapNhat)
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
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.DetailRoles);
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
                if (CTaiKhoan.RoleTaiKhoan_Xem || CTaiKhoan.RoleTaiKhoan_CapNhat)
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
                    return CLinQToDataTable.LINQToDataTable(queryRoles);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

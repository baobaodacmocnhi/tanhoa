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
    class CTaiKhoan
    {
        DB_KTKS_DonKHDataContext db = new DB_KTKS_DonKHDataContext();
        public DataTable LoadDSTaiKhoan()
        {
           if(CDangNhap.RoleTaiKhoan)
           {
               var taikhoans = from itemUser in db.Users
                               where itemUser.MaU != 0
                               select new
                               {
                                   MaU = itemUser.MaU,
                                   HoTen = itemUser.HoTen,
                                   TaiKhoan = itemUser.TaiKhoan,
                                   MatKhau = itemUser.MatKhau,
                               };
               //1 tài khoản có nhiều quyền chưa biết làm ntn nên jờ tạm làm theo cách chạy vòng lập add từng record
               DataTable table = new DataTable();
               table.Columns.Add("STT", typeof(string));
               table.Columns.Add("MaU", typeof(string));
               table.Columns.Add("HoTen", typeof(string));
               table.Columns.Add("TaiKhoan", typeof(string));
               table.Columns.Add("MatKhau", typeof(string));
               table.Columns.Add("QTaiKhoan", typeof(bool));
               table.Columns.Add("QToKhachHang", typeof(bool));

               int i = 1;
               foreach (var itemTK in taikhoans)
               {
                   var quyens = from itemDetailRole in db.DetailRoles
                                where itemDetailRole.MaU == itemTK.MaU
                                orderby itemDetailRole.MaR ascending
                                select itemDetailRole;

                   //MaR=1 => quyền tài khoản
                   //MaR=2 => quyền tổ khách hàng

                   table.Rows.Add(i++, itemTK.MaU, itemTK.HoTen, itemTK.TaiKhoan, itemTK.MatKhau,
                                   quyens.FirstOrDefault(itemQ => itemQ.MaR == 1).CapQuyen,
                                   quyens.FirstOrDefault(itemQ => itemQ.MaR == 2).CapQuyen
                                   );
               }
               return table;
           }
           else
               MessageBox.Show("Tài khoản này không có quyền","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
           return null;
        }

        public User getUserbyID(int MaU)
        {
            return db.Users.Single(item => item.MaU == MaU);
        }

        public void ThemTaiKhoan(User nguoidung)
        {
            if (CDangNhap.RoleTaiKhoan)
            {
                if (!db.Users.Any(item => item.TaiKhoan == nguoidung.TaiKhoan))
                {
                    nguoidung.MaU = db.Users.OrderByDescending(item => item.MaU).FirstOrDefault().MaU + 1;
                    nguoidung.CreateDate = DateTime.Now;
                    nguoidung.CreateBy = CDangNhap.TaiKhoan;
                    db.Users.InsertOnSubmit(nguoidung);
                    //Cấp quyền mặc định = False
                    //i tương ứng với số quyền trong bảng DetailRole
                    for (int i = 1; i <= 2; i++)
                    {
                        DetailRole qTaiKhoan = new DetailRole();
                        qTaiKhoan.MaR = i;
                        qTaiKhoan.CapQuyen = false;
                        nguoidung.DetailRoles.Add(qTaiKhoan);
                    }
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        db = new DB_KTKS_DonKHDataContext();
                    }
                    
                }
                else
                    MessageBox.Show("Tài khoản này đã có người sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void XoaTaiKhoan(User nguoidung)
        {
            if (CDangNhap.RoleTaiKhoan)
            {
                try
                {
                    foreach (var itemDetailRole in db.DetailRoles.Where(itemTaiKhoan=>itemTaiKhoan.MaU==nguoidung.MaU))
                    {
                        db.DetailRoles.DeleteOnSubmit(itemDetailRole);
                    }
                    db.Users.DeleteOnSubmit(nguoidung);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SuaTaiKhoan(User nguoidung,bool ChangedTaiKhoan)
        {
            if (CDangNhap.RoleTaiKhoan)
            {
                if (ChangedTaiKhoan)
                    if (!db.Users.Any(item => item.TaiKhoan == nguoidung.TaiKhoan))
                    {
                        try
                        {
                            db.SubmitChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Tài khoản này đã có người sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    try
                    {
                        db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            else
                MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.HeThong;
using KTKS_DonKH.LinQ;
using System.Data;
using KTKS_DonKH.Function;

namespace KTKS_DonKH.DAL.KhachHang
{
    class CDonDienThoai:CDAL
    {
        public bool ThemDonDienThoai(DonDienThoai dondt)
        {
            try
            {
                if (CTaiKhoan.RoleNhanDonKH_CapNhat)
                {
                    if (db.DonDienThoais.Count() > 0)
                    {
                        string ID = "MaDonDT";
                        string Table = "DonDienThoai";
                        decimal MaDonDT = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        dondt.MaDonDT = getMaxNextIDTable(MaDonDT);
                    }
                    else
                        dondt.MaDonDT = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    dondt.CreateDate = DateTime.Now;
                    dondt.CreateBy = CTaiKhoan.MaUser;
                    db.DonDienThoais.InsertOnSubmit(dondt);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm DonDienThoai", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.DonDienThoais);
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

        public bool SuaDonDienThoai(DonDienThoai dondt)
        {
            try
            {
                if (CTaiKhoan.RoleQLDonKH_CapNhat)
                {
                    dondt.ModifyDate = DateTime.Now;
                    dondt.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa DonDienThoai", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.DonDienThoais);
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

        public bool XoaDonDienThoai(DonDienThoai dondt)
        {
            try
            {
                if (CTaiKhoan.RoleQLDonKH_CapNhat)
                {
                    db.DonDienThoais.DeleteOnSubmit(dondt);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Xóa DonDienThoai", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.DonDienThoais);
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

        public bool CheckLapDonKH(decimal MaDonDT)
        {
            try
            {
                return db.DonDienThoais.Any(item => item.MaDonDT == MaDonDT && item.MaDon != null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DonDienThoai getDonDienThoaibyID(decimal MaDonDT)
        {
            try
            {
                return db.DonDienThoais.SingleOrDefault(item => item.MaDonDT == MaDonDT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDSDonDienThoai()
        {
            try
            {
                if (CTaiKhoan.RoleQLDonKH_Xem || CTaiKhoan.RoleQLDonKH_CapNhat)
                {
                    return CLinQToDataTable.LINQToDataTable(db.DonDienThoais.ToList());
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

        public DataTable getDSDonDienThoaiByDanhBo(string DanhBo)
        {
            try
            {
                if (CTaiKhoan.RoleQLDonKH_Xem || CTaiKhoan.RoleQLDonKH_CapNhat)
                {
                    var query= from item in db.DonDienThoais
                               where item.DanhBo == DanhBo
                               orderby item.CreateDate descending
                               select new
                               {
                                   In=false,
                                   LapDon=false,
                                   item.MaDon,
                                   item.CreateDate,
                                   item.DanhBo,
                                   item.HoTen,
                                   item.DiaChi,
                                   item.GiaBieu,
                                   item.DinhMuc,
                                   item.NoiDung,
                                   item.GhiChu,
                                   item.NguoiBao,
                                   item.DienThoai,
                               };
                    return CLinQToDataTable.LINQToDataTable(query);
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

        public DataTable getDSDonDienThoaiByDiaChi(string DiaChi)
        {
            try
            {
                if (CTaiKhoan.RoleQLDonKH_Xem || CTaiKhoan.RoleQLDonKH_CapNhat)
                {
                    var query = from item in db.DonDienThoais
                                where item.DiaChi.Contains(DiaChi)
                                orderby item.CreateDate descending
                                select new
                                {
                                    In = false,
                                    LapDon = false,
                                    item.MaDon,
                                    item.CreateDate,
                                    item.DanhBo,
                                    item.HoTen,
                                    item.DiaChi,
                                    item.GiaBieu,
                                    item.DinhMuc,
                                    item.NoiDung,
                                    item.GhiChu,
                                    item.NguoiBao,
                                    item.DienThoai,
                                };
                    return CLinQToDataTable.LINQToDataTable(query);
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

        public DataTable getDSDonDienThoaiByDate(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleQLDonKH_Xem || CTaiKhoan.RoleQLDonKH_CapNhat)
                {
                    var query = from item in db.DonDienThoais
                                where item.CreateDate.Value.Date == TuNgay.Date
                                //orderby item.CreateDate descending
                                select new
                                {
                                    In = false,
                                    LapDon = false,
                                    item.MaDon,
                                    item.CreateDate,
                                    item.DanhBo,
                                    item.HoTen,
                                    item.DiaChi,
                                    item.GiaBieu,
                                    item.DinhMuc,
                                    item.NoiDung,
                                    item.GhiChu,
                                    item.NguoiBao,
                                    item.DienThoai,
                                };
                    return CLinQToDataTable.LINQToDataTable(query);
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

        public DataTable getDSDonDienThoaiByDates(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleQLDonKH_Xem || CTaiKhoan.RoleQLDonKH_CapNhat)
                {
                    var query = from item in db.DonDienThoais
                                where item.CreateDate.Value.Date >= TuNgay.Date && item.CreateDate.Value <= DenNgay.Date
                                //orderby item.CreateDate descending
                                select new
                                {
                                    In = false,
                                    LapDon = false,
                                    item.MaDon,
                                    item.CreateDate,
                                    item.DanhBo,
                                    item.HoTen,
                                    item.DiaChi,
                                    item.GiaBieu,
                                    item.DinhMuc,
                                    item.NoiDung,
                                    item.GhiChu,
                                    item.NguoiBao,
                                    item.DienThoai,
                                };
                    return CLinQToDataTable.LINQToDataTable(query);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;
using System.Data;

namespace KTKS_DonKH.DAL.ToKhachHang
{
    class CDonDienThoai:CDAL
    {
        public bool Them(DonDienThoai dondt)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool Sua(DonDienThoai dondt)
        {
            try
            {
                    dondt.ModifyDate = DateTime.Now;
                    dondt.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa DonDienThoai", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
                return false;
            }
        }

        public bool Xoa(DonDienThoai dondt)
        {
            try
            {
                    db.DonDienThoais.DeleteOnSubmit(dondt);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Xóa DonDienThoai", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new dbKinhDoanhDataContext();
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
                    return LINQToDataTable(db.DonDienThoais.ToList());
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
                    var query= from item in db.DonDienThoais
                               where item.DanhBo == DanhBo
                               orderby item.CreateDate descending
                               select new
                               {
                                   In=false,
                                   LapDon=false,
                                   item.MaDonDT,
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
                                   item.NgayBao,
                                   item.DienThoai,
                               };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDSDonDienThoaiByDanhBo(int MaUser, string DanhBo)
        {
            try
            {
                    var query = from item in db.DonDienThoais
                                where item.DanhBo == DanhBo && item.CreateBy==MaUser
                                orderby item.CreateDate descending
                                select new
                                {
                                    In = false,
                                    LapDon = false,
                                    item.MaDonDT,
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
                                    item.NgayBao,
                                    item.DienThoai,
                                };
                    return LINQToDataTable(query);
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
                    var query = from item in db.DonDienThoais
                                where item.DiaChi.Contains(DiaChi)
                                orderby item.CreateDate descending
                                select new
                                {
                                    In = false,
                                    LapDon = false,
                                    item.MaDonDT,
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
                                    item.NgayBao,
                                    item.DienThoai,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDSDonDienThoaiByDiaChi(int MaUser, string DiaChi)
        {
            try
            {
                    var query = from item in db.DonDienThoais
                                where item.DiaChi.Contains(DiaChi) && item.CreateBy == MaUser
                                orderby item.CreateDate descending
                                select new
                                {
                                    In = false,
                                    LapDon = false,
                                    item.MaDonDT,
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
                                    item.NgayBao,
                                    item.DienThoai,
                                };
                    return LINQToDataTable(query);
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
                    var query = from item in db.DonDienThoais
                                where item.CreateDate.Value.Date == TuNgay.Date
                                //orderby item.CreateDate descending
                                select new
                                {
                                    In = false,
                                    LapDon = false,
                                    item.MaDonDT,
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
                                    item.NgayBao,
                                    item.DienThoai,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDSDonDienThoaiByDate(int MaUser, DateTime TuNgay)
        {
            try
            {
                    var query = from item in db.DonDienThoais
                                where item.CreateDate.Value.Date == TuNgay.Date && item.CreateBy == MaUser
                                //orderby item.CreateDate descending
                                select new
                                {
                                    In = false,
                                    LapDon = false,
                                    item.MaDonDT,
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
                                    item.NgayBao,
                                    item.DienThoai,
                                };
                    return LINQToDataTable(query);
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
                    var query = from item in db.DonDienThoais
                                where item.CreateDate.Value.Date >= TuNgay.Date && item.CreateDate.Value.Date <= DenNgay.Date
                                //orderby item.CreateDate descending
                                select new
                                {
                                    In = false,
                                    LapDon = false,
                                    item.MaDonDT,
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
                                    item.NgayBao,
                                    item.DienThoai,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable getDSDonDienThoaiByDates(int MaUser, DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                    var query = from item in db.DonDienThoais
                                where item.CreateDate.Value.Date >= TuNgay.Date && item.CreateDate.Value.Date<= DenNgay.Date && item.CreateBy == MaUser
                                //orderby item.CreateDate descending
                                select new
                                {
                                    In = false,
                                    LapDon = false,
                                    item.MaDonDT,
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
                                    item.NgayBao,
                                    item.DienThoai,
                                };
                    return LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

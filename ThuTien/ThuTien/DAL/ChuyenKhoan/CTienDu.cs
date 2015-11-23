using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Windows.Forms;
using System.Data;

namespace ThuTien.DAL.ChuyenKhoan
{
    class CTienDu : CDAL
    {
        //Quản lý tiền dư của khách hàng

        public bool Them(TT_TienDu tiendu)
        {
            try
            {
                tiendu.CreateDate = DateTime.Now;
                tiendu.CreateBy = CNguoiDung.MaND;
                tiendu.ModifyDate = DateTime.Now;
                tiendu.ModifyBy = CNguoiDung.MaND;
                _db.TT_TienDus.InsertOnSubmit(tiendu);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                _db = new dbThuTienDataContext();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Sua(TT_TienDu tiendu)
        {
            try
            {
                tiendu.ModifyDate = DateTime.Now;
                tiendu.ModifyBy = CNguoiDung.MaND;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable GetDSTienAm()
        {
            return LINQToDataTable( _db.TT_TienDus.Where(item => item.SoTien < 0).ToList());
        }

        public DataTable GetDSTienDu()
        {
            return LINQToDataTable( _db.TT_TienDus.Where(item => item.SoTien > 0||item.Phi>0).ToList());
        }

        public DataTable GetDSTienDu(DateTime NgayGiaiTrach)
        {
            string sql = "declare @NgayGiaiTrach date;"
                    + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyy-MM-dd") + "'"
                    + " select a.DanhBo,CASE WHEN b.SoTien is null THEN a.SoTien ELSE a.SoTien-b.SoTien END as SoTien from"
                    + " (select DanhBo,SoTien from TT_TienDu) a"
                    + " left join"
                    + " (select DanhBo,SUM(SoTien) as SoTien from TT_TienDuLichSu where CAST(CreateDate as date)>@NgayGiaiTrach group by DanhBo) b on a.DanhBo=b.DanhBo"
                    + " where case when b.SoTien is null then a.SoTien else a.SoTien-b.SoTien end>0";
            return ExecuteQuery_SqlDataAdapter_DataTable(sql);
        }

        public DataTable GetDSTienBienDong()
        {
            return LINQToDataTable( _db.TT_TienDus.Where(item => item.SoTien != 0).ToList());
        }

        public TT_TienDu Get(string DanhBo)
        {
            return _db.TT_TienDus.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public bool CheckExist(string DanhBo)
        {
            return _db.TT_TienDus.Any(item => item.DanhBo == DanhBo);
        }

        public bool Update(string DanhBo, int SoTien,string Loai,string GhiChu)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien+" + SoTien + ",ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo='" + DanhBo + "'"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'"+GhiChu+"'," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values('" + DanhBo + "'," + SoTien + "," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'"+GhiChu+"'," + CNguoiDung.MaND + ",GETDATE())");
                    }
                    else
                    {
                        return false;
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool Update(string DanhBo, int SoTien, string Loai, string GhiChu,string DanhBoChuyenNhan)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien+" + SoTien + ",ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo='" + DanhBo + "'"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,DanhBoChuyenNhan,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "','"+DanhBoChuyenNhan+"'," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values('" + DanhBo + "'," + SoTien + "," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,DanhBoChuyenNhan,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "','"+DanhBoChuyenNhan+"'," + CNguoiDung.MaND + ",GETDATE())");
                    }
                    else
                    {
                        return false;
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateThem(string SoHoaDon)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien-(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo=(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "')"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Thêm'," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values((select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Thêm'," + CNguoiDung.MaND + ",GETDATE())");
                    }
                    else
                    {
                        return false;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateThemTienMat(string SoHoaDon)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien-(select TienDu from HOADON where SOHOADON='" + SoHoaDon + "'),ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo=(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "')"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu=-TienDu from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Thêm'," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values((select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu=-TienDu from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu=-TienDu from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Thêm'," + CNguoiDung.MaND + ",GETDATE())");
                    }
                    else
                    {
                        return false;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateXoa(string SoHoaDon)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien+(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo=(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "')"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Xóa'," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values((select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Xóa'," + CNguoiDung.MaND + ",GETDATE())");
                    }
                    else
                    {
                        return false;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateXoaTienMat(string SoHoaDon)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien+(select TienDu from HOADON where SOHOADON='" + SoHoaDon + "'),ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo=(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "')"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Xóa'," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values((select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Xóa'," + CNguoiDung.MaND + ",GETDATE())");
                    }
                    else
                    {
                        return false;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public long GetTongTienTonDauNgay(DateTime CreateDate)
        {
            if (_db.TT_TienDuLichSus.Any(item => item.CreateDate.Value.Date >= CreateDate.Date))
                return (long)(_db.TT_TienDus.Sum(item => item.SoTien) - _db.TT_TienDuLichSus.Where(item => item.CreateDate.Value.Date >= CreateDate.Date).Sum(item => item.SoTien));
            else
                return (long)(_db.TT_TienDus.Sum(item => item.SoTien));
        }

        public long GetTongTienTonDenNgay(DateTime CreateDate)
        {
            if (_db.TT_TienDuLichSus.Any(item => item.CreateDate.Value.Date > CreateDate.Date))
                return (long)(_db.TT_TienDus.Sum(item => item.SoTien) - _db.TT_TienDuLichSus.Where(item => item.CreateDate.Value.Date > CreateDate.Date).Sum(item => item.SoTien));
            else
                return (long)(_db.TT_TienDus.Sum(item => item.SoTien));
        }

        public int GetTienDu(string DanhBo)
        {
            if (_db.TT_TienDus.Any(item => item.DanhBo == DanhBo))
                return _db.TT_TienDus.SingleOrDefault(item => item.DanhBo == DanhBo).SoTien.Value;
            else
                return 0;
        }

        public DataTable GetDSLichSu(string DanhBo)
        {
            return LINQToDataTable(_db.TT_TienDuLichSus.Where(item => item.DanhBo == DanhBo).OrderByDescending(item=>item.CreateDate).ToList());
        }

        public DataTable GetDSLichSu(string Loai,DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(_db.TT_TienDuLichSus.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.Loai.Contains(Loai)));
        }

    }
}

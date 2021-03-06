﻿using System;
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
            return LINQToDataTable(_db.TT_TienDus.Where(item => item.SoTien < 0).ToList());
        }

        public DataTable GetDSTienDu()
        {
            return LINQToDataTable(_db.TT_TienDus.Where(item => item.SoTien > 0).ToList());
        }

        public DataTable GetDSPhiMoNuoc()
        {
            return LINQToDataTable(_db.TT_TienDus.Where(item => item.Phi > 0).ToList());
        }

        public DataTable GetDSTienDu(DateTime NgayGiaiTrach)
        {
            string sql = "declare @NgayGiaiTrach date;"
                    + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "'"
                    + " select a.DanhBo,CASE WHEN b.SoTien is null THEN a.SoTien ELSE a.SoTien-b.SoTien END as SoTien,DienThoai from"
                    + " (select DanhBo,SoTien from TT_TienDu) a"
                    + " left join"
                    + " (select DanhBo,SUM(SoTien) as SoTien from TT_TienDuLichSu where CAST(CreateDate as date)>@NgayGiaiTrach group by DanhBo) b on a.DanhBo=b.DanhBo"
                    + " left join"
                    + " (select DanhBo,DienThoai from TT_ThongTinKhachHang) c on a.DanhBo=c.DanhBo"
                    + " where case when b.SoTien is null then a.SoTien else a.SoTien-b.SoTien end >0"
                    + " order by DanhBo";
            return ExecuteQuery_DataTable(sql);
        }

        public DataTable GetDSTienBienDong()
        {
            return LINQToDataTable(_db.TT_TienDus.Where(item => item.SoTien != 0).ToList());
        }

        public TT_TienDu Get(string DanhBo)
        {
            return _db.TT_TienDus.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public bool CheckExist(string DanhBo)
        {
            return _db.TT_TienDus.Any(item => item.DanhBo == DanhBo);
        }

        public bool Update(string DanhBo, int SoTien, string Loai, string GhiChu)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien+" + SoTien + ",ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo='" + DanhBo + "'"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "'," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values('" + DanhBo + "'," + SoTien + "," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "'," + CNguoiDung.MaND + ",GETDATE())");
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

        public bool Update(string DanhBo, int SoTien, string Loai, string GhiChu, DateTime CreateDate)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien+" + SoTien + ",ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + CreateDate.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "' where DanhBo='" + DanhBo + "'"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate,CreateDate2) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "'," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "',GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values('" + DanhBo + "'," + SoTien + "," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "'," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "')"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate,CreateDate2) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "'," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "',GETDATE())");
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

        public bool Update(string DanhBo, int SoTien, string Loai, string GhiChu, int MaNH)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien+" + SoTien + ",MaNH=" + MaNH + ",ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo='" + DanhBo + "'"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "'," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,MaNH,CreateBy,CreateDate,ModifyBy,ModifyDate) values('" + DanhBo + "'," + SoTien + "," + MaNH + "," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "'," + CNguoiDung.MaND + ",GETDATE())");
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

        public bool Update(string DanhBo, int SoTien, string Loai, string GhiChu, int MaNH, DateTime CreateDate)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien+" + SoTien + ",MaNH=" + MaNH + ",ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + CreateDate.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "' where DanhBo='" + DanhBo + "'"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate,CreateDate2) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "'," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "',GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,MaNH,CreateBy,CreateDate,ModifyBy,ModifyDate) values('" + DanhBo + "'," + SoTien + "," + MaNH + "," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "'," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "')"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate,CreateDate2) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "'," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "',GETDATE())");
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

        public bool Update(string DanhBo, int SoTien, string Loai, string GhiChu, string DanhBoChuyenNhan)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien+" + SoTien + ",ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo='" + DanhBo + "'"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,DanhBoChuyenNhan,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "','" + DanhBoChuyenNhan + "'," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values('" + DanhBo + "'," + SoTien + "," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,DanhBoChuyenNhan,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "','" + DanhBoChuyenNhan + "'," + CNguoiDung.MaND + ",GETDATE())");
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
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaHD,SoHoaDon,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Thêm '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),(select ID_HOADON from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values((select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaHD,SoHoaDon,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Thêm '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),(select ID_HOADON from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",GETDATE())");
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

        public bool UpdateThem_Doi(string SoHoaDon, DateTime CreateDate)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien-(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo=(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "')"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaHD,SoHoaDon,CreateBy,CreateDate,CreateDate2) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Thêm '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),(select ID_HOADON from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd HH:mm:ss") + "',GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values((select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaHD,SoHoaDon,CreateBy,CreateDate,CreateDate2) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Thêm '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),(select ID_HOADON from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd HH:mm:ss") + "',GETDATE())");
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
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaHD,SoHoaDon,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu=-TienDu from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân Tiền Mặt',N'Thêm '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),(select ID_HOADON from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values((select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu=-TienDu from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaHD,SoHoaDon,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu=-TienDu from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân Tiền Mặt',N'Thêm '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),(select ID_HOADON from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",GETDATE())");
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

        public bool UpdateThemTienMat_Doi(string SoHoaDon, DateTime CreateDate)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien-(select TienDu from HOADON where SOHOADON='" + SoHoaDon + "'),ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo=(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "')"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaHD,SoHoaDon,CreateBy,CreateDate,CreateDate2) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu=-TienDu from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân Tiền Mặt',N'Thêm '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),(select ID_HOADON from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd HH:mm:ss") + "',GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values((select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu=-TienDu from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaHD,SoHoaDon,CreateBy,CreateDate,CreateDate2) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu=-TienDu from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân Tiền Mặt',N'Thêm '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),(select ID_HOADON from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd HH:mm:ss") + "',GETDATE())");
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
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaHD,SoHoaDon,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Xóa '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),(select ID_HOADON from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values((select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaHD,SoHoaDon,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Xóa '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),(select ID_HOADON from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",GETDATE())");
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

        public bool UpdateXoa_Doi(string SoHoaDon, DateTime CreateDate)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien+(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo=(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "')"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaHD,SoHoaDon,CreateBy,CreateDate,CreateDate2) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Xóa '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),(select ID_HOADON from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd HH:mm:ss") + "',GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values((select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaHD,SoHoaDon,CreateBy,CreateDate,CreateDate2) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Xóa '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),(select ID_HOADON from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd HH:mm:ss") + "',GETDATE())");
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
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaHD,SoHoaDon,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Xóa '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),(select ID_HOADON from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values((select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaHD,SoHoaDon,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Xóa '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),(select ID_HOADON from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",GETDATE())");
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

        public bool UpdateXoaTienMat_Doi(string SoHoaDon, DateTime CreateDate)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien+(select TienDu from HOADON where SOHOADON='" + SoHoaDon + "'),ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo=(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "')"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaHD,SoHoaDon,CreateBy,CreateDate,CreateDate2) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Xóa '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),(select ID_HOADON from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd HH:mm:ss") + "',GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values((select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaHD,SoHoaDon,CreateBy,CreateDate,CreateDate2) values((select MAX(ID)+1 from TT_TienDuLichSu),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TienDu from HOADON where SOHOADON='" + SoHoaDon + "'),N'Đăng Ngân',N'Xóa '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),(select ID_HOADON from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd HH:mm:ss") + "',GETDATE())");
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
                return (long)(_db.TT_TienDus.Sum(item => (long)item.SoTien) - _db.TT_TienDuLichSus.Where(item => item.CreateDate.Value.Date >= CreateDate.Date).Sum(item => (long)item.SoTien));
            else
                return (long)(_db.TT_TienDus.Sum(item => (long)item.SoTien));
        }

        public long GetTongTienTonDenNgay(DateTime CreateDate)
        {
            if (_db.TT_TienDuLichSus.Any(item => item.CreateDate.Value.Date > CreateDate.Date))
                return (long)(_db.TT_TienDus.Sum(item => (long)item.SoTien) - _db.TT_TienDuLichSus.Where(item => item.CreateDate.Value.Date > CreateDate.Date).Sum(item => (long)item.SoTien));
            else
                return (long)(_db.TT_TienDus.Sum(item => (long)item.SoTien));
        }

        public int GetTienDu(string DanhBo)
        {
            if (_db.TT_TienDus.Any(item => item.DanhBo == DanhBo))
                return _db.TT_TienDus.SingleOrDefault(item => item.DanhBo == DanhBo).SoTien.Value;
            else
                return 0;
        }

        public int GetTienDu_SoHoaDon(string SoHoaDon)
        {
            if (_db.TT_TienDus.Any(item => item.DanhBo == _db.HOADONs.SingleOrDefault(itemHD => itemHD.SOHOADON == SoHoaDon).DANHBA))
                return _db.TT_TienDus.SingleOrDefault(item => item.DanhBo == _db.HOADONs.SingleOrDefault(itemHD => itemHD.SOHOADON == SoHoaDon).DANHBA).SoTien.Value;
            else
                return 0;
        }

        public DataTable GetDSLichSu(string DanhBo)
        {
            return LINQToDataTable(_db.TT_TienDuLichSus.Where(item => item.DanhBo == DanhBo).OrderByDescending(item => item.CreateDate).ToList());
        }

        public DataTable GetDSLichSu(string Loai, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(_db.TT_TienDuLichSus.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.Loai.Contains(Loai)));
        }

        public DataTable getThongKe(DateTime NgayGiaiTrach)
        {
            //(select DATEADD(DAY, -1, @Ngay)
            string sql = "declare @Ngay date"
                    + " set @Ngay='" + NgayGiaiTrach.ToString("yyyyMMdd")+ "'"
                    + " select"
                    + " TienDau=(select SUM(cast(SoTien as numeric(12, 0))) from TT_TienDu)-(select SUM(cast(SoTien as numeric(12, 0))) from TT_TienDuLichSu where CAST(CreateDate as date)>=@Ngay)"
                    + " ,BangKe=(select SUM(cast(SoTien as numeric(12, 0))) from TT_BangKe where CAST(CreateDate as date)=@Ngay)"
                    + " ,GiaiTrach=(select SUM(cast(TongCong as numeric(12, 0))) from HOADON where CAST(NGAYGIAITRACH as date)=@Ngay and DangNgan_ChuyenKhoan=1)"
                    + " ,TienMat=(select SUM(cast(TienMat as numeric(12, 0))) from HOADON where CAST(NGAYGIAITRACH as date)=@Ngay and DangNgan_ChuyenKhoan=1)"
                    + " ,PhiMoNuoc=(select SUM(cast(PhiMoNuoc as numeric(12, 0))) from TT_PhiMoNuoc where CAST(CreateDate as date)=@Ngay)"
                    + " ,DieuChinh=(select SUM(cast(SoTien as numeric(12, 0))) from TT_TienDuLichSu where Loai like N'%Điều Chỉnh%' and GhiChu not like N'%Phí Mở Nước%' and CAST(CreateDate as date)=@Ngay)"
                    + " ,TienCuoi=(select SUM(cast(SoTien as numeric(12, 0))) from TT_TienDu)-(select SUM(cast(SoTien as numeric(12, 0))) from TT_TienDuLichSu where CAST(CreateDate as date)>@Ngay)";
            return ExecuteQuery_DataTable(sql);
        }

    }
}

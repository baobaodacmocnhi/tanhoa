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
                Refresh();
                throw ex;
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
                throw ex;
            }
        }

        public DataTable GetDSTienAm(int FromDot, int ToDot)
        {
            //return LINQToDataTable(_db.TT_TienDus.Where(item => item.SoTien < 0).ToList());
            return ExecuteQuery_DataTable("with temp as"
                + " ("
                + " select Dot=SUBSTRING(ttkh.LOTRINH,1,2),td.* from TT_TienDu td left join CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh on td.DanhBo=ttkh.DANHBO where SoTien<0"
                + " )"
                + " select * from temp where Dot>=" + FromDot + " and Dot<=" + ToDot
                + " union all"
                + " select * from temp where Dot is null"
                + " order by DanhBo");
        }

        public DataTable GetDSTienDu(int FromDot, int ToDot)
        {
            //return LINQToDataTable(_db.TT_TienDus.Where(item => item.SoTien > 0).ToList());
            return ExecuteQuery_DataTable("with temp as"
               + " ("
               + " select Dot=SUBSTRING(ttkh.LOTRINH,1,2),td.* from TT_TienDu td left join CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh on td.DanhBo=ttkh.DANHBO where SoTien>0"
               + " )"
               + " select * from temp where Dot>=" + FromDot + " and Dot<=" + ToDot
               + " union all"
               + " select * from temp where Dot is null"
               + " order by DanhBo");
        }

        public DataTable getDS_PhiMoNuoc()
        {
            return LINQToDataTable(_db.TT_TienDus.Where(item => item.Phi > 0).ToList());
        }

        public DataTable getDSTienDu(DateTime NgayGiaiTrach)
        {
            return ExecuteQuery_DataTable("declare @NgayGiaiTrach date;"
                    + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "'"
                    + " select a.DanhBo,CASE WHEN b.SoTien is null THEN a.SoTien ELSE a.SoTien-b.SoTien END as SoTien,DienThoai=(select top 1 DienThoai from CAPNUOCTANHOA.dbo.SDT_DHN where DanhBo=a.DanhBo) from"
                    + " (select DanhBo,SoTien from TT_TienDu) a"
                    + " left join"
                    + " (select DanhBo,SUM(CAST(SoTien AS bigint)) as SoTien from TT_TienDuLichSu where CAST(CreateDate as date)>@NgayGiaiTrach group by DanhBo) b on a.DanhBo=b.DanhBo"
                    + " left join"
                    + " (select DanhBo,DienThoai from TT_ThongTinKhachHang) c on a.DanhBo=c.DanhBo"
                    + " where case when b.SoTien is null then a.SoTien else a.SoTien-b.SoTien end >0"
                    + " order by DanhBo");
        }

        public DataTable getDSTienDu(DateTime NgayGiaiTrach, int FromDot, int ToDot)
        {
            //string sql = "declare @NgayGiaiTrach date;"
            //        + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "'"
            //        + " select a.DanhBo,CASE WHEN b.SoTien is null THEN a.SoTien ELSE a.SoTien-b.SoTien END as SoTien,DienThoai from"
            //        + " (select DanhBo,SoTien from TT_TienDu) a"
            //        + " left join"
            //        + " (select DanhBo,SUM(CAST(SoTien AS bigint)) as SoTien from TT_TienDuLichSu where CAST(CreateDate as date)>@NgayGiaiTrach group by DanhBo) b on a.DanhBo=b.DanhBo"
            //        + " left join"
            //        + " (select DanhBo,DienThoai from TT_ThongTinKhachHang) c on a.DanhBo=c.DanhBo"
            //        + " where case when b.SoTien is null then a.SoTien else a.SoTien-b.SoTien end >0"
            //        + " order by DanhBo";
            return ExecuteQuery_DataTable(" declare @NgayGiaiTrach date;"
                    + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "';"
                    + " with temp as"
                    + " ("
                    + " select a.Dot,a.DanhBo,CASE WHEN b.SoTien is null THEN a.SoTien ELSE a.SoTien-b.SoTien END as SoTien,DienThoai=(select top 1 DienThoai from CAPNUOCTANHOA.dbo.SDT_DHN where DanhBo=a.DanhBo) from"
                    + " (select Dot=SUBSTRING(ttkh.LOTRINH,1,2),td.DanhBo,SoTien from TT_TienDu td left join CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh on td.DanhBo=ttkh.DANHBO) a"
                    + " left join"
                    + " (select DanhBo,SUM(CAST(SoTien AS bigint)) as SoTien from TT_TienDuLichSu where CAST(CreateDate as date)>@NgayGiaiTrach group by DanhBo) b on a.DanhBo=b.DanhBo"
                    + " where case when b.SoTien is null then a.SoTien else a.SoTien-b.SoTien end >0"
                    + " )"
                    + " select * from temp where Dot>=" + FromDot + " and Dot<=" + ToDot
                    + " union all"
                    + " select * from temp where Dot is null"
                    + " order by DanhBo");
        }

        public DataTable getDSTienDu_ChuyenNhanTien(DateTime NgayGiaiTrach, int FromDot, int ToDot)
        {
            return ExecuteQuery_DataTable("select tdls.* from TT_TienDuLichSu tdls,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG ttkh"
                + " where CAST(tdls.CreateDate as date)='" + NgayGiaiTrach.ToString("yyyyMMdd") + "' and (tdls.Loai like N'%chuyển tiền%' or tdls.Loai like N'%nhận tiền%')"
                + " and tdls.DanhBoChuyenNhan!='12000000000' and tdls.DanhBo=ttkh.DANHBO and " + FromDot + "<=SUBSTRING(ttkh.LOTRINH,1,2) and SUBSTRING(ttkh.LOTRINH,1,2)<=" + ToDot);
        }

        public DataTable GetDSTienBienDong()
        {
            return LINQToDataTable(_db.TT_TienDus.Where(item => item.SoTien != 0).ToList());
        }

        public TT_TienDu Get(string DanhBo)
        {
            return _db.TT_TienDus.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public bool checkExist(string DanhBo)
        {
            return _db.TT_TienDus.Any(item => item.DanhBo == DanhBo);
        }

        public bool checkExist_ChoXuLy(string DanhBo)
        {
            return _db.TT_TienDus.Any(item => item.DanhBo == DanhBo && item.ChoXuLy == true);
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

        public bool Update(string DanhBo, int SoTien, string Loai, string GhiChu, int MaNH, int MaBK)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien+" + SoTien + ",MaNH=" + MaNH + ",ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo='" + DanhBo + "'"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaBK,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "'," + MaBK + "," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,MaNH,CreateBy,CreateDate,ModifyBy,ModifyDate) values('" + DanhBo + "'," + SoTien + "," + MaNH + "," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaBK,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "'," + MaBK + "," + CNguoiDung.MaND + ",GETDATE())");
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

        public bool Update(string DanhBo, int SoTien, string Loai, string GhiChu, int MaNH, int MaBK, DateTime CreateDate)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDu set SoTien=SoTien+" + SoTien + ",MaNH=" + MaNH + ",ModifyBy=" + CNguoiDung.MaND + ",ModifyDate='" + CreateDate.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "' where DanhBo='" + DanhBo + "'"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaBK,CreateBy,CreateDate,CreateDate2) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "'," + MaBK + "," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "',GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDu(DanhBo,SoTien,MaNH,CreateBy,CreateDate,ModifyBy,ModifyDate) values('" + DanhBo + "'," + SoTien + "," + MaNH + "," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "'," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "')"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSu(ID,DanhBo,SoTien,Loai,GhiChu,MaBK,CreateBy,CreateDate,CreateDate2) values((select MAX(ID)+1 from TT_TienDuLichSu),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "'," + MaBK + "," + CNguoiDung.MaND + ",'" + CreateDate.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "',GETDATE())");
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

        public long GetTongTienTonDenNgay(DateTime CreateDate, int IDPhong)
        {
            if (_db.TT_TienDuLichSus.Any(item => item.CreateDate.Value.Date > CreateDate.Date && _db.TT_NguoiDungs.SingleOrDefault(o => o.MaND == item.CreateBy).TT_To.IDPhong == IDPhong))
                return (long)(_db.TT_TienDus.Sum(item => (long)item.SoTien) - _db.TT_TienDuLichSus.Where(item => item.CreateDate.Value.Date > CreateDate.Date && _db.TT_NguoiDungs.SingleOrDefault(o => o.MaND == item.CreateBy).TT_To.IDPhong == IDPhong).Sum(item => (long)item.SoTien));
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

        public bool xoa_LichSu(TT_TienDuLichSu en)
        {
            try
            {
                _db.TT_TienDuLichSus.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public TT_TienDuLichSu get_LichSu(int ID)
        {
            return _db.TT_TienDuLichSus.SingleOrDefault(item => item.ID == ID);
        }

        public TT_TienDuLichSu get_LichSu(string DanhBo, int SoTien, DateTime CreateDate, int MaBK)
        {
            return _db.TT_TienDuLichSus.Where(item => item.DanhBo == DanhBo && item.SoTien == SoTien && item.CreateDate.Value.Date == CreateDate.Date && item.MaBK == MaBK).OrderByDescending(item => item.CreateDate).FirstOrDefault();
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
            string sql = "declare @Ngay date"
                    + " set @Ngay='" + NgayGiaiTrach.ToString("yyyyMMdd") + "'"
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

        public DataTable getThongKe(DateTime NgayGiaiTrach, int FromDot, int ToDot)
        {
            string sql = "declare @Ngay date"
                    + " set @Ngay='" + NgayGiaiTrach.ToString("yyyyMMdd") + "'"
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

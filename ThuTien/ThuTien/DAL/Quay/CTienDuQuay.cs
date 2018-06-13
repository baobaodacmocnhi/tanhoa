using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ThuTien.DAL.QuanTri;
using System.Windows.Forms;
using ThuTien.LinQ;

namespace ThuTien.DAL.Quay
{
    class CTienDuQuay : CDAL
    {
        public bool Sua(TT_TienDuQuay tiendu)
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
            return LINQToDataTable(_db.TT_TienDuQuays.Where(item => item.SoTien < 0).ToList());
        }

        public DataTable GetDSTienDu()
        {
            return LINQToDataTable(_db.TT_TienDuQuays.Where(item => item.SoTien > 0).ToList());
        }

        public DataTable GetDSTienDu(DateTime NgayGiaiTrach)
        {
            string sql = "declare @NgayGiaiTrach date;"
                    + " set @NgayGiaiTrach='" + NgayGiaiTrach.ToString("yyyyMMdd") + "'"
                    + " select a.DanhBo,CASE WHEN b.SoTien is null THEN a.SoTien ELSE a.SoTien-b.SoTien END as SoTien,DienThoai from"
                    + " (select DanhBo,SoTien from TT_TienDuQuay) a"
                    + " left join"
                    + " (select DanhBo,SUM(SoTien) as SoTien from TT_TienDuLichSuQuay where CAST(CreateDate as date)>@NgayGiaiTrach group by DanhBo) b on a.DanhBo=b.DanhBo"
                    + " left join"
                    + " (select DanhBo,DienThoai from TT_ThongTinKhachHang) c on a.DanhBo=c.DanhBo"
                    + " where case when b.SoTien is null then a.SoTien else a.SoTien-b.SoTien end>0";
            return ExecuteQuery_SqlDataReader_DataTable(sql);
        }

        public bool Update(string DanhBo, int SoTien, string Loai, string GhiChu)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDuQuay set SoTien=SoTien+" + SoTien + ",ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo='" + DanhBo + "'"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSuQuay(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSuQuay),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "'," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDuQuay(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values('" + DanhBo + "'," + SoTien + "," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSuQuay(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSuQuay),'" + DanhBo + "'," + SoTien + ",N'" + Loai + "',N'" + GhiChu + "'," + CNguoiDung.MaND + ",GETDATE())");
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

        public TT_TienDuQuay Get(string DanhBo)
        {
            return _db.TT_TienDuQuays.SingleOrDefault(item => item.DanhBo == DanhBo);
        }

        public bool UpdateThem(string SoHoaDon, string Loai, string GhiChu)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDuQuay set SoTien=SoTien-(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo=(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "')"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSuQuay(ID,DanhBo,SoTien,Loai,GhiChu,SoHoaDon,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSuQuay),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'" + Loai + "',N'" + GhiChu + " '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDuQuay(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values((select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSuQuay(ID,DanhBo,SoTien,Loai,GhiChu,SoHoaDon,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSuQuay),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'" + Loai + "',N'" + GhiChu + " '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",GETDATE())");
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

        public bool UpdateXoa(string SoHoaDon, string Loai, string GhiChu)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDuQuay set SoTien=SoTien+(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo=(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "')"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSuQuay(ID,DanhBo,SoTien,Loai,GhiChu,SoHoaDon,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSuQuay),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'" + Loai + "',N'" + GhiChu + " '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDuQuay(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values((select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSuQuay(ID,DanhBo,SoTien,Loai,GhiChu,SoHoaDon,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSuQuay),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'" + Loai + "',N'" + GhiChu + " '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "'),'" + SoHoaDon + "'," + CNguoiDung.MaND + ",GETDATE())");
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

        public int GetTienDu(string DanhBo)
        {
            if (_db.TT_TienDuLichSuQuays.Any(item => item.DanhBo == DanhBo))
                return _db.TT_TienDuLichSuQuays.SingleOrDefault(item => item.DanhBo == DanhBo).SoTien.Value;
            else
                return 0;
        }

        public DataTable GetDSLichSu(string DanhBo)
        {
            return LINQToDataTable(_db.TT_TienDuLichSuQuays.Where(item => item.DanhBo == DanhBo).OrderByDescending(item => item.CreateDate).ToList());
        }

        public DataTable GetDSLichSu(string Loai, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            return LINQToDataTable(_db.TT_TienDuLichSuQuays.Where(item => item.CreateDate.Value.Date >= FromCreateDate.Date && item.CreateDate.Value.Date <= ToCreateDate.Date && item.Loai.Contains(Loai)));
        }
    }
}

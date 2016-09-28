using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ThuTien.DAL.QuanTri;
using System.Windows.Forms;

namespace ThuTien.DAL.Quay
{
    class CTienDuQuay : CDAL
    {
        public DataTable GetDSTienAm()
        {
            return LINQToDataTable(_db.TT_TienDuQuays.Where(item => item.SoTien < 0).ToList());
        }

        public DataTable GetDSTienDu()
        {
            return LINQToDataTable(_db.TT_TienDuQuays.Where(item => item.SoTien > 0).ToList());
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

        public bool UpdateThem(string SoHoaDon, string Loai, string GhiChu)
        {
            try
            {
                if (LinQ_ExecuteNonQuery("update TT_TienDuQuay set SoTien=SoTien-(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=GETDATE() where DanhBo=(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "')"))
                {
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSuQuay(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSuQuay),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'" + Loai + "',N'" + GhiChu + " '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDuQuay(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values((select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSuQuay(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSuQuay),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG=-TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'" + Loai + "',N'" + GhiChu + " '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE())");
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
                    return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSuQuay(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSuQuay),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'" + Loai + "',N'" + GhiChu + " '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE())");
                }
                else
                    if (LinQ_ExecuteNonQuery("insert into TT_TienDuQuay(DanhBo,SoTien,CreateBy,CreateDate,ModifyBy,ModifyDate) values((select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE()," + CNguoiDung.MaND + ",GETDATE())"))
                    {
                        return LinQ_ExecuteNonQuery("insert into TT_TienDuLichSuQuay(ID,DanhBo,SoTien,Loai,GhiChu,CreateBy,CreateDate) values((select MAX(ID)+1 from TT_TienDuLichSuQuay),(select DANHBA from HOADON where SOHOADON='" + SoHoaDon + "'),(select TONGCONG from HOADON where SOHOADON='" + SoHoaDon + "'),N'" + Loai + "',N'" + GhiChu + " '+(select CONVERT(varchar(2),ky)+'/'+CONVERT(varchar(4),NAM) from HOADON where SOHOADON='" + SoHoaDon + "')," + CNguoiDung.MaND + ",GETDATE())");
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

    }
}

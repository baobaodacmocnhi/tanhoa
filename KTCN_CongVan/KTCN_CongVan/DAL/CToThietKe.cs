using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace KTCN_CongVan.DAL
{
    class CToThietKe
    {
        CConnection _cDAL = new CConnection("Data Source=hp_g7\\kd;Initial Catalog=TANHOA_WATER;Persist Security Info=True;User ID=sa;Password=db8@tanhoa");

        public DateTime GetToDate(DateTime FromDate, int SoNgayCongThem)
        {
            while (SoNgayCongThem > 0)
            {
                if (FromDate.DayOfWeek == DayOfWeek.Friday)
                    FromDate = FromDate.AddDays(3);
                else
                    if (FromDate.DayOfWeek == DayOfWeek.Saturday)
                        FromDate = FromDate.AddDays(2);
                    else
                        FromDate = FromDate.AddDays(1);
                SoNgayCongThem--;
            }
            return FromDate;
        }

        public DataTable getDSDotThiCong()
        {
            string sql = "SELECT MADOT,TENLOAI,NgayLap=NGAYLAPDON,NGAYCHUYEN"
                    + " FROM DOT_NHAN_DON dot,LOAI_HOSO loai"
                    + " WHERE loai.MALOAI= ot.LOAIDON AND CHUYENDON='True' and BOPHANCHUYEN='TTK'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDSDotThiCong_NgayLap(string LoaiHoSo, DateTime FromNgayLap, DateTime ToNgayLap)
        {
            //DATEADD(DAY,5,ttk.NGAYGIAOSDV)<=GETDATE()
            string sql = "SELECT MADOT,MALOAI,TENLOAI,NgayLap=NGAYLAPDON,NGAYCHUYEN,NGAYGIAOSDV=(select top 1 ttk.NGAYGIAOSDV from TOTHIETKE ttk,DON_KHACHHANG don where dot.MADOT=ttk.MADOT and ttk.MADOT=dot.MADOT"
                    + " and don.HoSoCha is null and ttk.NGAYTKGD is null and ttk.NGAYHOANTATTK is null)"
                    + " FROM DOT_NHAN_DON dot,LOAI_HOSO loai"
                    + " WHERE loai.MALOAI=dot.LOAIDON AND CHUYENDON='True' and BOPHANCHUYEN='TTK'"
                    + " and cast(NGAYLAPDON as date)>='" + FromNgayLap.ToString("yyyyMMdd") + "' and cast(NGAYLAPDON as date)<='" + ToNgayLap.ToString("yyyyMMdd") + "'";
            switch (LoaiHoSo)
            {
                case "GanMoi":
                    sql += " and loai.MALOAI='GM'";
                    break;
                case "CatHuy":
                    sql += " and loai.MALOAI='HD'";
                    break;
                case "DichVu":
                    sql += " and loai.MALOAI!='GM' and loai.MALOAI!='HD'";
                    break;
                default:
                    break;
            }
            sql += " order by NGAYCHUYEN";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDSDotThiCong_NgayChuyen(string LoaiHoSo, DateTime FromNgayChuyen, DateTime ToNgayChuyen)
        {
            string sql = "SELECT MADOT,MALOAI,TENLOAI,NgayLap=NGAYLAPDON,NGAYCHUYEN,NGAYGIAOSDV=(select top 1 ttk.NGAYGIAOSDV from TOTHIETKE ttk,DON_KHACHHANG don where dot.MADOT=ttk.MADOT and ttk.MADOT=dot.MADOT"
                    + " and don.HoSoCha is null and ttk.NGAYTKGD is null and ttk.NGAYHOANTATTK is null)"
                    + " FROM DOT_NHAN_DON dot,LOAI_HOSO loai"
                    + " WHERE loai.MALOAI=dot.LOAIDON AND CHUYENDON='True' and BOPHANCHUYEN='TTK'"
                    + " and cast(NGAYCHUYEN as date)>='" + FromNgayChuyen.ToString("yyyyMMdd") + "' and cast(NGAYCHUYEN as date)<='" + ToNgayChuyen.ToString("yyyyMMdd") + "'";
            switch (LoaiHoSo)
            {
                case "GanMoi":
                    sql += " and loai.MALOAI='GM'";
                    break;
                case "CatHuy":
                    sql += " and loai.MALOAI='HD'";
                    break;
                case "DichVu":
                    sql += " and loai.MALOAI!='GM' and loai.MALOAI!='HD'";
                    break;
                default:
                    break;
            }
            sql += " order by NGAYCHUYEN";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDSDotThiCong_Ton(string LoaiHoSo)
        {
            string sql = "SELECT distinct dot.MADOT,TENLOAI,NgayLap=NGAYLAPDON,NGAYCHUYEN"
                    + " FROM DOT_NHAN_DON dot,LOAI_HOSO loai,TOTHIETKE ttk,DON_KHACHHANG don"
                    + " WHERE loai.MALOAI=dot.LOAIDON and dot.MADOT=ttk.MADOT and dot.MADOT=don.MADOT AND CHUYENDON='True' and dot.BOPHANCHUYEN='TTK'"
                    + " and don.HoSoCha is null and NGAYGIAOSDV is null and NGAYTKGD is null and NGAYHOANTATTK is null";
            switch (LoaiHoSo)
            {
                case "GanMoi":
                    sql += " and loai.MALOAI='GM'";
                    break;
                case "CatHuy":
                    sql += " and loai.MALOAI='HD'";
                    break;
                case "DichVu":
                    sql += " and loai.MALOAI!='GM' and loai.MALOAI!='HD'";
                    break;
                default:
                    break;
            }
            sql += " order by NGAYCHUYEN";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDSDotThiCong(string MaDot)
        {
            string sql = "SELECT MADOT,MALOAI,TENLOAI,NgayLap=NGAYLAPDON,NGAYCHUYEN,NGAYGIAOSDV=(select top 1 ttk.NGAYGIAOSDV from TOTHIETKE ttk,DON_KHACHHANG don where dot.MADOT=ttk.MADOT and ttk.MADOT=dot.MADOT"
                    + " and don.HoSoCha is null and ttk.NGAYTKGD is null and ttk.NGAYHOANTATTK is null)"
                    + " FROM DOT_NHAN_DON dot,LOAI_HOSO loai"
                    + " WHERE loai.MALOAI=dot.LOAIDON AND CHUYENDON='True' and BOPHANCHUYEN='TTK'"
                    + " and MADOT like '%"+MaDot+"%'";
            sql += " order by NGAYCHUYEN";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDSHoSo(string MaDot)
        {
            string sql = "SELECT SOHOSO=kh.SHS,HoSoCha,HOTEN,(SONHA +' '+ DUONG +', P.'+p.TENPHUONG+', Q.'+ q.TENQUAN ) as 'DIACHI',NGAYNHAN=CONVERT(VARCHAR(10),kh.NGAYNHAN,103),lkh.TENLOAI as 'LOAI',"
                    + " NgayGiaoSDV,SoDoVien=(select fullname from Users where username=SoDoVien),NgayLapBG=NGAYTKGD,NgayTraHS=NGAYHOANTATTK,MaLoaiHoSo=kh.loaihoso"
                    + " FROM DON_KHACHHANG kh,QUAN q,PHUONG p,LOAI_KHACHHANG lkh,TOTHIETKE ttk"
                    + " WHERE kh.QUAN=q.MAQUAN AND q.MAQUAN=p.MAQUAN AND kh.PHUONG=p.MAPHUONG AND lkh.MALOAI=kh.LOAIKH and ttk.SOHOSO=kh.SOHOSO"
                    + " AND kh.MADOT='" + MaDot + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

    }
}

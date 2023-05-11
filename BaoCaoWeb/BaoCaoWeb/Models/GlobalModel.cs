using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaoCaoWeb.Models
{
    public class ThongTin
    {
        public decimal KhachHang { get; set; }
        public decimal SanLuong { get; set; }
        public decimal SanLuongKH { get; set; }
        public double SanLuongDat { get; set; }
        public decimal DoanhThu { get; set; }
        public decimal DoanhThuKH { get; set; }
        public double DoanhThuDat { get; set; }
        public double ThatThoatNuoc { get; set; }
        public double ThatThoatNuocKH { get; set; }
        public double ThatThoatNuocDat { get; set; }
        public decimal GanMoi { get; set; }
        public decimal GanMoiKH { get; set; }
        public double GanMoiDat { get; set; }
        public decimal ThayDHNNho { get; set; }
        public decimal ThayDHNNhoKH { get; set; }
        public double ThayDHNNhoDat { get; set; }
        public decimal ThayDHNLon { get; set; }
        public decimal ThayDHNLonKH { get; set; }
        public double ThayDHNLonDat { get; set; }
        public int NamPresent { get; set; }
        public int NamPrevious { get; set; }
        public List<Chart> lstSanLuong { get; set; }
        public List<Chart> lstDoanhThu { get; set; }
        public List<Chart> lstGiaBanBinhQuan { get; set; }
        public List<Chart> lstThuHo { get; set; }
        public Array jsonSanLuong { get; set; }
        public ThongTin()
        {
            KhachHang = SanLuong = DoanhThu = SanLuongKH = DoanhThuKH = NamPresent = NamPrevious = 0;
            ThatThoatNuoc = ThatThoatNuocKH = ThatThoatNuocDat = SanLuongDat = DoanhThuDat = 0.0;
            lstSanLuong = lstDoanhThu = lstGiaBanBinhQuan = lstThuHo = new List<Chart>();
            jsonSanLuong = null;
        }
    }

    public class Chart
    {
        public int Ky { get; set; }
        public decimal NamPresent { get; set; }
        public decimal NamPrevious { get; set; }
        public decimal ChenhLech { get; set; }
        public string NoiDung { get; set; }
        public string NoiDung2 { get; set; }
        public double KeHoach { get; set; }
        public double ThucHien { get; set; }
        public double TyLe { get; set; }
        public Chart()
        {
            Ky = 0;
            NamPresent = NamPrevious = ChenhLech = 0;
            NoiDung = NoiDung2 = "";
            KeHoach = ThucHien = TyLe = 0.0f;
        }
    }

    public class NoiDung
    {
        public string NoiDung1 { get; set; }
        public string NoiDung2 { get; set; }
        public string NoiDung3 { get; set; }
        public string NoiDung4 { get; set; }
        public string NoiDung5 { get; set; }
        public string NoiDung6 { get; set; }
        public NoiDung()
        {
            NoiDung1 = NoiDung2 = NoiDung3 = NoiDung4 = NoiDung5 = NoiDung6 = "";
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaoCaoWeb.Models
{
    public class ThongTin
    {
        public decimal TongKhachHang { get; set; }
        public decimal TongSanLuong { get; set; }
        public decimal TongDoanhThu { get; set; }
        public decimal TongThatThoatNuoc { get; set; }
        public int NamPresent { get; set; }
        public int NamPrevious { get; set; }
        public List<Chart> lstSanLuong { get; set; }
        public List<Chart> lstDoanhThu { get; set; }
        public List<Chart> lstGiaBanBinhQuan { get; set; }
        public List<Chart> lstThuHo { get; set; }
        public Array jsonSanLuong { get; set; }
        public ThongTin()
        {
            TongKhachHang = TongSanLuong = TongDoanhThu = TongThatThoatNuoc = NamPresent = NamPrevious = 0;
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
        public Chart()
        {
            Ky = 0;
            NamPresent = NamPrevious = ChenhLech = 0;
        }
    }



}
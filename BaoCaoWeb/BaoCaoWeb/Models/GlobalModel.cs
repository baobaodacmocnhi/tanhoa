using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaoCaoWeb.Models
{
    public class ThongTin
    {
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal TongKhachHang { get; set; }
        public decimal TongSanLuong { get; set; }
        public decimal TongDoanhThu { get; set; }
        public decimal TongThatThoatNuoc { get; set; }

        public ThongTin()
        {
            TongKhachHang = 0;
            TongSanLuong = TongDoanhThu = TongThatThoatNuoc = 0;
        }
    }
}
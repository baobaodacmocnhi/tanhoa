using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VanBanKhachHangWeb.Models
{
    public class VanBanKhachHangModel
    {
        public List<VanBan> lstVanBan { get; set; }
        public VanBan ttkh { get; set; }

        public VanBanKhachHangModel()
        {
            ttkh = new VanBan();
            lstVanBan = new List<VanBan>();
        }

        public class VanBan
        {
            [StringLength(13, MinimumLength = 11, ErrorMessage = "Danh bộ gồm 11 ký tự")]
            [Required(ErrorMessage = "Vui lòng nhập danh bộ")]
            [Display(Name = "Danh Bộ")]
            public string DanhBo { get; set; }

            [Display(Name = "Khách Hàng")]
            public string HoTen { get; set; }

            [Display(Name = "Địa Chỉ")]
            public string DiaChi { get; set; }

            [Display(Name = "Loại Văn Bản")]
            public string LoaiVanBan { get; set; }

            [Display(Name = "Ngày Lập")]
            public DateTime CreateDate { get; set; }

            [Display(Name = "File")]
            public string FileContent { get; set; }

            public string TableName { get; set; }

            public string IDFileContent { get; set; }

            public VanBan()
            {
                DanhBo = "";
                HoTen = "";
                DiaChi = "";
                LoaiVanBan = "";
                CreateDate = DateTime.Now;
                FileContent = "";
                TableName = "";
                IDFileContent = "";
            }
        }

    }
}
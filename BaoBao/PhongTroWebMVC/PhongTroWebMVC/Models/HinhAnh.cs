namespace PhongTroWebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HinhAnh")]
    public partial class HinhAnh
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Display(Name = "Hình")]
        public byte[] Image { get; set; }

        [Display(Name = "Hình")]
        public byte[] Image_Thumb { get; set; }

        [Display(Name = "Khách hàng")]
        public int? ID_KhachHang { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreateDate { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}

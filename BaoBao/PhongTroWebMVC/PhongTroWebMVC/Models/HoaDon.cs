namespace PhongTroWebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Display(Name = "Phòng")]
        public int? IDPhong { get; set; }

        [Display(Name = "Chỉ số điện cũ")]
        public int? ChiSoDienOld { get; set; }

        [Display(Name = "Chỉ số điện mới")]
        public int? ChiSoDienNew { get; set; }

        [Display(Name = "Tiêu thụ điện")]
        public int? TieuThuDien { get; set; }

        [Display(Name = "Tiền điện")]
        public int? TienDien { get; set; }

        [Display(Name = "Chi tiết điện")]
        [DataType(DataType.MultilineText)]
        [StringLength(200)]
        public string ChiTietDien { get; set; }

        [Display(Name = "Chỉ số nước cũ")]
        public int? ChiSoNuocOld { get; set; }

        [Display(Name = "Chỉ số nước mới")]
        public int? ChiSoNuocNew { get; set; }

        [Display(Name = "Tiêu thụ nước")]
        public int? TieuThuNuoc { get; set; }

        [Display(Name = "Tiền nước")]
        public int? TienNuoc { get; set; }

        [Display(Name = "Chi tiết nước")]
        [DataType(DataType.MultilineText)]
        [StringLength(200)]
        public string ChiTietNuoc { get; set; }

        [Display(Name = "Chi phí khác")]
        [DataType(DataType.MultilineText)]
        [StringLength(200)]
        public string ChiPhiKhac { get; set; }

        [Display(Name = "Tổng tiền")]
        public int? TongTien { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? ModifyDate { get; set; }

        public virtual Phong Phong { get; set; }
    }
}

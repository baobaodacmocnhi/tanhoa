namespace PhongTroWebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class Phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phong()
        {
            ChiPhiPhongs = new HashSet<ChiPhiPhong>();
            HoaDons = new HashSet<HoaDon>();
            KhachHangs = new HashSet<KhachHang>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Display(Name = "Phòng")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Giá tiền")]
        public int? GiaTien { get; set; }

        [Display(Name = "Thuê")]
        public bool Thue { get; set; }

        [Display(Name = "Ngày thuê")]
        [Column(TypeName = "date")]
        public DateTime? NgayThue { get; set; }

        [Display(Name = "Chỉ số điện cũ")]
        public int? ChiSoDienOld { get; set; }

        [Display(Name = "Chỉ số điện mới")]
        public int? ChiSoDien { get; set; }

        [Display(Name = "Số NK nước")]
        public int? SoNKNuoc { get; set; }

        [Display(Name = "Chỉ số nước cũ")]
        public int? ChiSoNuocOld { get; set; }

        [Display(Name = "Chỉ số nước mới")]
        public int? ChiSoNuoc { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? ModifyDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiPhiPhong> ChiPhiPhongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}

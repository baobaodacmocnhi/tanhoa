namespace PhongTroWebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            HinhAnhs = new HashSet<HinhAnh>();
        }

        [Display(Name = "Khách hàng")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Display(Name = "Họ tên")]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Display(Name = "Tên")]
        [StringLength(10)]
        public string Ten { get; set; }

        [Display(Name = "Giới tính")]
        public bool GioiTinh { get; set; }

        [Display(Name = "Ngày sinh")]
        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [Display(Name = "Điện thoại")]
        [StringLength(50)]
        public string DienThoai { get; set; }

        [Display(Name = "Biển số xe")]
        [StringLength(50)]
        public string BienSoXe { get; set; }

        [Display(Name = "Phòng")]
        public int? IDPhong { get; set; }

        [Display(Name = "Thuê")]
        public bool Thue { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? ModifyDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HinhAnh> HinhAnhs { get; set; }

        public virtual Phong Phong { get; set; }
    }
}

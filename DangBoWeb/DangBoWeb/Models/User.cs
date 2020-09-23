namespace DangBoWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            PhanQuyenNguoiDungs = new HashSet<PhanQuyenNguoiDung>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaU { get; set; }

        public int? STT { get; set; }

        [Display(Name = "Họ Tên")]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Display(Name = "Tài Khoản")]
        [StringLength(50)]
        public string TaiKhoan { get; set; }

        [Display(Name = "Mật Khẩu")]
        [StringLength(50)]
        public string MatKhau { get; set; }

        public bool Admin { get; set; }

        [Display(Name = "Nhóm")]
        public int? MaNhom { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? ModifyBy { get; set; }

        public virtual Nhom Nhom { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanQuyenNguoiDung> PhanQuyenNguoiDungs { get; set; }
    }


}

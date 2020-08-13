namespace DangBoWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu()
        {
            PhanQuyenNguoiDungs = new HashSet<PhanQuyenNguoiDung>();
            PhanQuyenNhoms = new HashSet<PhanQuyenNhom>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaMenu { get; set; }

        public int? STT { get; set; }

        [StringLength(50)]
        public string TenMenu { get; set; }

        [StringLength(50)]
        public string TextMenu { get; set; }

        [StringLength(50)]
        public string TenMenuCha { get; set; }

        [StringLength(50)]
        public string TextMenuCha { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? ModifyBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanQuyenNguoiDung> PhanQuyenNguoiDungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanQuyenNhom> PhanQuyenNhoms { get; set; }
    }
}

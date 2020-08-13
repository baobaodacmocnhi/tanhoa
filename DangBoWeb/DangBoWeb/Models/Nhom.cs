namespace DangBoWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nhom")]
    public partial class Nhom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nhom()
        {
            PhanQuyenNhoms = new HashSet<PhanQuyenNhom>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNhom { get; set; }

        [StringLength(50)]
        public string TenNhom { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? ModifyBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanQuyenNhom> PhanQuyenNhoms { get; set; }
    }
}

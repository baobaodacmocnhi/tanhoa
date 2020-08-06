namespace DangBoWeb.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongVanDi")]
    public partial class CongVanDi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CongVanDi()
        {
            CongVanDi_Hinh = new HashSet<CongVanDi_Hinh>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? IDDonVi { get; set; }

        public int? IDLoaiCV { get; set; }

        [StringLength(50)]
        public string SoCV { get; set; }

        [StringLength(50)]
        public string TieuDe { get; set; }

        [StringLength(50)]
        public string NoiDung { get; set; }

        public bool Mat { get; set; }

        public bool Khan { get; set; }

        public bool HetHan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHetHan { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public virtual DonVi DonVi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongVanDi_Hinh> CongVanDi_Hinh { get; set; }

        public virtual LoaiCongVan LoaiCongVan { get; set; }
    }
}

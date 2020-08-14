namespace DangBoWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongVanDen")]
    public partial class CongVanDen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CongVanDen()
        {
            CongVanDen_Hinh = new HashSet<CongVanDen_Hinh>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? IDDonVi { get; set; }

        public int? IDLoaiCV { get; set; }

        [Display(Name = "Số CV")]
        [StringLength(50)]
        public string SoCV { get; set; }

        [Display(Name = "Tiêu Đề")]
        [StringLength(50)]
        public string TieuDe { get; set; }

        [Display(Name = "Nội Dung")]
        [StringLength(50)]
        public string NoiDung { get; set; }

        public bool Mat { get; set; }

        public bool Khan { get; set; }

        public bool HetHan { get; set; }

        [Display(Name = "Ngày Hết Hạn")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? NgayHetHan { get; set; }

        public int? CreateBy { get; set; }

        [Display(Name = "Ngày Lập")]
        public DateTime? CreateDate { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public virtual DonVi DonVi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongVanDen_Hinh> CongVanDen_Hinh { get; set; }

        public virtual LoaiCongVan LoaiCongVan { get; set; }
    }
}

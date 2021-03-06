﻿namespace DangBoWeb.Models
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

        public int? SoCV1 { get; set; }

        [Display(Name = "Số CV")]
        [StringLength(50)]
        public string SoCV { get; set; }

        [Display(Name = "Trích Yếu Nội Dung")]
        [StringLength(500)]
        public string TrichYeuNoiDung { get; set; }

        [Display(Name = "Bút Phê")]
        [StringLength(500)]
        public string ButPhe { get; set; }

        [Display(Name = "Ghi Chú")]
        [StringLength(200)]
        public string GhiChu { get; set; }

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
        public virtual ICollection<CongVanDi_Hinh> CongVanDi_Hinh { get; set; }

        public virtual LoaiCongVan LoaiCongVan { get; set; }
    }
}

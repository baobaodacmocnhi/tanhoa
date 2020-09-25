namespace DangBoWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhiemKy")]
    public partial class NhiemKy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nhiệm Kỳ")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Từ Ngày")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? TuNgay { get; set; }

        [Display(Name = "Đến Ngày")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? DenNgay { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? ModifyBy { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}

namespace PhongTroWebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaNuoc")]
    public partial class GiaNuoc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Display(Name = "Giá nước")]
        [StringLength(200)]
        public string Name { get; set; }

        [Display(Name = "Giá tiền")]
        [DisplayFormat(DataFormatString = "{0:#,##}", ApplyFormatInEditMode = true)]
        public int? GiaTien { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Ngày cập nhật")]
        public DateTime? ModifyDate { get; set; }
    }
}

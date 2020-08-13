namespace DangBoWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CongVanDi_Hinh
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? IDCongVanDi { get; set; }

        [StringLength(100)]
        public string FileName { get; set; }

        public int? FileSize { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }

        [StringLength(10)]
        public string FileExtention { get; set; }

        public byte[] FileContent { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public virtual CongVanDi CongVanDi { get; set; }
    }
}

namespace DangBoWeb.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CongVanDen_Hinh
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? IDCongVanDen { get; set; }

        [StringLength(10)]
        public string LoaiFile { get; set; }

        [StringLength(50)]
        public string TenFile { get; set; }

        public byte[] File { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public virtual CongVanDen CongVanDen { get; set; }
    }
}

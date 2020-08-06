namespace DangBoWeb.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanQuyenNguoiDung")]
    public partial class PhanQuyenNguoiDung
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaMenu { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaND { get; set; }

        public bool ToanQuyen { get; set; }

        public bool Xem { get; set; }

        public bool Them { get; set; }

        public bool Xoa { get; set; }

        public bool Sua { get; set; }

        public bool QuanLy { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? ModifyBy { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual User User { get; set; }
    }
}

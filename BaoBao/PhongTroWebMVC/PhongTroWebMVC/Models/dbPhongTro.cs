namespace PhongTroWebMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbPhongTro : DbContext
    {
        public dbPhongTro()
            : base("name=dbPhongTro")
        {
        }

        public virtual DbSet<ChiPhiKhac> ChiPhiKhacs { get; set; }
        public virtual DbSet<ChiPhiPhong> ChiPhiPhongs { get; set; }
        public virtual DbSet<GiaDien> GiaDiens { get; set; }
        public virtual DbSet<GiaNuoc> GiaNuocs { get; set; }
        public virtual DbSet<HinhAnh> HinhAnhs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiPhiKhac>()
                .HasMany(e => e.ChiPhiPhongs)
                .WithRequired(e => e.ChiPhiKhac)
                .HasForeignKey(e => e.IDChiPhiKhac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.BienSoXe)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HinhAnhs)
                .WithOptional(e => e.KhachHang)
                .HasForeignKey(e => e.ID_KhachHang);

            modelBuilder.Entity<Phong>()
                .HasMany(e => e.ChiPhiPhongs)
                .WithRequired(e => e.Phong)
                .HasForeignKey(e => e.IDPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phong>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.Phong)
                .HasForeignKey(e => e.IDPhong);

            modelBuilder.Entity<Phong>()
                .HasMany(e => e.KhachHangs)
                .WithOptional(e => e.Phong)
                .HasForeignKey(e => e.IDPhong);
        }
    }
}

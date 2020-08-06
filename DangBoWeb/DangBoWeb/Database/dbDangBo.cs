namespace DangBoWeb.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbDangBo : DbContext
    {
        public dbDangBo()
            : base("name=dbDangBo")
        {
        }

        public virtual DbSet<CongVanDen> CongVanDens { get; set; }
        public virtual DbSet<CongVanDen_Hinh> CongVanDen_Hinh { get; set; }
        public virtual DbSet<CongVanDi> CongVanDis { get; set; }
        public virtual DbSet<CongVanDi_Hinh> CongVanDi_Hinh { get; set; }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<LoaiCongVan> LoaiCongVans { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Nhom> Nhoms { get; set; }
        public virtual DbSet<PhanQuyenNguoiDung> PhanQuyenNguoiDungs { get; set; }
        public virtual DbSet<PhanQuyenNhom> PhanQuyenNhoms { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CongVanDen>()
                .Property(e => e.SoCV)
                .IsUnicode(false);

            modelBuilder.Entity<CongVanDen>()
                .Property(e => e.TieuDe)
                .IsUnicode(false);

            modelBuilder.Entity<CongVanDen>()
                .Property(e => e.NoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<CongVanDen>()
                .HasMany(e => e.CongVanDen_Hinh)
                .WithOptional(e => e.CongVanDen)
                .HasForeignKey(e => e.IDCongVanDen);

            modelBuilder.Entity<CongVanDen_Hinh>()
                .Property(e => e.LoaiFile)
                .IsUnicode(false);

            modelBuilder.Entity<CongVanDen_Hinh>()
                .Property(e => e.TenFile)
                .IsUnicode(false);

            modelBuilder.Entity<CongVanDi>()
                .Property(e => e.SoCV)
                .IsUnicode(false);

            modelBuilder.Entity<CongVanDi>()
                .Property(e => e.TieuDe)
                .IsUnicode(false);

            modelBuilder.Entity<CongVanDi>()
                .Property(e => e.NoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<CongVanDi>()
                .HasMany(e => e.CongVanDi_Hinh)
                .WithOptional(e => e.CongVanDi)
                .HasForeignKey(e => e.IDCongVanDi);

            modelBuilder.Entity<CongVanDi_Hinh>()
                .Property(e => e.LoaiFile)
                .IsUnicode(false);

            modelBuilder.Entity<CongVanDi_Hinh>()
                .Property(e => e.TenFile)
                .IsUnicode(false);

            modelBuilder.Entity<DonVi>()
                .HasMany(e => e.CongVanDens)
                .WithOptional(e => e.DonVi)
                .HasForeignKey(e => e.IDDonVi);

            modelBuilder.Entity<DonVi>()
                .HasMany(e => e.CongVanDis)
                .WithOptional(e => e.DonVi)
                .HasForeignKey(e => e.IDDonVi);

            modelBuilder.Entity<LoaiCongVan>()
                .HasMany(e => e.CongVanDens)
                .WithOptional(e => e.LoaiCongVan)
                .HasForeignKey(e => e.IDLoaiCV);

            modelBuilder.Entity<LoaiCongVan>()
                .HasMany(e => e.CongVanDis)
                .WithOptional(e => e.LoaiCongVan)
                .HasForeignKey(e => e.IDLoaiCV);

            modelBuilder.Entity<Menu>()
                .Property(e => e.TenMenu)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.TenMenuCha)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.PhanQuyenNguoiDungs)
                .WithRequired(e => e.Menu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.PhanQuyenNhoms)
                .WithRequired(e => e.Menu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nhom>()
                .HasMany(e => e.PhanQuyenNhoms)
                .WithRequired(e => e.Nhom)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PhanQuyenNguoiDungs)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.MaND)
                .WillCascadeOnDelete(false);
        }
    }
}

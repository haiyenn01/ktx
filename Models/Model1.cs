namespace PlurasightLogin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserAddress> AspNetUserAddresses { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Dien> Diens { get; set; }
        public virtual DbSet<GiatDo> GiatDoes { get; set; }
        public virtual DbSet<HDDienNuoc> HDDienNuocs { get; set; }
        public virtual DbSet<HDGiatDo> HDGiatDoes { get; set; }
        public virtual DbSet<HDSuaChua> HDSuaChuas { get; set; }
        public virtual DbSet<HDThuePhong> HDThuePhongs { get; set; }
        public virtual DbSet<KhuNha> KhuNhas { get; set; }
        public virtual DbSet<Nuoc> Nuocs { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<VatTu> VatTus { get; set; }

        public virtual DbSet<BaiViet> BaiViets { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserAddresses)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.CMND)
                .IsFixedLength();

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.SDT)
                .IsFixedLength();
        }
    }
}

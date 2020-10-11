using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AssetTracket_Data
{
    public partial class AssetsTrackerContext : DbContext
    {
        public AssetsTrackerContext()
        {
        }

        public AssetsTrackerContext(DbContextOptions<AssetsTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Asset> Asset { get; set; }
        public virtual DbSet<AssignAsset> AssignAsset { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AssetsTracker;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.Property(e => e.AdministratorId).HasColumnName("AdministratorID");

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.AssetName).HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Asset)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Asset__CategoryI__286302EC");
            });

            modelBuilder.Entity<AssignAsset>(entity =>
            {
                entity.Property(e => e.AdministratorId).HasColumnName("AdministratorID");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.DateTo).HasColumnType("datetime");

                entity.HasOne(d => d.Administrator)
                    .WithMany(p => p.AssignAsset)
                    .HasForeignKey(d => d.AdministratorId)
                    .HasConstraintName("FK__AssignAss__Admin__3B75D760");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssignAsset)
                    .HasForeignKey(d => d.AssetId)
                    .HasConstraintName("FK__AssignAss__Asset__2B3F6F97");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AssignAsset)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__AssignAss__Emplo__2C3393D0");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

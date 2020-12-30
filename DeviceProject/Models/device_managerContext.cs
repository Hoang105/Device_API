using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DeviceProject.Models
{
    public partial class device_managerContext : DbContext
    {
        public device_managerContext()
        {
        }

        public device_managerContext(DbContextOptions<device_managerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<device> devices { get; set; }
        public virtual DbSet<device_history> device_histories { get; set; }
        public virtual DbSet<device_status> device_statuses { get; set; }
        public virtual DbSet<project> projects { get; set; }
        public virtual DbSet<role_manager> role_managers { get; set; }
        public virtual DbSet<user_manager> user_managers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-6HPIEJD;Initial Catalog=device_manager;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<device>(entity =>
            {
                entity.HasKey(e => e.device_id);

                entity.ToTable("device");

                entity.Property(e => e.device_name).IsRequired();

                entity.Property(e => e.device_report).HasColumnType("date");

                entity.Property(e => e.device_warranty_period).HasColumnType("date");
            });

            modelBuilder.Entity<device_history>(entity =>
            {
                entity.HasKey(e => e.device_history_id)
                    .HasName("PK__device_h__C71719D34BF0F4D6");

                entity.ToTable("device_history");

                entity.Property(e => e.device_history_change).HasColumnType("date");
            });

            modelBuilder.Entity<device_status>(entity =>
            {
                entity.HasKey(e => e.status_id)
                    .HasName("PK__device_s__3683B531267D2B70");

                entity.ToTable("device_status");

                entity.Property(e => e.status_name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<project>(entity =>
            {
                entity.HasKey(e => e.project_id);

                entity.ToTable("project");

                entity.Property(e => e.project_name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<role_manager>(entity =>
            {
                entity.HasKey(e => e.role_manager_id);

                entity.ToTable("role_manager");

                entity.Property(e => e.role_manager_name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<user_manager>(entity =>
            {
                entity.HasKey(e => e.user_manager_id);

                entity.ToTable("user_manager");

                entity.Property(e => e.user_manager_birthday)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.user_manager_email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.user_manager_name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.user_manager_password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.user_manager_phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.user_manager_username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

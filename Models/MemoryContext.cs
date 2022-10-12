using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MemoryWebApi.Models
{
    public partial class MemoryContext : DbContext
    {
        public MemoryContext()
        {
        }

        public MemoryContext(DbContextOptions<MemoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LocalHost;Database=Memory;User Id=memorryapi;Password=password;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Image1).HasColumnName("Image");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .IsFixedLength();

                entity.Property(e => e.Theme)
                    .HasMaxLength(60)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(60);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

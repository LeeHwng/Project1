using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Qhluxury.Models;

namespace Qhluxury.Data;

public partial class QhluxuryContext : DbContext
{
    public QhluxuryContext()
    {
    }

    public QhluxuryContext(DbContextOptions<QhluxuryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hanghoa> Hanghoas { get; set; }

    public virtual DbSet<Loaihang> Loaihangs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
/*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.*/
        => optionsBuilder.UseSqlServer("Server=LAPTOP-SLC41VO7\\SQLEXPRESS;Database=Qhluxury;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hanghoa>(entity =>
        {
            entity.HasKey(e => e.Mahang);

            entity.ToTable("HANGHOA");

            entity.Property(e => e.Anh).HasMaxLength(50);
            entity.Property(e => e.Tenhang).HasMaxLength(50);
        });

        modelBuilder.Entity<Loaihang>(entity =>
        {
            entity.HasKey(e => e.Maloaihang);

            entity.ToTable("LOAIHANG");

            entity.Property(e => e.Tenloaihang).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

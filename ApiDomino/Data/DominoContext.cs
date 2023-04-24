using System;
using System.Collections.Generic;
using ApiDomino.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDomino.Data;

public partial class DominoContext : DbContext
{
    public DominoContext()
    {
    }

    public DominoContext(DbContextOptions<DominoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CadenaDomino> CadenaDominos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CadenaDomino>(entity =>
        {
            entity.HasKey(e => e.IdCadena).HasName("PK__CadenaDo__3A044C97E1F914E3");

            entity.ToTable("CadenaDomino");

            entity.Property(e => e.Cadena)
                .HasMaxLength(800)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

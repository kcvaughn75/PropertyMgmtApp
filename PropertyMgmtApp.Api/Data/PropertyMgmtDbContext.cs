using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PropertyMgmtApp.Api.Models;

namespace PropertyMgmtApp.Api.Data;

public partial class PropertyMgmtDbContext : DbContext
{
    public PropertyMgmtDbContext()
    {
    }

    public PropertyMgmtDbContext(DbContextOptions<PropertyMgmtDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lease> Leases { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=PropertyMgmtDb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lease>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Leases__3214EC07E70EE71A");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Leases).HasConstraintName("FK_Leases_Tenant");

            entity.HasOne(d => d.Unit).WithMany(p => p.Leases).HasConstraintName("FK_Leases_Unit");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Properti__3214EC076FAA1586");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tenants__3214EC07B5ED9EBD");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Units__3214EC07068EABC6");

            entity.HasOne(d => d.Property).WithMany(p => p.Units).HasConstraintName("FK_Units_Property");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

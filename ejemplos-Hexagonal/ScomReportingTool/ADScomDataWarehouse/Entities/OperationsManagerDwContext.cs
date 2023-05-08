using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ADScomDataWarehouse.Entities;

public partial class OperationsManagerDwContext : DbContext
{
    public OperationsManagerDwContext()
    {
    }

    public OperationsManagerDwContext(DbContextOptions<OperationsManagerDwContext> options)
        : base(options)
    {
    }

    public virtual DbSet<VManagedEntity> VManagedEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("data source=10.99.99.8;initial catalog=OperationsManagerDW;persist security info=True;user id=bitviewer;password=KjxtV(^3aW;MultipleActiveResultSets=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VManagedEntity>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vManagedEntity");

            entity.Property(e => e.DwcreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("DWCreatedDateTime");
            entity.Property(e => e.ManagedEntityRowId).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

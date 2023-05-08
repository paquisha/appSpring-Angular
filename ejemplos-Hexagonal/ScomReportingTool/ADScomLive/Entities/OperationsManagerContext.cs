using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ADScomLive.Entities;

public partial class OperationsManagerContext : DbContext
{
    public OperationsManagerContext()
    {
    }

    public OperationsManagerContext(DbContextOptions<OperationsManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alert> Alerts { get; set; }

    public virtual DbSet<AlertView> AlertViews { get; set; }

    public virtual DbSet<BaseManagedEntity> BaseManagedEntities { get; set; }

    public virtual DbSet<Connector> Connectors { get; set; }

    public virtual DbSet<LocalizedText> LocalizedTexts { get; set; }

    public virtual DbSet<MaintenanceMode> MaintenanceModes { get; set; }

    public virtual DbSet<MaintenanceMode1> MaintenanceModes1 { get; set; }

    public virtual DbSet<MaintenanceMode2> MaintenanceModes2 { get; set; }

    public virtual DbSet<MaintenanceMode3> MaintenanceModes3 { get; set; }

    public virtual DbSet<StateView> StateViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=10.99.99.6;Initial Catalog=OperationsManager;Persist Security Info=False;User ID=bitviewer-live;Password=FgF#aB!rut;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alert>(entity =>
        {
            entity.HasKey(e => e.AlertId).IsClustered(false);

            entity.ToTable("Alert");

            entity.HasIndex(e => new { e.BaseManagedEntityId, e.ProblemId }, "idx_Alert_BaseManagedEntityId_ProblemId").HasFillFactor(80);

            entity.HasIndex(e => e.LastModified, "idx_Alert_LastModified").HasFillFactor(80);

            entity.HasIndex(e => new { e.LastModifiedByNonConnector, e.ConnectorId }, "idx_Alert_LastModifiedByNonConnector_ConnectorId").HasFillFactor(80);

            entity.HasIndex(e => e.LastModifiedExceptRepeatCount, "idx_Alert_LastModifiedExceptRepeatCount").HasFillFactor(80);

            entity.HasIndex(e => e.ResolutionState, "idx_Alert_ResolutionState").HasFillFactor(80);

            entity.HasIndex(e => e.TimeResolutionStateLastModifiedInDb, "idx_Alert_TimeResolutionStateLastModifiedInDB").HasFillFactor(80);

            entity.HasIndex(e => new { e.TimeAdded, e.AlertId }, "idxc_Alert_TimeAdded_AlertId")
                .IsUnique()
                .IsClustered()
                .HasFillFactor(80);

            entity.Property(e => e.AlertId).ValueGeneratedNever();
            entity.Property(e => e.AlertDescription).HasMaxLength(2000);
            entity.Property(e => e.AlertName).HasMaxLength(255);
            entity.Property(e => e.Category).HasMaxLength(256);
            entity.Property(e => e.CustomField1).HasMaxLength(255);
            entity.Property(e => e.CustomField10).HasMaxLength(255);
            entity.Property(e => e.CustomField2).HasMaxLength(255);
            entity.Property(e => e.CustomField3).HasMaxLength(255);
            entity.Property(e => e.CustomField4).HasMaxLength(255);
            entity.Property(e => e.CustomField5).HasMaxLength(255);
            entity.Property(e => e.CustomField6).HasMaxLength(255);
            entity.Property(e => e.CustomField7).HasMaxLength(255);
            entity.Property(e => e.CustomField8).HasMaxLength(255);
            entity.Property(e => e.CustomField9).HasMaxLength(255);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.LastModifiedByNonConnector).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedExceptRepeatCount).HasColumnType("datetime");
            entity.Property(e => e.Owner).HasMaxLength(255);
            entity.Property(e => e.ResolvedBy).HasMaxLength(255);
            entity.Property(e => e.SiteName).HasMaxLength(255);
            entity.Property(e => e.TfsWorkItemId).HasMaxLength(150);
            entity.Property(e => e.TfsWorkItemOwner).HasMaxLength(255);
            entity.Property(e => e.TicketId).HasMaxLength(150);
            entity.Property(e => e.TimeAdded).HasColumnType("datetime");
            entity.Property(e => e.TimeRaised).HasColumnType("datetime");
            entity.Property(e => e.TimeResolutionStateLastModified).HasColumnType("datetime");
            entity.Property(e => e.TimeResolutionStateLastModifiedInDb)
                .HasColumnType("datetime")
                .HasColumnName("TimeResolutionStateLastModifiedInDB");
            entity.Property(e => e.TimeResolved).HasColumnType("datetime");

            entity.HasOne(d => d.BaseManagedEntity).WithMany(p => p.Alerts)
                .HasForeignKey(d => d.BaseManagedEntityId)
                .HasConstraintName("FK_Alert_BaseManagedEntity");

            entity.HasOne(d => d.Connector).WithMany(p => p.Alerts)
                .HasForeignKey(d => d.ConnectorId)
                .HasConstraintName("FK_Alert_ConnectorId");
        });

        modelBuilder.Entity<AlertView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AlertView");

            entity.Property(e => e.Category).HasMaxLength(256);
            entity.Property(e => e.CustomField1).HasMaxLength(255);
            entity.Property(e => e.CustomField10).HasMaxLength(255);
            entity.Property(e => e.CustomField2).HasMaxLength(255);
            entity.Property(e => e.CustomField3).HasMaxLength(255);
            entity.Property(e => e.CustomField4).HasMaxLength(255);
            entity.Property(e => e.CustomField5).HasMaxLength(255);
            entity.Property(e => e.CustomField6).HasMaxLength(255);
            entity.Property(e => e.CustomField7).HasMaxLength(255);
            entity.Property(e => e.CustomField8).HasMaxLength(255);
            entity.Property(e => e.CustomField9).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.LanguageCode).HasMaxLength(3);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
            entity.Property(e => e.LastModifiedByNonConnector).HasColumnType("datetime");
            entity.Property(e => e.MaintenanceModeLastModified).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Owner).HasMaxLength(255);
            entity.Property(e => e.ResolvedBy).HasMaxLength(255);
            entity.Property(e => e.SiteName).HasMaxLength(255);
            entity.Property(e => e.StateLastModified).HasColumnType("datetime");
            entity.Property(e => e.TfsWorkItemId).HasMaxLength(150);
            entity.Property(e => e.TfsWorkItemOwner).HasMaxLength(255);
            entity.Property(e => e.TicketId).HasMaxLength(150);
            entity.Property(e => e.TimeAdded).HasColumnType("datetime");
            entity.Property(e => e.TimeRaised).HasColumnType("datetime");
            entity.Property(e => e.TimeResolutionStateLastModified).HasColumnType("datetime");
            entity.Property(e => e.TimeResolved).HasColumnType("datetime");
        });

        modelBuilder.Entity<BaseManagedEntity>(entity =>
        {
            entity.ToTable("BaseManagedEntity", tb => tb.HasTrigger("triu_BaseManagedEntity"));

            entity.HasIndex(e => e.BaseManagedTypeId, "idx_BaseManagedEntity_BaseManagedTypeId").HasFillFactor(80);

            entity.HasIndex(e => e.LastModified, "idx_BaseManagedEntity_LastModified").HasFillFactor(80);

            entity.HasIndex(e => new { e.BaseManagedEntityId, e.TopLevelHostEntityId }, "idx_BaseManagedEntity_TopLevelHostEntityId").HasFillFactor(80);

            entity.Property(e => e.BaseManagedEntityId).ValueGeneratedNever();
            entity.Property(e => e.BaseManagedEntityInternalId).ValueGeneratedOnAdd();
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.OverrideTimestamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<Connector>(entity =>
        {
            entity.HasKey(e => e.ConnectorId).HasName("PK__Connecto__9B30413AC6D19216");

            entity.ToTable("Connector");

            entity.Property(e => e.ConnectorId).ValueGeneratedNever();
            entity.Property(e => e.CurrentBookmark).HasColumnType("datetime");
            entity.Property(e => e.LastModified).HasColumnType("datetime");

            entity.HasOne(d => d.BaseManagedEntity).WithMany(p => p.Connectors)
                .HasForeignKey(d => d.BaseManagedEntityId)
                .HasConstraintName("FK_Connector_BaseManagedEntity");
        });

        modelBuilder.Entity<LocalizedText>(entity =>
        {
            entity.HasKey(e => new { e.LtstringId, e.LtstringType, e.LanguageCode });

            entity.ToTable("LocalizedText");

            entity.HasIndex(e => e.MpelementId, "idx_LTMPElementId").HasFillFactor(80);

            entity.HasIndex(e => e.ManagementPackId, "idx_LTManagementPackId").HasFillFactor(80);

            entity.HasIndex(e => e.DisplayStringId, "idx_LT_DisplayStringId").HasFillFactor(80);

            entity.Property(e => e.LtstringId).HasColumnName("LTStringId");
            entity.Property(e => e.LtstringType).HasColumnName("LTStringType");
            entity.Property(e => e.LanguageCode).HasMaxLength(3);
            entity.Property(e => e.ElementName).HasMaxLength(256);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.Ltvalue).HasColumnName("LTValue");
            entity.Property(e => e.MpelementId).HasColumnName("MPElementId");
            entity.Property(e => e.SubElementName).HasMaxLength(256);
            entity.Property(e => e.TimeAdded).HasColumnType("datetime");
        });

        modelBuilder.Entity<MaintenanceMode>(entity =>
        {
            entity.HasKey(e => e.ManagedEntityRowId);

            entity.ToTable("MaintenanceMode", "CS");

            entity.HasIndex(e => e.ManagedEntityGuid, "IX_MaintenanceMode_ManagedEntityGuid").IsUnique();

            entity.Property(e => e.ManagedEntityRowId).ValueGeneratedNever();
            entity.Property(e => e.DblastModifiedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("DBLastModifiedDateTime");
        });

        modelBuilder.Entity<MaintenanceMode1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MaintenanceMode", "CSLog");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.DblastModifiedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("DBLastModifiedDateTime");
        });

        modelBuilder.Entity<MaintenanceMode2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MaintenanceMode", "CSStage");

            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.DblastModifiedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("DBLastModifiedDateTime");
        });

        modelBuilder.Entity<MaintenanceMode3>(entity =>
        {
            entity.HasKey(e => e.BaseManagedEntityId);

            entity.ToTable("MaintenanceMode");

            entity.HasIndex(e => e.LastModified, "idx_MaintenanceMode_LastModified").HasFillFactor(80);

            entity.Property(e => e.BaseManagedEntityId).ValueGeneratedNever();
            entity.Property(e => e.Comments).HasMaxLength(1000);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.ScheduledEndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.User).HasMaxLength(200);

            entity.HasOne(d => d.BaseManagedEntity).WithOne(p => p.MaintenanceMode3)
                .HasForeignKey<MaintenanceMode3>(d => d.BaseManagedEntityId)
                .HasConstraintName("FK_MaintenanceMode_BaseManagedEntity");
        });

        modelBuilder.Entity<StateView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("StateView");

            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.MonitorName).HasMaxLength(256);
            entity.Property(e => e.OperationalStateName).HasMaxLength(256);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

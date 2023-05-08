using System;
using System.Collections.Generic;

namespace ADScomLive.Entities;

public partial class AlertView
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public Guid MonitoringObjectId { get; set; }

    public Guid MonitoringClassId { get; set; }

    public string MonitoringObjectDisplayName { get; set; } = null!;

    public string? MonitoringObjectName { get; set; }

    public string? MonitoringObjectPath { get; set; }

    public string MonitoringObjectFullName { get; set; } = null!;

    public bool IsMonitorAlert { get; set; }

    public Guid ProblemId { get; set; }

    public Guid MonitoringRuleId { get; set; }

    public byte ResolutionState { get; set; }

    public byte Priority { get; set; }

    public byte Severity { get; set; }

    public string Category { get; set; } = null!;

    public string? Owner { get; set; }

    public string? ResolvedBy { get; set; }

    public DateTime? TimeRaised { get; set; }

    public DateTime TimeAdded { get; set; }

    public DateTime LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? TimeResolved { get; set; }

    public DateTime TimeResolutionStateLastModified { get; set; }

    public string? CustomField1 { get; set; }

    public string? CustomField2 { get; set; }

    public string? CustomField3 { get; set; }

    public string? CustomField4 { get; set; }

    public string? CustomField5 { get; set; }

    public string? CustomField6 { get; set; }

    public string? CustomField7 { get; set; }

    public string? CustomField8 { get; set; }

    public string? CustomField9 { get; set; }

    public string? CustomField10 { get; set; }

    public string? TicketId { get; set; }

    public string? Context { get; set; }

    public Guid? ConnectorId { get; set; }

    public DateTime LastModifiedByNonConnector { get; set; }

    public bool? MonitoringObjectInMaintenanceMode { get; set; }

    public DateTime? MaintenanceModeLastModified { get; set; }

    public byte? MonitoringObjectHealthState { get; set; }

    public DateTime? StateLastModified { get; set; }

    public int ConnectorStatus { get; set; }

    public Guid? TopLevelHostEntityId { get; set; }

    public int RepeatCount { get; set; }

    public Guid? AlertStringId { get; set; }

    public string? AlertStringName { get; set; }

    public string? LanguageCode { get; set; }

    public string? AlertStringDescription { get; set; }

    public string? AlertParams { get; set; }

    public string? SiteName { get; set; }

    public string? TfsWorkItemId { get; set; }

    public string? TfsWorkItemOwner { get; set; }
}

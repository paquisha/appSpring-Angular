using System;
using System.Collections.Generic;

namespace ADScomLive.Entities;

public partial class StateView
{
    public Guid? StateId { get; set; }

    public Guid BaseManagedEntityId { get; set; }

    public Guid MonitorId { get; set; }

    public string MonitorName { get; set; } = null!;

    public Guid? OperationalState { get; set; }

    public string? OperationalStateName { get; set; }

    public byte? HealthState { get; set; }

    public DateTime? LastModified { get; set; }

    public Guid? ParentMonitorId { get; set; }

    public bool IsDependencyMonitor { get; set; }

    public Guid? RelationshipTypeId { get; set; }

    public Guid? MemberMonitorId { get; set; }

    public Guid TargetManagedEntityType { get; set; }
}

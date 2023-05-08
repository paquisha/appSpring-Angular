using System;
using System.Collections.Generic;

namespace ADScomLive.Entities;

public partial class MaintenanceMode3
{
    public Guid BaseManagedEntityId { get; set; }

    public bool IsInMaintenanceMode { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime ScheduledEndTime { get; set; }

    public DateTime? EndTime { get; set; }

    public byte ReasonCode { get; set; }

    public string? Comments { get; set; }

    public string User { get; set; } = null!;

    public DateTime LastModified { get; set; }

    public Guid? ScheduleId { get; set; }

    public virtual BaseManagedEntity BaseManagedEntity { get; set; } = null!;
}

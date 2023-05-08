using System;
using System.Collections.Generic;

namespace ADScomLive.Entities;

public partial class BaseManagedEntity
{
    public Guid BaseManagedEntityId { get; set; }

    public int BaseManagedEntityInternalId { get; set; }

    public Guid BaseManagedTypeId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Path { get; set; }

    public string? Name { get; set; }

    public string DisplayName { get; set; } = null!;

    public Guid? TopLevelHostEntityId { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime LastModified { get; set; }

    public DateTime OverrideTimestamp { get; set; }

    public DateTime TimeAdded { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public virtual ICollection<Alert> Alerts { get; } = new List<Alert>();

    public virtual ICollection<Connector> Connectors { get; } = new List<Connector>();

    public virtual MaintenanceMode3? MaintenanceMode3 { get; set; }
}

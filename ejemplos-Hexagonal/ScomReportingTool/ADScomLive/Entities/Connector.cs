using System;
using System.Collections.Generic;

namespace ADScomLive.Entities;

public partial class Connector
{
    public Guid ConnectorId { get; set; }

    public Guid BaseManagedEntityId { get; set; }

    public bool IsInitialized { get; set; }

    public DateTime CurrentBookmark { get; set; }

    public bool IsBackwardCompatible { get; set; }

    public DateTime LastModified { get; set; }

    public virtual ICollection<Alert> Alerts { get; } = new List<Alert>();

    public virtual BaseManagedEntity BaseManagedEntity { get; set; } = null!;
}

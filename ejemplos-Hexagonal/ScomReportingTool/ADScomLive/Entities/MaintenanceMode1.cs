using System;
using System.Collections.Generic;

namespace ADScomLive.Entities;

public partial class MaintenanceMode1
{
    public Guid ManagedEntityGuid { get; set; }

    public DateTime DblastModifiedDateTime { get; set; }

    public bool DeletedInd { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public int SynchronizationBatchId { get; set; }

    public bool ProcessedInd { get; set; }
}

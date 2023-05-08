using System;
using System.Collections.Generic;

namespace ADScomLive.Entities;

public partial class MaintenanceMode
{
    public long ManagedEntityRowId { get; set; }

    public Guid ManagedEntityGuid { get; set; }

    public DateTime DblastModifiedDateTime { get; set; }

    public bool DeletedInd { get; set; }

    public int LastModifiedBatchId { get; set; }
}

using System;
using System.Collections.Generic;

namespace ADScomDataWarehouse.Entities;

public partial class VManagedEntity
{
    public int ManagedEntityRowId { get; set; }

    public int ManagementGroupRowId { get; set; }

    public Guid ManagedEntityGuid { get; set; }

    public int ManagedEntityTypeRowId { get; set; }

    public int? TopLevelHostManagedEntityRowId { get; set; }

    public string? FullName { get; set; }

    public string? Path { get; set; }

    public string? Name { get; set; }

    public string? DisplayName { get; set; }

    public string? ManagedEntityDefaultName { get; set; }

    public DateTime DwcreatedDateTime { get; set; }
}

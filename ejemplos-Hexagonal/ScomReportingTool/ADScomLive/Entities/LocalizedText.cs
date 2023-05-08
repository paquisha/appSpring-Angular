using System;
using System.Collections.Generic;

namespace ADScomLive.Entities;

public partial class LocalizedText
{
    public Guid LtstringId { get; set; }

    public string LanguageCode { get; set; } = null!;

    public byte LtstringType { get; set; }

    public Guid? ManagementPackId { get; set; }

    public string? ElementName { get; set; }

    public Guid? MpelementId { get; set; }

    public string? SubElementName { get; set; }

    public string? Ltvalue { get; set; }

    public DateTime TimeAdded { get; set; }

    public DateTime LastModified { get; set; }

    public Guid? DisplayStringId { get; set; }
}

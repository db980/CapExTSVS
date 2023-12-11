using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexInitRecipient
{
    public string RequestorCode { get; set; } = null!;

    public string RecipientsCode { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? MappedDate { get; set; }
}

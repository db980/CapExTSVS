using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexConversation
{
    public int ConId { get; set; }

    public int? CapexId { get; set; }

    public string? Remarks { get; set; }

    public string? FileName { get; set; }

    public string? PostedBy { get; set; }

    public DateTime? PostedDate { get; set; }
}

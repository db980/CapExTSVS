using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexComBumaster
{
    public int IndId { get; set; }

    public string CompCode { get; set; } = null!;

    public string? Des { get; set; }

    public string Bu { get; set; } = null!;

    public bool? Status { get; set; }
}

using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class TempDtLineItem001
{
    public string? Id { get; set; }

    public string ItemName { get; set; } = null!;

    public string PlantCode { get; set; } = null!;

    public string? Categories { get; set; }

    public string Uom { get; set; } = null!;

    public string Quantity { get; set; } = null!;

    public string TaxRate { get; set; } = null!;
}

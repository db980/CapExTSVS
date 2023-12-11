using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class Temp
{
    public string? OrgId { get; set; }

    public string? OrgName { get; set; }

    public string? Status { get; set; }

    public string? CreationDate { get; set; }

    public string? TrxNumber { get; set; }

    public string? TrxDate { get; set; }

    public string? CustomerTrxId { get; set; }

    public string? ItemCode { get; set; }

    public string? Description { get; set; }

    public string? LineNumber { get; set; }

    public string? ChasisNumber { get; set; }

    public string? EngineNumber { get; set; }

    public string? UomCode { get; set; }

    public string? Quantity { get; set; }

    public string? UnitPrice { get; set; }
}

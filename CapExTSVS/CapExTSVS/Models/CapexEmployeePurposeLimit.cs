using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexEmployeePurposeLimit
{
    public string? Grid { get; set; }

    public int? MaxLimit { get; set; }

    public int? InteractiveCost { get; set; }

    public string? CapexType { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }
}

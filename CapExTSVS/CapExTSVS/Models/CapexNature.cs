using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexNature
{
    public int Cnid { get; set; }

    public string? CapexNature1 { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }
}

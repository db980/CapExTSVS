using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexRightsMaster
{
    public int Rid { get; set; }

    public string? Rname { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }
}

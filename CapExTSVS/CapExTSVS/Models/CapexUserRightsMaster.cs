using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexUserRightsMaster
{
    public int Mid { get; set; }

    public int Rid { get; set; }

    public string EmpCode { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}

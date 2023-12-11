using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexViewOnlyEmpRoleMapping
{
    public string? EmpCode { get; set; }

    public string? CapexCreatedById { get; set; }

    public bool? IsActive { get; set; }

    public string? MappedBy { get; set; }

    public DateTime? MappedDate { get; set; }
}

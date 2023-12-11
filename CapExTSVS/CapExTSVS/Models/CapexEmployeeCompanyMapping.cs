using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexEmployeeCompanyMapping
{
    public int Id { get; set; }

    public string? EmpCode { get; set; }

    public string? CompanyIds { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}

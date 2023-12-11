using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class TestCapexPayApprovalCatEmpMapping
{
    public int Id { get; set; }

    public int CapexId { get; set; }

    public string Empcode { get; set; } = null!;

    public string DepartmentLvl1 { get; set; } = null!;

    public string DepartmentLvl2 { get; set; } = null!;

    public string FinanceLvl3 { get; set; } = null!;

    public string? FinancefLvl4 { get; set; }

    public string FinanceLvl5 { get; set; } = null!;

    public string MdLvl6 { get; set; } = null!;

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}

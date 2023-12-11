using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexPayApprovalCat
{
    public int Cpacid { get; set; }

    public int CapexId { get; set; }

    public decimal AmountForm { get; set; }

    public decimal AmountTo { get; set; }

    public string? DepartmentLvl1 { get; set; }

    public string? DepartmentLvl2 { get; set; }

    public string? FinanceLvl3 { get; set; }

    public string? FinancefLvl4 { get; set; }

    public string? FinanceLvl5 { get; set; }

    public string? MdLvl6 { get; set; }

    public string? Remarks { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    /// <summary>
    /// 0=Default,1=Customer Funded Capex
    /// </summary>
    public int? IsSpecialCategory { get; set; }

    public virtual CapexTypeMaster Capex { get; set; } = null!;
}

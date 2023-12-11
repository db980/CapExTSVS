using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexTypeMaster
{
    public int Ctid { get; set; }

    public string? CapexType { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public string? CompCode { get; set; }

    public string? Des { get; set; }

    public string? Bu { get; set; }

    public string? ReqType { get; set; }

    public string? BudgetType { get; set; }

    public virtual ICollection<CapexPayApprovalCatEmpMapping> CapexPayApprovalCatEmpMappings { get; } = new List<CapexPayApprovalCatEmpMapping>();

    public virtual ICollection<CapexPayApprovalCat> CapexPayApprovalCats { get; } = new List<CapexPayApprovalCat>();
}

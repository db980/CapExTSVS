using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexMasterItem
{
    public int Cmiid { get; set; }

    public int? CapexId { get; set; }

    public string? LineItem { get; set; }

    public string? ItemName { get; set; }

    public string? CapexNature { get; set; }

    public string? LocationCode { get; set; }

    public string? CostCenter { get; set; }

    public string? Uom { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? PerUnit { get; set; }

    public decimal? Amount { get; set; }

    public decimal? Tax { get; set; }

    public decimal? Total { get; set; }

    public string? Cwip { get; set; }

    public string? CwipInsertedBy { get; set; }

    public DateTime? CwipInsertedDate { get; set; }

    public string? CwipDescription { get; set; }

    public string? InternalOrder { get; set; }

    public string? InternalOrderInsertedBy { get; set; }

    public DateTime? InternalOrderInsertedDate { get; set; }

    public string? InternalOrderDescription { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }
}

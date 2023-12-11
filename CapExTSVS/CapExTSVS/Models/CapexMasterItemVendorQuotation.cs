using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexMasterItemVendorQuotation
{
    public int Cvqid { get; set; }

    public int? CapexId { get; set; }

    public string? FileCode { get; set; }

    public string? VendorCode { get; set; }

    public string? LineItem { get; set; }

    public string? ItemName { get; set; }

    public string? Uom { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? InitialRate { get; set; }

    public decimal? InitialAmount { get; set; }

    public decimal? FinalRate { get; set; }

    public decimal? FinalAmount { get; set; }

    public decimal? Tax { get; set; }

    public decimal? TotalWithTax { get; set; }

    public string? Remarks { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }
}

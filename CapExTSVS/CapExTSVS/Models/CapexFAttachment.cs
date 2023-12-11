using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexFAttachment
{
    public decimal Fileid { get; set; }

    public string? Filepth { get; set; }

    public string? FileCode { get; set; }

    public DateTime? Moddate { get; set; }

    public string? Userid { get; set; }

    public string? FileType { get; set; }

    public string? CapexId { get; set; }

    public decimal? QuotationAmount { get; set; }

    public string? TnC { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public string? PaymentTerm { get; set; }

    public string? Delivery { get; set; }

    public string? Fright { get; set; }

    public string? InstallationCost { get; set; }

    public string? Remarks { get; set; }
}

using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class VendorMaster
{
    public int Id { get; set; }

    public string VendorCode { get; set; } = null!;

    public string? CompanyCode { get; set; }

    public string? FirmName { get; set; }

    public string? FirmContactNumber { get; set; }

    public string? FirmEmailAddress { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? District { get; set; }

    public string? State { get; set; }

    public string? PinCode { get; set; }

    public string? ContactPersonName { get; set; }

    public string? ContactPersonContactNumber { get; set; }

    public string? ContactPersonEmailAddress { get; set; }

    public string? Gst { get; set; }

    public string? Remarks { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}

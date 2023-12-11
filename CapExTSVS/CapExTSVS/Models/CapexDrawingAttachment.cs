using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexDrawingAttachment
{
    public decimal Fileid { get; set; }

    public string? CapexId { get; set; }

    public string? Filepth { get; set; }

    public string? DrawingCapexName { get; set; }

    public string? Remarks { get; set; }

    public string? FileCode { get; set; }

    public string? AssignedTo { get; set; }

    public DateTime? AssignedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? IsActive { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdartedDate { get; set; }
}

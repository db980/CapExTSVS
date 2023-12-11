using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class IndId
{
    public int Id { get; set; }

    public int IndId1 { get; set; }

    public string Empcode { get; set; } = null!;

    public string? RmLvl { get; set; }

    public string? BuLvl { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}

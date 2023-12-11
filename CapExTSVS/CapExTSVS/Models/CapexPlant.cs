using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexPlant
{
    public string PlantCode { get; set; } = null!;

    public string? PlantDes { get; set; }

    public string? Street { get; set; }

    public string? District { get; set; }

    public string? City { get; set; }

    public string? PostlCode { get; set; }

    public string? Region { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? ComCode { get; set; }
}

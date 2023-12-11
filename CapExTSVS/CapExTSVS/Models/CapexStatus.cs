﻿using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexStatus
{
    public int? Id { get; set; }

    public string? CapexStatus1 { get; set; }

    public bool? IsActive { get; set; }

    public int? OrderList { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}

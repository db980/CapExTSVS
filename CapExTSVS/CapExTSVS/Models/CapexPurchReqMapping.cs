﻿using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexPurchReqMapping
{
    public string? PurchaseCode { get; set; }

    public string? RequisitionCode { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}

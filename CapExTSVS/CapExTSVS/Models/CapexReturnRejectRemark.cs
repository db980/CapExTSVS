using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class CapexReturnRejectRemark
{
    public int Id { get; set; }

    public int RefId { get; set; }

    public string RemarkFrom { get; set; } = null!;

    public string RemarkType { get; set; } = null!;

    public string? Remark { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}

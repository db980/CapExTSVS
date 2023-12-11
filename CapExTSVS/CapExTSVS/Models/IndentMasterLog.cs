using System;
using System.Collections.Generic;

namespace CapExTSVS.Models;

public partial class IndentMasterLog
{
    public int LogId { get; set; }

    public int? IndentId { get; set; }

    public string? Company { get; set; }

    public string? Bu { get; set; }

    public string? LocatioWork { get; set; }

    public string? TypeofWorkDetails { get; set; }

    public string? EnclosureBqqfile { get; set; }

    public string? EnclosureDrawingFile { get; set; }

    public string? RateProposed { get; set; }

    public DateTime? TentativeStartDate { get; set; }

    public DateTime? TentativeCompletionDate { get; set; }

    public string? ProposedContractorName { get; set; }

    public string? VendorExistingLocation { get; set; }

    public string? ContractorDetailsAddressGst { get; set; }

    public int? Status { get; set; }

    public string? RmLvl { get; set; }

    public DateTime? RmLvlDate { get; set; }

    public string? RmLvlRemarks { get; set; }

    public string? BuLvl { get; set; }

    public DateTime? BuLvlDate { get; set; }

    public string? BuLvlRemarks { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public string? RejectedBy { get; set; }

    public DateTime? RejectedDate { get; set; }

    public string? RejectedRemarks { get; set; }

    public string? ReturnedBy { get; set; }

    public DateTime? ReturnedDate { get; set; }

    public string? ReturnedRemarks { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public DateTime? LoggedDate { get; set; }

    public string? CapexType { get; set; }

    public string? Remarks { get; set; }

    public string? TagPurchaser { get; set; }
}
